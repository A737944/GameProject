using System.Security.AccessControl;

namespace GameProject
{
    /// <summary>
    /// 主表單類別
    /// </summary>
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        private Account currentUser;
        private Login loginForm;
        private string username;

=======
        /// <summary>
        /// 當前使用者
        /// </summary>
        private Account currentUser;

        /// <summary>
        /// 登入表單參考
        /// </summary>
        private Login loginForm;

        /// <summary>
        /// 使用者名稱
        /// </summary>
        private string username;

        /// <summary>
        /// 主表單建構函式
        /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
        public Form1(Account user, Login loginForm)
        {
            InitializeComponent();
            this.currentUser = user;
            this.loginForm = loginForm;
            label1.Text = $"歡迎 {currentUser.Username}！\n目前勝場：{currentUser.WinCount}";
        }

        /// <summary>
        /// 骰子遊戲按鈕點擊事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ShowModeDialog("dice");
        }

        /// <summary>
        /// 剪刀石頭布遊戲按鈕點擊事件
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            ShowModeDialog("rps");
        }

        /// <summary>
        /// 顯示遊戲模式選擇對話框
        /// </summary>
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

<<<<<<< HEAD
=======
        /// <summary>
        /// 登出按鈕點擊事件
        /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// 更新使用者資訊
        /// </summary>
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
        public void UpdateUserInfo()
        {
            label1.Text = $"歡迎 {currentUser.Username}！\n目前勝場：{currentUser.WinCount}";
        }

<<<<<<< HEAD
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
=======
        /// <summary>
        /// 排行榜按鈕點擊事件
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            RankList rankList = new RankList();
            rankList.Show();
        }
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
    }
}
