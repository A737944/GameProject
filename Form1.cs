using System.Security.AccessControl;

namespace GameProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowModeDialog("dice");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowModeDialog("rps");
        }
        private void ShowModeDialog(string gametype)
        {
            using (SelectGameMode selectGameMode = new SelectGameMode(gametype))
            {
                if (selectGameMode.ShowDialog() == DialogResult.OK)
                {
                    string mode = selectGameMode.SelectedMode;

                    if (mode == null) return;

                    if (gametype == "dice")
                    {
                        DiceGame diceGame = new DiceGame(mode, this);
                        diceGame.Show();
                    }
                    else if (gametype == "rps")
                    {
                        RPSGame rpsGame = new RPSGame(mode, this);
                        rpsGame.Show();
                    }
                }
            }
        }

        
    }
}
