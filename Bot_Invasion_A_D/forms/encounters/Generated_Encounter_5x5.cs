using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Invasion_A_D.forms.encounters
{
    public partial class Generated_Encounter_5x5 : Generated_Encounter_Parent
    {
        // constructor serves to connect actual winforms to unassigned winforms in parent
        public Generated_Encounter_5x5(Encounter enc)
        {
            this.enc = enc;
            InitializeComponent();
            CreateButtonDictionary(buttonPanel);
            this.highlighted = highlightPicture;
            this.pHealth = playerHealth;
            this.hInfo = highlitedInfo;
            this.escButton = escapeButton;
            this.medkitButton = btn_medkit;
            this.ControlBox = false;
        }
    }
}
