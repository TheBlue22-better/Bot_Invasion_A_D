using Bot_Invasion_A_D.Properties;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot_Invasion_A_D.code.entities.enemies;
using Bot_Invasion_A_D.code.entities;

namespace Bot_Invasion_A_D.code.world.encounter_tile.child_tiles
{
    internal class TurretTile : ParentTile
    {
        public TurretTile()
        {
            this.entity = RandomTurret();
        }

        public override void SetSprite()
        {
            
            if ((entity as Turret).GetState() == enums.STATE.AIM)
            {
                switch (entity.GetName())
                {
                    case "meleeTurret":
                        {
                            this.sprite = Resources.meleeTurret;
                            break;
                        }
                    case "rangedTurret":
                        {
                            this.sprite = Resources.rangedTurret;
                            break;
                        }
                }
            }
            else
            {
                switch (entity.GetName())
                {
                    case "meleeTurret":
                        {
                            this.sprite = Resources.meleeTurretAttack;
                            break;
                        }
                    case "rangedTurret":
                        {
                            this.sprite = Resources.rangedTurretAttack;
                            break;
                        }
                }
            }
            
        }

    }
}
