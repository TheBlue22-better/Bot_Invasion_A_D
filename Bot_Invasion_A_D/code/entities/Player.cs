using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public class Player : Entity
    {
        private string name;
        public Player(string name)
        {
            this.name = name;
            this.maxHealth = 1000;
            this.health = 1000;
        }
    }
}
