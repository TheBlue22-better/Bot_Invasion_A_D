using Bot_Invasion_A_D.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities.enemies
{
    public class RangedTurret : Turret
    {
        public RangedTurret()
        {
            this.health = 200;
            this.maxHealth = 200;
            this.name = "rangedTurret";
            this.range = 2;
            this.state = enums.STATE.AIM;
        }

        public override double DealDamage(DIFFICULTY diff)
        {
            Random random = new Random();
            switch (diff)
            {
                case DIFFICULTY.EASY:
                    {
                        return random.NextDouble() * (50 - 25.0) + (25.0);
                        break;
                    }
                case DIFFICULTY.MEDIUM:
                    {
                        return random.NextDouble() * (100.0 - 60.0) + (60.0);
                        break;
                    }
                case DIFFICULTY.HARD:
                    {
                        return random.NextDouble() * (180.0 - 100.0) + (100.0);
                        break;
                    }
            }
            return 0;
        }
    }
}
