using Bot_Invasion_A_D.code.world.encounter_tile;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities.enemies
{
    public abstract class ParentEnemy : Entity
    {
        protected int range;
        public ParentEnemy()
        {
        }

        public int GetRange() { return this.range; }

        public Tuple<int, int> FindPath(Tuple<int, int> playerLocation, ParentTile[,] tileGrid)
        {
            if (PositionNextToPlayer(positionInEncounter, playerLocation,range)) { return positionInEncounter; }        // enemy is already next to player, we dont need to move
            Tuple<int, int> firstStep = positionInEncounter;

            //                  X DIRECTION
            if (playerLocation.Item1 > firstStep.Item1 && firstStep.Item1 - 1 > 0 && !tileGrid[firstStep.Item1-1,firstStep.Item2].IsFull()) 
            {
                return new Tuple<int, int>(firstStep.Item1 - 1, firstStep.Item2);
            }
            else if (playerLocation.Item1 < firstStep.Item1 && firstStep.Item1 + 1 < tileGrid.GetLength(0)-1 && !tileGrid[firstStep.Item1 + 1, firstStep.Item2].IsFull())
            {
                return new Tuple<int, int>(firstStep.Item1 + 1, firstStep.Item2);
            }
            //                  ON THE SAME IN X AXIS, MOVING IN Y
            else
            {
                if (playerLocation.Item2 > firstStep.Item2 && firstStep.Item2 - 1 > 0 && !tileGrid[firstStep.Item1, firstStep.Item2 -1].IsFull())
                {
                    return new Tuple<int, int>(firstStep.Item1, firstStep.Item2 - 1 );
                }
                else if (playerLocation.Item2 < firstStep.Item2 && firstStep.Item2 + 1 < tileGrid.GetLength(0) - 1 && !tileGrid[firstStep.Item1, firstStep.Item2+1].IsFull())
                {
                    return new Tuple<int, int>(firstStep.Item1, firstStep.Item2 + 1);
                }
            }
            // maybe diagonal here but right now, idc
            return firstStep;
        }
    }
}
