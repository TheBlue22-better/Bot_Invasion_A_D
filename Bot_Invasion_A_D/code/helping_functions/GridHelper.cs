using Bot_Invasion_A_D.code.world.encounter_tile;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem_Testing.code.world.encounter_tile;

namespace Bot_Invasion_A_D.code.helping_functions
{
    public static class GridHelper
    {
        public static Tile[,] FillGrid(Tile[,] grid, ref Tuple<int, int> playerPos)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // mountain
            int maxMountains = rows - 1;        // rows == cols; rows is dym
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = tryFillTile(new MountainTile(), 10, ref maxMountains);
                }
            }
            // player
            int maxPlayer = 1;
            for (int i = 0; i < rows; i++)
            {
                if (!grid[rows - 1, i].isFull())
                {
                    grid[rows - 1, i] = tryFillTile(new PlayerTile(), 30, ref maxPlayer);
                    if (grid[rows - 1, i].hasPlayer()) playerPos = new Tuple<int, int>(rows - 1, i);
                }
            }
            if (maxPlayer == 1) { grid[rows - 1, cols - 1] = new PlayerTile(); }                                // in case we got no player generated
            // enemies
            Random random = new Random();
            int maxEnemies = (rows - 3) * (cols - 3);
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!grid[i, j].isFull())
                    {
                        grid[i, j] = tryFillTile(new EnemyTile(), 35, ref maxEnemies);
                    }
                }
            }
            return grid;
        }

        public static Tile tryFillTile(Tile tile, int percent, ref int maxAmount)
        {
            if (maxAmount == 0)
            {
                return new EmptyTile();
            }
            else if (GetChance(percent))
            {
                maxAmount--;
                return tile;
            }
            else return new EmptyTile();
        }

        public static void ShowGrid(Tile[,] tileGrid, ref SortedDictionary<string, Button> buttonDictionary)
        {
            int rows = tileGrid.GetLength(0);
            int cols = tileGrid.GetLength(1);
            Button[] buttons = buttonDictionary.Values.ToArray();

            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[k].Image = tileGrid[i, j].getSprite();
                    k++;
                }
            }
        }

        public static void GenerateGrid(ref Tile[,] tileGrid, int dim)
        {
            tileGrid = new Tile[dim,dim];
        }
    }
}
