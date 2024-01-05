using Bot_Invasion_A_D.code.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public class Player : Entity
    {
        int medkits;
        public Player(string name)
        {
            this.name = name;
            this.maxHealth = 1000;
            this.health = 1000;
            this.medkits = 0;
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
                        return random.NextDouble() * (50.0 - 25.0) + (25.0);
                    }
                case DIFFICULTY.HARD:
                    {
                        return random.NextDouble() * 25.0;
                    }
            }
            return 0;       // not possible as long as the world is one of 3 chosen difficulties
        }

        public void GiveMedkit() { medkits++; }
        public void ConsumeMedkit(DIFFICULTY diff) 
        {
            if (diff == DIFFICULTY.EASY) this.health += maxHealth / 4;
            else if (diff == DIFFICULTY.MEDIUM) this.health += maxHealth / 6;
            else this.health += maxHealth / 10;
            medkits--;
        }
        public int GetMedkits() { return medkits; }
        public override string GetInfo()
        {
            return health.ToString("F2") + "/" + maxHealth.ToString("F2");
        }
    }
}
