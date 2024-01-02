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
            this.state = enums.STATE.AIMING;
        }
    }
}
