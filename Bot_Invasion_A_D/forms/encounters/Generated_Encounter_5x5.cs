﻿using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.Properties;
using Sem_Testing.code.world.encounter_tile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Invasion_A_D.forms.encounters
{
    public partial class Generated_Encounter_5x5 : Generated_Encounter_Parent
    {
        public Generated_Encounter_5x5(Encounter enc)
        {
            this.enc = enc;
            InitializeComponent();
            CreateButtonDictionary(buttonPanel);
        }
    }
}
