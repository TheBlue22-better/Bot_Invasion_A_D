using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.world.encounter_tile;
using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.world.encounter_tile.child_tiles;
using System.CodeDom;

namespace Bot_Invasion_A_D.code.helping_functions
{
    // helping static methods that deal with grid inside encounters
    public static class GridHelper
    {
        // this method fills initialized tile grid with mountains, finish, boss (if the encounter is of boss type), player and enemies. Rest of the tiles are empty
        public static void FillGrid(ParentTile[,] grid, Player player,Dictionary<Tuple<int,int>, Turret> enemies, ENCOUNTER_TYPE eType)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // mountains
            int maxMountains = rows - 1;        // rows == cols, as the grid is a square
            for (int i = 0; i < rows; i++)      // generated anywhere in the grid
            {
                for (int j = 0; j < cols; j++)     
                {
                    grid[i, j] = tryFillTile(new TileFactory(MOUNTAIN).GetTile(), 10, ref maxMountains);
                }
            }

            // finish                                       
            int finishLocation = 0;                         // value is assigned as it is used optionally in boss
            int maxFinish = 1;
            for (int i = 0; i < rows; i++)                  // finish is generated in top row, unless a mountain is there already
            {
                grid[0, i] = tryFillTile(new TileFactory(FINISH).GetTile(), 30, ref maxFinish);
                if (grid[0, i].GetType() == TILE_TYPE.FINISH) finishLocation = i;
            }
            if (maxFinish == 1)
            {                                                // in case we got no finish generated, it is put in top left corner
                grid[0, 0] = new TileFactory(FINISH).GetTile();
                finishLocation = 0;
            }

            // boss (if eType is BOSS) 
            if (eType == ENCOUNTER_TYPE.BOSS)
            {
                grid[1, finishLocation] = new TileFactory(BOSS).GetTile();                  // boss is always generated directly undearneath the finish, replacing any mountain already there
                (grid[0, finishLocation] as FinishTile).bossAlive = true;                   // exit is locked
                grid[0, finishLocation].SetSprite();
                enemies.Add(new Tuple<int, int>(1, finishLocation), (grid[1, finishLocation].GetEntity() as Turret));
            }

            // player  
            int maxPlayer = 1;
            for (int i = 0; i < rows; i++)                                                  // player is generated in the bottom row, unless there is a mountain there already
            {
                if (!grid[rows - 1, i].IsFull())
                {
                    grid[rows - 1, i] = tryFillTile(new TileFactory(PLAYER).GetTile(), 30, ref maxPlayer);
                    if (grid[rows - 1, i].HasPlayer()) player.SetPosition(new Tuple<int, int>(rows - 1, i));
                }
            }
            if (maxPlayer == 1) {                                                // in case we got no player generated, it is put in bottom right corner
                grid[rows - 1, cols - 1] = new TileFactory(PLAYER).GetTile();
                player.SetPosition(new Tuple<int, int>(rows - 1, cols - 1));
            }         
            
            // enemies 
            int maxEnemies = (rows - 2) * (cols - 2);                           
            for (int i = 0; i < rows - 2; i++)                              // enemies are generated anywhere but the bottom two rows (to give player a breathing room)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!grid[i, j].IsFull())
                    {
                        grid[i, j] = tryFillTile(new TileFactory(TURRET).GetTile(), 30, ref maxEnemies);
                        if (grid[i, j].HasTurret()) {
                            grid[i, j].GetEntity().SetPosition(new Tuple<int, int>(i, j));
                            enemies.Add(new Tuple<int,int>(i,j), (grid[i, j].GetEntity() as Turret));
                        }                  
                    }
                }
            }
        }

        // this method returns an empty tile if maxAmount was already reached or if the percentage chance is not randomly met
        public static ParentTile tryFillTile(ParentTile tile, int percent, ref int maxAmount)
        {
            if (maxAmount == 0)
            {
                return new TileFactory(EMPTY).GetTile();
            }
            else if (GetChance(percent))
            {
                maxAmount--;
                return tile;
            }
            else return new TileFactory(EMPTY).GetTile();
        }

        // this method sets sprite/background picture for the grid of buttons in the encounter form
        public static void ShowGrid(ParentTile[,] tileGrid, SortedDictionary<string, Button> buttonDictionary)                    
        {
            int rows = tileGrid.GetLength(0);
            int cols = tileGrid.GetLength(1);
            Button[] buttons = buttonDictionary.Values.ToArray();

            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[k].BackgroundImage = tileGrid[i, j].GetSprite();
                    k++;
                }
            }
        }

        // this method initiliazes the tile grid based on the required dimension and returns it
        public static ParentTile[,] InitializeGrid(ParentTile[,] tileGrid, int dim)
        {
            return new ParentTile[dim,dim];
        }

        // this method returns true if the queried position is next to the player, given its range as an optional parameter
        public static bool PositionNextToPlayer(Tuple<int, int> pos, Tuple<int,int> playerPos, int range = 1)
        {
            if (pos.Item1 == playerPos.Item1 + range && pos.Item2 <= playerPos.Item2 + range && pos.Item2 >= playerPos.Item2 - range
                ||(pos.Item1 == playerPos.Item1 - range && pos.Item2 <= playerPos.Item2 + range && pos.Item2 >= playerPos.Item2 - range)
                || pos.Item2 == playerPos.Item2 + range && pos.Item1 <= playerPos.Item1 + range && pos.Item1 >= playerPos.Item1 - range
                || (pos.Item2 == playerPos.Item2 - range && pos.Item1 <= playerPos.Item1 + range && pos.Item1 >= playerPos.Item1 - range)) return true;
            else return false;
        }

        // this method is used to move the entity from one tile to another in the tilegrid
        public static void MoveEntity(ParentTile[,] tileGrid, Tuple<int, int> oldPos, Tuple<int, int> newPos)
        {
            if (oldPos != newPos)
            {
                ParentTile entityTile = tileGrid[oldPos.Item1, oldPos.Item2];
                tileGrid[oldPos.Item1, oldPos.Item2] = tileGrid[newPos.Item1, newPos.Item2];
                tileGrid[newPos.Item1, newPos.Item2] = entityTile;
            }
        }
    }
}
