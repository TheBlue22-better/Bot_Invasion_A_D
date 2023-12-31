﻿using Bot_Invasion_A_D.code.enums;
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
        // boss spawn stage
        int bossStage = 1;
        public BossTurret() 
        {
            this.health = 500;
            this.maxHealth = 500;
            this.name = "bossTurretPhase1";
            this.range = 2;
            this.state = STATE.AIM;
        }

        public int GetStage() { return bossStage; }
        public override double DealDamage()
        {
            Random random = new Random();
            if (bossStage == 1)
            {
                return random.NextDouble() * (1000 - 200) + 200;
            }
            else
            {
                return random.NextDouble() * (250 - 80) + 80;
            }
        }

        public override bool DropsMedkit()
        {
            return true;
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
    }
}
