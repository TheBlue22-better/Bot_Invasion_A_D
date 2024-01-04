using Bot_Invasion_A_D.code.world.encounter_tile;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Bot_Invasion_A_D.code.enums.STATE;
using Bot_Invasion_A_D.code.enums;

namespace Bot_Invasion_A_D.code.entities
{
    public class Turret : Entity
    {
        protected int range;
        protected STATE state;
        public Turret()
        {

        }

        public override string GetInfo()
        {
            return health.ToString() + "/" + maxHealth.ToString() + "\nCurrent State: " + state + "\nRange: " + range.ToString();
        }

        public int GetRange() { return range;}

        public void SetState(STATE state) { this.state = state; }

        public STATE GetState() { return state;}
    }
}
