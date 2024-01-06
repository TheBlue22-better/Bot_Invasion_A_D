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
    public partial class Win_Screen : Form
    {
        public Win_Screen()
        {
            InitializeComponent();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
