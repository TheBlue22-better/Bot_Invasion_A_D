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
    public class Turret : Entity
    {
        protected int range;
        protected STATE state;
        public Turret()
        {

        }

        public override string GetInfo()
        {
            return health.ToString("F2") + "/" + maxHealth.ToString("F2") + "\nCurrent State: " + state + "\nRange: " + range.ToString();
        }

        public int GetRange() { return range;}

        public void SetState(STATE state) { this.state = state; }

        public STATE GetState() { return state;}

        public override double DealDamage(DIFFICULTY diff)
        {
            return 0; // it is overridden in child turrets
        }

        public virtual bool DropsMedkit(DIFFICULTY diff)
        {
            return false;
        }

        public virtual void TurretTurn(Tuple<int, int> myPos, Player player, DIFFICULTY worldDiff)
        {
            if (state == STATE.AIM && PositionNextToPlayer(myPos, player.GetPosition(), range))
            {
                state = STATE.FIRE;
            }
            else if (state == STATE.FIRE && !PositionNextToPlayer(myPos, player.GetPosition(), range))
            {
                state = STATE.AIM;
            }
            else if (state == STATE.FIRE && PositionNextToPlayer(myPos, player.GetPosition(), range))
            {
                Damage(this, player, worldDiff);
            }
        }
    }
}
