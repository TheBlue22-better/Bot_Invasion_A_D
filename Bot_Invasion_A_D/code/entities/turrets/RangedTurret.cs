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
    }
}
