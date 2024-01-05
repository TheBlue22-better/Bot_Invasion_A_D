using Bot_Invasion_A_D.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public class Player : Entity
    {
        public Player(string name)
        {
            this.name = name;
            this.maxHealth = 1000;
            this.health = 1000;
        }

        public override double DealDamage(WORLD_DIFFICULTY diff)
        {
            Random random = new Random();
            switch (diff)
            {
                case WORLD_DIFFICULTY.EASY:
                    {
                        return random.NextDouble() * (75.0 - 50.0) + (50.0);
                        break;
                    }
                case WORLD_DIFFICULTY.MEDIUM:
                    {
                        return random.NextDouble() * (50.0 - 25.0) + (25.0);
                        break;
                    }
                case WORLD_DIFFICULTY.HARD:
                    {
                        return random.NextDouble() * 25.0;
                        break;
                    }
            }
            return 0;       // not possible as long as the world is one of 3 chosen difficulties
        }

        public override string GetInfo()
        {
            return health.ToString("F2") + "/" + maxHealth.ToString("F2");
        }
    }
}
