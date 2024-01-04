using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.world.encounter_tile;

namespace Bot_Invasion_A_D.code.helping_functions
{
    public static class GridHelper
    {
        public static ParentTile[,] FillGrid(ParentTile[,] grid, ref Player player, ref Dictionary<Tuple<int,int>, Turret> enemies)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // mountain
            int maxMountains = rows - 1;        // rows == cols; rows is dym
            for (int i = 0; i < rows; i++)      // y
            {
                for (int j = 0; j < cols; j++)     //x
                {
                    grid[i, j] = tryFillTile(new TileFactory(MOUNTAIN).GetTile(), 10, ref maxMountains);
                }
            }
            // finish
            int maxFinish = 1;
            for (int i = 0; i < rows; i++)      // x
            {
                if (!grid[0, i].IsFull())
                {
                    grid[0, i] = tryFillTile(new TileFactory(FINISH).GetTile(), 30, ref maxFinish);
                }
            }
            if (maxFinish == 1)
            {                                                // in case we got no finish generated
                grid[0, 0] = new TileFactory(FINISH).GetTile();
            }

            // player
            int maxPlayer = 1;
            for (int i = 0; i < rows; i++)      // x
            {
                if (!grid[rows - 1, i].IsFull())
                {
                    grid[rows - 1, i] = tryFillTile(new TileFactory(PLAYER).GetTile(), 30, ref maxPlayer);
                    if (grid[rows - 1, i].HasPlayer()) player.SetPosition(new Tuple<int, int>(rows - 1, i));
                }
            }
            if (maxPlayer == 1) {                                                // in case we got no player generated
                grid[rows - 1, cols - 1] = new TileFactory(PLAYER).GetTile();
                player.SetPosition(new Tuple<int, int>(rows - 1, cols - 1));
            }                               
            // enemies
            int maxEnemies = (rows - 3) * (cols - 3);
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!grid[i, j].IsFull())
                    {
                        grid[i, j] = tryFillTile(new TileFactory(TURRET).GetTile(), 20, ref maxEnemies);
                        if (grid[i, j].HasTurret()) {
                            grid[i, j].GetEntity().SetPosition(new Tuple<int, int>(i, j));
                            enemies.Add(new Tuple<int,int>(i,j), (grid[i, j].GetEntity() as Turret));
                        }                  
                    }
                }
            }
            return grid;
        }

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

        public static void ShowGrid(ParentTile[,] tileGrid, ref SortedDictionary<string, Button> buttonDictionary)                    
        {
            int rows = tileGrid.GetLength(0);
            int cols = tileGrid.GetLength(1);
            Button[] buttons = buttonDictionary.Values.ToArray();

            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[k].Image = tileGrid[i, j].GetSprite();
                    k++;
                }
            }
        }

        public static void InitializeGrid(ref ParentTile[,] tileGrid, int dim)
        {
            tileGrid = new ParentTile[dim,dim];
        }

        public static bool PositionNextToPlayer(Tuple<int, int> pos, Tuple<int,int> playerPos, int range = 1)
        {
            if (pos.Item1 == playerPos.Item1 + range && pos.Item2 <= playerPos.Item2 + range && pos.Item2 >= playerPos.Item2 - range
                ||(pos.Item1 == playerPos.Item1 - range && pos.Item2 <= playerPos.Item2 + range && pos.Item2 >= playerPos.Item2 - range)
                || pos.Item2 == playerPos.Item2 + range && pos.Item1 <= playerPos.Item1 + range && pos.Item1 >= playerPos.Item1 - range
                || (pos.Item2 == playerPos.Item2 - range && pos.Item1 <= playerPos.Item1 + range && pos.Item1 >= playerPos.Item1 - range)) return true;
            else return false;
        }


        public static void MoveEntity(ref ParentTile[,] tileGrid, Tuple<int, int> oldPos, Tuple<int, int> newPos)
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
