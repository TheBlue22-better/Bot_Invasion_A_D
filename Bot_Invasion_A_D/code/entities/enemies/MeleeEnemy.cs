using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities.enemies
{
    internal class MeleeEnemy : ParentEnemy
    {
        public MeleeEnemy() 
        {
            this.name = "meleeEnemy";
            this.range = 0;
        }
    }
}
