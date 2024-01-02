﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Invasion_A_D.code.entities
{
    public class Player : Entity
    {
        public Player(string name)
        {
            this.name = name;
            this.maxHealth = 1000;
            this.health = 1000;
        }

        public override string GetInfo()
        {
            return health.ToString() + "/" + maxHealth.ToString();
        }
    }
}
