using Bot_Invasion_A_D.code.enums;
using static Bot_Invasion_A_D.code.helping_functions.GridHelper;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.world.encounter_tile;

namespace Bot_Invasion_A_D.code.entities.child_turrets
{
    public class BossTurret : Turret
    {
        int bossStage = 1;
        public BossTurret() 
        {
            this.health = 500;
            this.maxHealth = 500;
            this.name = "bossTurretPhase1";
            this.range = 2;
            this.state = enums.STATE.AIM;
        }

        public override double DealDamage(DIFFICULTY diff)
        {
            Random random = new Random();
            if (bossStage == 0)
            {
                switch (diff)
                {
                    case DIFFICULTY.EASY:
                        {
                            return random.NextDouble() * (750 - 100) + 100;
                        }
                    case DIFFICULTY.MEDIUM:
                        {
                            return random.NextDouble() * (1000 - 200) + 200;
                        }
                    case DIFFICULTY.HARD:
                        {
                            return random.NextDouble() * (2000 - 500) + 500;
                        }
                }
            }
            else
            {
                switch (diff)
                {
                    case DIFFICULTY.EASY:
                        {
                            return random.NextDouble() * (100 - 50) + 50;
                        }
                    case DIFFICULTY.MEDIUM:
                        {
                            return random.NextDouble() * (250 - 80) + 80;
                        }
                    case DIFFICULTY.HARD:
                        {
                            return random.NextDouble() * (300 - 120) + 120;
                        }
                }
            }
            
            return 0;       // not possible as long as the world is one of 3 chosen difficulties
        }

        public override bool DropsMedkit(DIFFICULTY diff)
        {
            return true;
        }

        public override void TurretTurn(Tuple<int, int> myPos, Player player, DIFFICULTY worldDiff)
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

        public bool HasNextStage()
        {
            if (bossStage < 3) return true;
            return false;
        }

        public void NextStage() 
        {
            bossStage++;
            this.name = "bossTurretPhase" + bossStage;
            range--;
            maxHealth -= 200;
            health = maxHealth;
        }

        public void FinalAttack(ParentTile[,] tileGrid)
        {

        }
    }
}
