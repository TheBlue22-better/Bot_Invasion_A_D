using Bot_Invasion_A_D.code.enums;
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

namespace Bot_Invasion_A_D.forms.worlds
{
    public partial class World_Medium : Form
    {
        OpenWorld openWorld;
        Dictionary<String, Encounter> encounters;
        Dictionary<String, Button> encounterBtns;
        public World_Medium(OpenWorld world)
        {
            InitializeComponent(); ;
            this.openWorld = world;
            this.encounters = world.Encounters();
            encounterBtnsFill();

        }

        private void buttonGeneral_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            UpdateAvailable(btn);
            encounters[btn.Name].Generate();
            (sender as Button).Enabled = false;

        }
        private void UpdateAvailable(Button btn)
        {
            Encounter encounter = encounters[btn.Name];
            List<String> neigbours = encounter.Neigbours();
            foreach (String neigbour in neigbours)
            {
                if (!encounterBtns[neigbour].Enabled) encounterBtns[neigbour].Enabled = true;
            }
        }

        // extemely ugly, a better way to do this maybe?
        private void encounterBtnsFill()
        {
            this.encounterBtns = new Dictionary<string, Button>();
            encounterBtns.Add("E1", E1);
            encounterBtns.Add("E2", E2);
            encounterBtns.Add("E3", E3);
            encounterBtns.Add("E4", E4);
            encounterBtns.Add("E5", E5);
            encounterBtns.Add("E6", E6);
            encounterBtns.Add("E7", E7);
            encounterBtns.Add("E8", E8);
            encounterBtns.Add("E9", E9);
            encounterBtns.Add("E10", E10);
            encounterBtns.Add("E11", E11);
            encounterBtns.Add("E12", E12);
            encounterBtns.Add("E13", E13);
            encounterBtns.Add("E14", E14);
            encounterBtns.Add("E15", E15);
            encounterBtns.Add("E16", E16);
            encounterBtns.Add("E17", E17);
            encounterBtns.Add("E18", E18);
            encounterBtns.Add("E19", E19);
            encounterBtns.Add("E20", E20);
            encounterBtns.Add("E21", E21);
            encounterBtns.Add("E22", E22);
            encounterBtns.Add("E23", E23);
            encounterBtns.Add("E24", E24);
            encounterBtns.Add("E25", E25);
            encounterBtns.Add("E26", E26);
            encounterBtns.Add("E27", E27);
            encounterBtns.Add("E28", E28);
            encounterBtns.Add("E29", E29);
            encounterBtns.Add("E30", E30);
            encounterBtns.Add("E31", E31);
            encounterBtns.Add("E32", E32);
            encounterBtns.Add("E33", E33);
            encounterBtns.Add("E34", E34);
            encounterBtns.Add("E35", E35);
            encounterBtns.Add("E36", E36);
            encounterBtns.Add("E37", E37);
            encounterBtns.Add("E38", E38);
            encounterBtns.Add("E39", E39);
            encounterBtns.Add("E40", E40);
            encounterBtns.Add("E41", E41);
        }

        private void btn_EnabledChanged(object sender, EventArgs e)
        {
            Helper.OnClickChange(sender, encounters);
        }
    }


}
