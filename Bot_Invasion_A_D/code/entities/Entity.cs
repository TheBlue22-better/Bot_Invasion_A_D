using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public abstract class Entity
    {
        protected string name;
        protected double maxHealth;
        protected double health;
        protected Tuple<int, int> positionInEncounter;

        public void SetPosition(Tuple<int, int> positionInEncounter) { this.positionInEncounter = positionInEncounter; }
        public Tuple<int, int> GetPosition()
        {
            return this.positionInEncounter;
        }
        public string GetName() { return name; }

        public abstract string GetInfo();
    }
}
