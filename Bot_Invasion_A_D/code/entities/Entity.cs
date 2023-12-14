using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public class Entity
    {
        protected double maxHealth;
        protected double health;
        protected Tuple<int, int> positionInEncounter;

        public void SetPosition(Tuple<int, int> positionInEncounter) { this.positionInEncounter = positionInEncounter; }
    }
}
