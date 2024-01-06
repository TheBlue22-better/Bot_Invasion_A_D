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
        public override double DealDamage()
        {
            Random random = new Random();
            return random.NextDouble() * (50.0 - 25.0) + (25.0);
        }
        public void GiveMedkit() { medkits++; }
        public void ConsumeMedkit() 
        {
            health += maxHealth / 6;

            if (health > maxHealth) health = maxHealth;
            medkits--;
        }
        public int GetMedkits() { return medkits; }
        public override string GetInfo()
        {
            return health.ToString("F2") + "/" + maxHealth.ToString("F2");
        }
    }
}
