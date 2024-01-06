using Bot_Invasion_A_D.code.enums;
using Bot_Invasion_A_D.code.world;
using Bot_Invasion_A_D.forms.menu;
using Bot_Invasion_A_D.forms.worlds;

namespace Sem_Testing
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form wrld_medium = new World_Medium(new OpenWorld());
            this.Hide();
            wrld_medium.ShowDialog();
            this.Show();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits();
            this.Hide();
            credits.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}