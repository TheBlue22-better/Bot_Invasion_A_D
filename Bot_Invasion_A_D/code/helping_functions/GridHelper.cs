﻿using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.code.world.encounter_tile;

namespace Bot_Invasion_A_D.code.helping_functions
{
    public static class GridHelper
    {
        public static ParentTile[,] FillGrid(ParentTile[,] grid, ref Player player, ref List<ParentEnemy> enemies)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // mountain
            int maxMountains = rows - 1;        // rows == cols; rows is dym
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = tryFillTile(new TileFactory(MOUNTAIN).GetTile(), 10, ref maxMountains);
                }
            }
            // player
            int maxPlayer = 1;
            for (int i = 0; i < rows; i++)
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
                        grid[i, j] = tryFillTile(new TileFactory(ENEMY).GetTile(), 20, ref maxEnemies);
                        if (grid[i, j].HasEnemy()) {
                            grid[i, j].GetEnemy().SetPosition(new Tuple<int, int>(i, j));
                            enemies.Add(grid[i, j].GetEnemy());
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

        public static void GenerateGrid(ref ParentTile[,] tileGrid, int dim)
        {
            tileGrid = new ParentTile[dim,dim];
        }

        public static bool PositionNextToPlayer(Tuple<int, int> pos, Tuple<int,int> playerPos)
        {
            if ((pos.Item1 == playerPos.Item1 && (pos.Item2 + 1 == playerPos.Item2 || pos.Item2 - 1 == playerPos.Item2)) ||
                (pos.Item2 == playerPos.Item2 && (pos.Item1 + 1 == playerPos.Item1 || pos.Item1 - 1 == playerPos.Item1)) ||
                (pos.Item1 + 1 == playerPos.Item1 && pos.Item2 + 1 == playerPos.Item2) ||
                (pos.Item1 - 1 == playerPos.Item1 && pos.Item2 + 1 == playerPos.Item2) ||
                (pos.Item1 + 1 == playerPos.Item1 && pos.Item2 - 1 == playerPos.Item2) ||
                (pos.Item1 - 1 == playerPos.Item1 && pos.Item2 - 1 == playerPos.Item2)) return true;
            else return false;
        }

        public static void MovePlayer(ref ParentTile[,] tileGrid, Tuple<int, int> oldPos, Tuple<int, int> newPos)
        {
            tileGrid[oldPos.Item1, oldPos.Item2] = new TileFactory(EMPTY).GetTile();
            tileGrid[newPos.Item1, newPos.Item2] = new TileFactory(PLAYER).GetTile();
        }
    }
}
