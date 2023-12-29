using Bot_Invasion_A_D.forms.menu;

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
            Difficulty_Select dif_select = new Difficulty_Select();
            this.Hide();
            dif_select.ShowDialog();
            this.Close();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}