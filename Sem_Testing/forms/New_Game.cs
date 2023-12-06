using Sem_Testing.code;
using Sem_Testing.code.world;
using Sem_Testing.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem_Testing
{
    public partial class NewGame : Form
    {
        OpenWorld world;
        Dictionary<String, Encounter> encounters;
        Dictionary<String,Button> encounterBtns;
        public NewGame(OpenWorld world)
        {
            this.world = world;
            this.encounters = world.Encounters();
            InitializeComponent();
            // world is premade
            encounterBtns = new Dictionary<string, Button>();
            encounterBtns.Add("E0", btnE0);
            encounterBtns.Add("E1", btnE1);
            encounterBtns.Add("E2", btnE2);
            encounterBtns.Add("E3", btnE3);
            encounterBtns.Add("E4", btnE4);
            encounterBtns.Add("E5", btnE5);
            encounterBtns.Add("E6", btnE6);
            encounterBtns.Add("E7", btnE7);
            encounterBtns.Add("E8", btnE8);
            //
        }

        // based implementation

        private void btn_general_Click(object sender, EventArgs e)
        {
            UpdateAvailable(sender as Button);
            GenerateEncounter();
            (sender as Button).Enabled = false;
        }

        private void UpdateAvailable(Button btn)
        {
            Encounter encounter = encounters[btn.Text];
            List<String> neigbours = encounter.Neigbours();
            foreach (String neigbour in neigbours)
            {
                if (!encounterBtns[neigbour].Enabled) encounterBtns[neigbour].Enabled = true;
            }
        }

        private void GenerateEncounter()
        {
            Form encounter = new Gen_Encounter();
            encounter.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
