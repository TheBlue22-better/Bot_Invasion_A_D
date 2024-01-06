using Bot_Invasion_A_D.code.world.encounter_tile;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Bot_Invasion_A_D.code.enums.STATE;
using Bot_Invasion_A_D.code.enums;
using System.Numerics;

namespace Bot_Invasion_A_D.code.entities
{
    // parent turret is never actually interacted with, only serves as a template
    public class Turret : Entity
    {
        protected int range;
        protected STATE state;

        public override string GetInfo()
        {
            return health.ToString("F2") + "/" + maxHealth.ToString("F2") + "\nCurrent State: " + state + "\nRange: " + range.ToString();
        }
        public STATE GetState() { return state;}

        public override double DealDamage()
        {
            return 0;           // overriden in child turrets
        }

        public virtual bool DropsMedkit()
        {
            return false;       // overriden in child turrets also
        }

        public void TurretTurn(Tuple<int, int> myPos, Player player)
        {
            if (state == AIM && PositionNextToPlayer(myPos, player.GetPosition(), range))                   // turret is aming and sees a player, changes state, cant fire yet
            {
                state = FIRE;
            }
            else if (state == FIRE && !PositionNextToPlayer(myPos, player.GetPosition(), range))            // turret lost sight of the player, stops aiming
            {
                state = AIM;
            }
            else if (state == FIRE && PositionNextToPlayer(myPos, player.GetPosition(), range))             // turret is aiming and see the player, deals damage
            {
                Damage(this, player);
            }
        }
    }
}
