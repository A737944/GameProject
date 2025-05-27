namespace GameProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SelectGameMode modeDiolog = new SelectGameMode();
            modeDiolog.Setparent(this);
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
            SelectGameMode modeDialog = new SelectGameMode();
            modeDialog.Setparent(this);
            if (modeDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedMode = modeDialog.GameType;
                if (gametype == "dice")
                {
                    DiceGame diceGame = new DiceGame(selectedMode, modeDialog);
                    diceGame.Show();
                }
                else if (gametype == "rps")
                {
                    RPSGame rpsGame = new RPSGame(selectedMode, modeDialog);
                    rpsGame.Show();
                }
                this.Hide();
            }
        }

        
    }
}
