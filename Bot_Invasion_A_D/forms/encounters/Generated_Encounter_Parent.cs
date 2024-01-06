using Bot_Invasion_A_D.code.helping_functions;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.Properties;
using static Bot_Invasion_A_D.code.helping_functions.Helper;
using static Bot_Invasion_A_D.code.enums.TILE_TYPE;
using Bot_Invasion_A_D.code.enums;
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
        protected Button medkitButton;

        public Generated_Encounter_Parent DimEncounter(int dim)
        {
            if (dim == 5) return new Generated_Encounter_5x5(enc);
            else if (dim == 6) return new Generated_Encounter_6x6(enc);
            else return new Generated_Encounter_7x7(enc);
        }

        public ref SortedDictionary<string, Button> getDictionary()
        {
            return ref buttonDictionary;
        }

        protected void CreateButtonDictionary(Control container)
        {
            buttonDictionary = new SortedDictionary<string, Button>();
            var buttons = container.Controls.OfType<Button>();

            foreach (Button btn in buttons)
            {
                buttonDictionary.Add(btn.Name, btn);
            }
        }

        public void UpdateEncounter(Encounter enc) { this.enc = enc; }
        public void UpdatePlayerHealth(string health)
        {
            pHealth.Text = health;
        }
        public void UpdateEnemyHealth(Tuple<int, int> location)
        {
            hInfo.Text = enc.GetGrid()[location.Item1, location.Item2].GetEntity().GetInfo();
        }
        public void UpdateMedkitButton()
        {
            medkitButton.Text = enc.GetPlayer().GetMedkits() + " Medkit(s) left";
            if (enc.GetPlayer().GetMedkits() == 0) medkitButton.Enabled = false;
            else medkitButton.Enabled = true;
        }
        // any "tile" button on any encounter does the same thing
        protected void btn_general_Click(object sender, EventArgs e)
        {
            switch (enc.UpdateEncounter((sender as Button).Name))
            {
                case RESULT.NOTHING:                                        // player was not killed nor anyone escaped
                    {
                        GridHelper.ShowGrid(enc.GetGrid(), buttonDictionary);
                        UpdatePlayerHealth(enc.GetPlayer().GetInfo());
                        UpdateMedkitButton();

                        Tuple<int, int> location = NameToLocation((sender as Button).Name);
                        if (enc.GetGrid()[location.Item1, location.Item2].HasTurret())
                        {
                            UpdateEnemyHealth(location);
                        }
                        break;
                    }
                case RESULT.VICTORY:                                            // player has escaped
                    {
                        this.Close();
                        break;
                    }
                case RESULT.DEATH:                                              // player has died
                    {
                        this.Close();
                        break;
                    }
            }
            
        }

        // hovering over a tile shows its sprite and info about the tile
        protected void btn_mouse_Enter(object sender, EventArgs e)
        {
            highlighted.BackgroundImage = (sender as Button).BackgroundImage;               // sprite of the tile
            Tuple<int, int> location = NameToLocation((sender as Button).Name);             // each tile has different info, some given by entity inside that tile
            if (enc.GetGrid()[location.Item1, location.Item2].GetEntity() != null)          // entity gives info
            {
                UpdateEnemyHealth(location);
            }
            else if (enc.GetGrid()[location.Item1, location.Item2].GetType() == MOUNTAIN)   // other is based on the given tile
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

        // default state of the highlight 
        protected void btn_mouse_Exit(object sender, EventArgs e)
        {
            highlighted.BackgroundImage = Resources.nothing;
            hInfo.Text = "<UNKNOWN>";
        }

        // player can escape and skip the encounter, they will they damage, if they hover over the button before clicking it, they will see how much
        protected void btn_Escape_Enter(object sender, EventArgs e)
        {
            escButton.Text = "YOU WILL TAKE\n" + enc.GetEscapeDamage().ToString("F2") + "\nDAMAGE!";
        }

        // defaut state of the escape button
        protected void btn_Escape_Exit(object sender, EventArgs e)
        {
            escButton.Text = "<ESCAPE!>";
        }

        protected void btn_Escape_Click(object sender, EventArgs e)
        {
            enc.GetPlayer().SetHealth(enc.GetPlayer().GetHealth() - enc.GetEscapeDamage());
            this.Close();
        }

        protected void btn_Medkit_Click(object sender, EventArgs e)
        {
            enc.GetPlayer().ConsumeMedkit();
            UpdatePlayerHealth(enc.GetPlayer().GetInfo());
            UpdateMedkitButton();
        }
    }
}
