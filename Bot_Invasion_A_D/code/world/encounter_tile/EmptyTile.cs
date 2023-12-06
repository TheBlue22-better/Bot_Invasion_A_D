using Bot_Invasion_A_D.Properties;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public class EmptyTile : Tile
    {
        public EmptyTile()
        {
            this.sprite = Resources.emptyTile;
        }

        public new bool isFull()
        {
            return false;
        }
    }
}
