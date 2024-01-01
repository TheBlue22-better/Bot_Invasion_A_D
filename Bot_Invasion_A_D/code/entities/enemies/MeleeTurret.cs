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
            this.name = "meleeTurret";
            this.range = 1;
        }
    }
}
