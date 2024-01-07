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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void btn_playGame_Click(object sender, EventArgs e)
        {
            Form wrld_medium = new World_Medium(new OpenWorld());
            this.Hide();
            wrld_medium.ShowDialog();
            this.Close();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
