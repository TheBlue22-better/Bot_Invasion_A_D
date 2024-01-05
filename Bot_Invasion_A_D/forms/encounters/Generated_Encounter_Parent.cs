using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.Properties;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
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
    public partial class Generated_Encounter_Parent : Form
    {
        protected Encounter enc;
        protected SortedDictionary<string, Button> buttonDictionary;
        protected PictureBox highlighted;
        protected Label pHealth;
        protected Label hInfo;
        protected Button escButton;

        public Generated_Encounter_Parent DimEncounter(int dim)
        {
            if (dim == 5) return new Generated_Encounter_5x5(enc);
            else if (dim == 6) return new Generated_Encounter_6x6(enc);
            else return new Generated_Encounter_7x7(enc);
        }

        public void SetEncounter(Encounter enc)
        {
            this.enc = enc;
        }

        public ref SortedDictionary<string, Button> getDictionary()
        {
            return ref buttonDictionary;
        }

        protected void CreateButtonDictionary(Control container)
        {
            buttonDictionary = new SortedDictionary<string, Button>();
            // Use LINQ to filter controls to only include buttons
            var buttons = container.Controls.OfType<Button>();

            // Add buttons to the dictionary with their names as keys
            foreach (var button in buttons)
            {
                buttonDictionary.Add(button.Name, button);
            }
        }

        public void UpdateEncounter(Encounter enc) { this.enc = enc; }

        protected void btn_general_Click(object sender, EventArgs e)
        {
            enc.UpdateEncounter((sender as Button).Name);
            GridHelper.ShowGrid(enc.GetGrid(), ref buttonDictionary);
            UpdatePlayerHealth(enc.GetPlayer().GetInfo());
        }

        protected void btn_mouse_Enter(object sender, EventArgs e)
        {
            highlighted.BackgroundImage = (sender as Button).Image;
            Tuple<int, int> location = NameToLocation((sender as Button).Name);
            if (enc.GetGrid()[location.Item1, location.Item2].GetEntity() != null)
            {
                hInfo.Text = enc.GetGrid()[location.Item1, location.Item2].GetEntity().GetInfo();
                
            }
            else if (enc.GetGrid()[location.Item1, location.Item2].GetType() == MOUNTAIN)
            {
                hInfo.Text = "IMPASSABLE.";
            }
            else if (enc.GetGrid()[location.Item1, location.Item2].GetType() == FINISH)
            {
                hInfo.Text = "MOVE HERE\nTO ESCAPE.";
            }
            else
            {
                hInfo.Text = "NOTHING.";
            }
        }

        protected void btn_mouse_Exit(object sender, EventArgs e)
        {
            highlighted.BackgroundImage = Resources.nothing;
            hInfo.Text = "<UNKNOWN>";
        }

        public void UpdatePlayerHealth(string health)
        {
            pHealth.Text = health;
        }

        protected void btn_Escape_Enter(object sender, EventArgs e)
        {
            escButton.Text = "YOU WILL TAKE\n" + enc.EscapeDamage().ToString("F2") + "\nDAMAGE!";
        }

        protected void btn_Escape_Exit(object sender, EventArgs e)
        {
            escButton.Text = "<ESCAPE!>";
        }

        protected void btn_Escape_Click(object sender, EventArgs e)
        {
            enc.GetPlayer().SetHealth(enc.GetPlayer().GetHealth() - enc.EscapeDamage());
            this.Close();
        }

    }
}
