using Bot_Invasion_A_D.code.world;
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
    public partial class Generated_Encounter_Parent : Form
    {
        protected Encounter enc;
        protected SortedDictionary<string, Button> buttonDictionary;
        public Generated_Encounter_Parent()
        {
            InitializeComponent();
        }

        public Generated_Encounter_Parent DimEncounter(int dim)
        {
            if (dim == 5) return new Generated_Encounter_5x5();
            else if (dim == 6) return new Generated_Encounter_6x6();
            else return new Generated_Encounter_7x7();
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



        protected void btn_general_Click(object sender, EventArgs e)
        {

        }
    }
}
