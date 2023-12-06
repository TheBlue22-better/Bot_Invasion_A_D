﻿using Bot_Invasion_A_D.Properties;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.world.encounter_tile
{
    public class MountainTile : Tile
    {
        public MountainTile() 
        {
            this.sprite = Resources.mountain;
        }

        public bool isFull()
        {
            return true;
        }
    }
}
