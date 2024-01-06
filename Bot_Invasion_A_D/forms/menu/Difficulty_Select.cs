using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.forms.worlds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Invasion_A_D.forms.menu
{
    public partial class Difficulty_Select : Form
    {
        public Difficulty_Select()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_easy_Click(object sender, EventArgs e)
        {

        }

        private void btn_medium_Click(object sender, EventArgs e)
        {
            Form wrld_medium = new World_Medium(new OpenWorld(DIFFICULTY.MEDIUM));
            this.Hide();
            wrld_medium.ShowDialog();
            this.Close();
            
        }

        private void btn_hard_Click(object sender, EventArgs e)
        {

        }
    }
}
