using Sem_Testing.code.world;

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
            OpenWorld openWorld = new OpenWorld();
            Form newGame = new NewGame(openWorld);
            this.Hide();
            newGame.ShowDialog();
            this.Close();
            
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}