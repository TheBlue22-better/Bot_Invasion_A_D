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

        public override double DealDamage(DIFFICULTY diff)
        {
            Random random = new Random();
            switch (diff)
            {
                case DIFFICULTY.EASY:
                    {
                        return random.NextDouble() * (75.0 - 50.0) + (50.0);
                    }
                case DIFFICULTY.MEDIUM:
                    {
                        return random.NextDouble() * (150.0 - 70.0) + (70.0);
                    }
                case DIFFICULTY.HARD:
                    {
                        return random.NextDouble() * (250.0 - 120.0) + (120.0);
                    }
            }
            return 0;       // not possible as long as the world is one of 3 chosen difficulties
        }

        public override bool DropsMedkit(DIFFICULTY diff)
        {
            if (diff == DIFFICULTY.EASY) return GetChance(35);
            else if (diff == DIFFICULTY.MEDIUM) return GetChance(60);
            else return GetChance(80);
        }
    }
}
