using System.Security.AccessControl;

namespace GameProject
{
    public partial class Form1 : Form
    {
        private Account currentUser;
        private Login loginForm;
        private string username;

        public Form1(Account user, Login loginForm)
        {
            InitializeComponent();
            this.currentUser = user;
            this.loginForm = loginForm;
            label1.Text = $"歡迎 {currentUser.Username}！\n目前勝場：{currentUser.WinCount}";
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
                        DiceGame diceGame = new DiceGame(mode, this, currentUser);
                        diceGame.Show();
                    }
                    else if (gametype == "rps")
                    {
                        RPSGame rpsGame = new RPSGame(mode, this, currentUser);
                        rpsGame.Show();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        public void UpdateUserInfo()
        {
            label1.Text = $"歡迎 {currentUser.Username}！\n目前勝場：{currentUser.WinCount}";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            RankList rankList = new RankList();
            rankList.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGray;
        }
    }
}
