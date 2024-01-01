using Bot_Invasion_A_D.code.world.encounter_tile;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public abstract class Turret : Entity
    {
        protected int range;
        public Turret()
        {
        }

        public int GetRange() { return range;}
    }
}
