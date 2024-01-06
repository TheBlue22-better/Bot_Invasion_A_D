using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.forms.menu;
using Bot_Invasion_A_D.Properties;
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
            InitializeComponent();
            this.openWorld = world;
            this.encounters = world.Encounters();
            EncounterBtnsFill();
            UpdatePlayerInfo();
        }

        // I use the same method for any of the "encounter" buttons; they all do the same function
        private void buttonGeneral_Click(object sender, EventArgs e)
        {
            Form encounter = new Form();
            Button btn = (sender as Button);                        // sender is always a button, safe to do this
            UpdateAvailable(btn);                                   // update next node in the path in the open world
            encounter = encounters[btn.Name].Generate(openWorld.GetPlayer());           // ecounters are initialized in the constructor, filled with data here
            (sender as Button).Enabled = false;                                 // you can't repeat encounters
            encounter.ShowDialog();
            // encounter has concluded
            UpdatePlayerInfo();                                             
            if (openWorld.GetPlayer().IsDead()) ShowGameOverScreen();                       // check for endgame conditions
            else if (encounters[btn.Name].GetType() == ENCOUNTER_TYPE.BOSS) ShowWinScreen();
        }

        // method enables nodes that are next to the current node, neigbours are pre-set
        private void UpdateAvailable(Button btn)
        {
            Encounter encounter = encounters[btn.Name];
            List<String> neigbours = encounter.GetNeigbours();
            foreach (String neigbour in neigbours)
            {
                if (!encounterBtns[neigbour].Enabled) encounterBtns[neigbour].Enabled = true;
            }
        }
        private void EncounterBtnsFill()
        {
            encounterBtns = new Dictionary<string, Button>();

            var buttons = this.Controls.OfType<Button>();
            foreach (Button btn in buttons)
            {
                encounterBtns.Add(btn.Name, btn);
            }
        }

        // color change when button is enabled
        private void btn_EnabledChanged(object sender, EventArgs e)
        {
            Helper.OnClickChange(sender, encounters);
        }

        private void UpdatePlayerInfo()
        {
            playerPicture.BackgroundImage = Resources.player;
            playerInfoLabel.Text = openWorld.GetPlayer().GetInfo();
            medkitLabel.Text = openWorld.GetPlayer().GetMedkits() + " Medkit(s) left";
            if (openWorld.GetPlayer().GetMedkits() == 0) btn_medkit.Enabled = false;
            else btn_medkit.Enabled = true;
        }

        private void btn_medkit_Click(object sender, EventArgs e)
        {
            openWorld.GetPlayer().ConsumeMedkit();
            UpdatePlayerInfo();
        }

        private void ShowGameOverScreen()
        {
            this.Hide();
            Game_Over gameOverScreen = new Game_Over();
            gameOverScreen.ShowDialog();
            this.Close();
        }

        private void ShowWinScreen()
        {
            this.Hide();
            Win_Screen winScreen = new Win_Screen();
            winScreen.ShowDialog();
            this.Close();
        }
    }


}
