using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
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
    public partial class Generated_Encounter_6x6 : Generated_Encounter_Parent
    {
        public Generated_Encounter_6x6(Encounter enc)   // i hate that i have to copy the same damn constructor 3 times...
        {
            this.enc = enc;
            InitializeComponent();
            CreateButtonDictionary(buttonPanel);
            this.highlighted = highlightPicture;
            this.pHealth = playerHealth;
            this.hInfo = highlitedInfo;
        }
    }
}
