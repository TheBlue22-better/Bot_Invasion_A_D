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
            this.name = "rangedTurret";
            this.range = 2;
        }
    }
}
