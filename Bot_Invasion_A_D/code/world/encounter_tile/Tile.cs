using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_Testing.code.world.encounter_tile
{
    public abstract class Tile
    {
        protected Bitmap sprite;

        public Tile()
        {

        }

        public Bitmap getSprite()
        {
            return sprite;
        }

        public abstract bool isFull();

        public abstract bool hasPlayer();
    }
}
