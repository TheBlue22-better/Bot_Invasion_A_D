using Bot_Invasion_A_D.Properties;
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
            this.tileType = enums.TILE_TYPE.PLAYER;
        }

        public override bool isFull()
        {
            return true;
        }

        public override bool hasPlayer()
        {
            return true;
        }

        public override bool hasEnemy()
        {
            return false;
        }
    }
}
