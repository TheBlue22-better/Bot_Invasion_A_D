using Bot_Invasion_A_D.code.entities;
using Bot_Invasion_A_D.code.entities.child_turrets;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile.child_tiles
{
    internal class BossTile : ParentTile
    {
        public BossTile()
        {
            this.entity = new BossTurret();
        }

        // sprite is set based on boss state and phase
        public override void SetSprite()
        {
            if ((entity as Turret).GetState() == enums.STATE.AIM)
            {
                switch ((entity as BossTurret).GetStage())
                {
                    case 1:
                        {
                            this.sprite = Resources.BossPhase1;
                            break;
                        }
                    case 2:
                        {
                            this.sprite = Resources.BossPhase2;
                            break;
                        }
                    case 3:
                        {
                            this.sprite = Resources.BossPhase3;
                            break;
                        }
                }
            }
            else
            {
                switch ((entity as BossTurret).GetStage())
                {
                    case 1:
                        {
                            this.sprite = Resources.BossPhase1Attack;
                            break;
                        }
                    case 2:
                        {
                            this.sprite = Resources.BossPhase2Attack;
                            break;
                        }
                }
            }
        }
    }
}
