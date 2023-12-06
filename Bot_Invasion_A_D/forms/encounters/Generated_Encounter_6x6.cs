using Bot_Invasion_A_D.code.helping_functions;
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
    public partial class Generated_Encounter_6x6 : Generated_Encounter_Parent
    {
        Tile[,] tileGrid;
        SortedDictionary<string, Button> buttonDictionary;
        public Generated_Encounter_6x6()
        {
            InitializeComponent();
            CreateButtonDictionary(buttonPanel);
        }

        public void SetGrid (Tile[,] tileGrid)
        {
            this.tileGrid = tileGrid;
        }
        private void btn_general_Click(object sender, EventArgs e)
        {

        }
    }
}
