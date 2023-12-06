using Bot_Invasion_A_D.Properties;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    internal class PlayerTile : Tile
    {
        public PlayerTile() 
        {
            this.sprite = Resources.player;
        }

        public bool isFull()
        {
            return true;
        }

        public bool hasPlayer()
        {
            return true;
        }
    }
}
