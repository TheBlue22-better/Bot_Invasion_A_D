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

        public override void SetSprite()
        {
            if ((entity as Turret).GetState() == enums.STATE.AIM)
            {
                switch (entity.GetName())
                {
                    case "bossTurretPhase1":
                        {
                            this.sprite = Resources.BossPhase1;
                            break;
                        }
                    case "bossTurretPhase2":
                        {
                            this.sprite = Resources.BossPhase2;
                            break;
                        }
                    case "bossTurretPhase3":
                        {
                            this.sprite = Resources.BossPhase3;
                            break;
                        }
                }
            }
            else
            {
                switch (entity.GetName())
                {
                    
                }
            }
        }
    }
}
