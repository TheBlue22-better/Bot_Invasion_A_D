using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities.enemies
{
    internal class MeleeTurret : Turret
    {
        public MeleeTurret() 
        {
            this.health = 300;
            this.maxHealth = 300;
            this.name = "meleeTurret";
            this.range = 1;
            this.state = enums.STATE.AIM;
        }

        public override double DealDamage()
        {
            Random random = new Random();
            return random.NextDouble() * (150.0 - 70.0) + 70.0;
        }

        public override bool DropsMedkit()
        {
            return GetChance(60);
        }
    }
}
