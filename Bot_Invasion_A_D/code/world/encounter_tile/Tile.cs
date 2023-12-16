using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public abstract class Tile
    {
        protected Bitmap sprite;
        protected TILE_TYPE tileType;

        public Tile()
        {

        }

        public Bitmap getSprite()
        {
            return sprite;
        }

        public abstract bool isFull();

        public abstract bool hasPlayer();

        public abstract bool hasEnemy();
    }
}
