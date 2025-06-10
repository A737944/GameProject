using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameProject.Properties;
using static GameProject.GameFramework;
using System.Text.Json;

namespace GameProject
{
    /// <summary>
    /// 骰子遊戲表單類別
    /// </summary>
    public partial class DiceGame : Form
    {
        /// <summary>
        /// 遊戲類型
        /// </summary>
        private string gameType;

        /// <summary>
        /// 骰子遊戲邏輯
        /// </summary>
        private GameFramework.DiceGameLogic gameLogic;

        /// <summary>
        /// 玩家1
        /// </summary>
        private GameFramework.Player player1;

        /// <summary>
        /// 玩家2
        /// </summary>
        private GameFramework.Player player2;

        /// <summary>
        /// 隨機數產生器
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// 父表單參考
        /// </summary>
        private Form1 parentForm;

        /// <summary>
        /// 玩家1擲骰結果
        /// </summary>
        private int? player1Roll = null;

        /// <summary>
        /// 玩家2擲骰結果
        /// </summary>
        private int? player2Roll = null;

        /// <summary>
        /// 當前使用者
        /// </summary>
        private Account currentUser;

        /// <summary>
        /// 骰子遊戲表單建構函式
        /// </summary>
        public DiceGame(string mode, Form1 parent, Account currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            gameType = mode;
            this.parentForm = parent;

            this.Text = $"骰子遊戲-{gameType}";

            if (gameType == "2p")
            {
                player1 = new GameFramework.Player(currentUser.Username);
                player2 = new GameFramework.Player("Player 2");

                button1.Text = "玩家一丟骰";
                button2.Text = "玩家二丟骰";
                button2.Visible = true;
                button2.Enabled = false;
            }
            else if (gameType == "com")
            {
                player1 = new GameFramework.Player(currentUser.Username);
                player2 = new GameFramework.Player("Computer");

                button1.Text = "Roll Dice";
                button2.Visible = false;
            }
            else if (gameType == "com vs com")
            {
                player1 = new GameFramework.Player("Computer 1");
                player2 = new GameFramework.Player("Computer 2");

                button1.Text = "Auto Play";
                button2.Visible = false;
            }
            label4.Visible = false; // 隱藏比分顯示
            // 記得只初始化一次 gameLogic，使用正確的 p1、p2
            gameLogic = new GameFramework.DiceGameLogic(player1, player2);
            this.currentUser = currentUser;
        }

        /// <summary>
        /// 玩家1擲骰按鈕點擊事件
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            if (gameType == "2p")
            {
                pictureBox1.Image = Properties.Resource.roll_dice;
                label1.Text = $"{player1.Name} 擲骰中...";
                label2.Text = "";
                label3.Text = "勝負:";

                // 模擬動畫時間
                await Task.Delay(1000);

                // 擲骰 + 顯示點數與靜態圖
                gameLogic.RollPlayer1(); // 只擲 Player1
                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                pictureBox1.Image = GetDiceImage(gameLogic.Player1Roll);

                // 禁用自己，啟用玩家2按鈕
                button1.Enabled = false;
                button2.Enabled = true;

            }
            else if (gameType == "com")
            {
                label1.Text = $"{player1.Name} 擲骰中...";
                label2.Text = $"{player2.Name} 擲骰中...";

                pictureBox1.Image = Properties.Resource.roll_dice;
                pictureBox2.Image = Properties.Resource.roll_dice;

                button1.Enabled = false;
                button2.Enabled = false;

                await Task.Delay(1000); // 模擬骰子動畫時間

                var result = gameLogic.PlayRound();

                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                pictureBox1.Image = GetDiceImage(gameLogic.Player1Roll);

                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                pictureBox2.Image = GetDiceImage(gameLogic.Player2Roll);

                label3.Text = "勝負：" + gameLogic.GetWinnerText();
                label4.Text = gameLogic.GetScoreText();
                label4.Visible = true;

                if (gameLogic.GetWinnerText() == $"{player1.Name} 贏了!")
                {
                    currentUser.WinCount++;
                    // 更新 accounts.json
                    string jsonPath = "accounts.json";
                    if (File.Exists(jsonPath))
                    {
                        string json = File.ReadAllText(jsonPath);
                        var accounts = JsonSerializer.Deserialize<List<Account>>(json);
                        var account = accounts.Find(a => a.Username == currentUser.Username);
                        if (account != null)
                        {
                            account.WinCount = currentUser.WinCount;
                            string updatedJson = JsonSerializer.Serialize(accounts);
                            File.WriteAllText(jsonPath, updatedJson);
                        }
                    }
                }

                button1.Enabled = true;

            }
            else if (gameType == "com vs com")
            {
                button2.Visible = false;
                AutoPlayComVsCom();
            }
        }

        /// <summary>
        /// 玩家2擲骰按鈕點擊事件
        /// </summary>
        private async void button2_Click(object sender, EventArgs e)
        {
            if (gameType == "2p")
            {
                // 顯示擲骰動畫
                pictureBox2.Image = Properties.Resource.roll_dice;
                label2.Text = $"{player2.Name} 擲骰中...";

                await Task.Delay(1000);

                gameLogic.RollPlayer2(); // 只擲 Player2 並更新分數
                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                pictureBox2.Image = GetDiceImage(gameLogic.Player2Roll);

                // 顯示勝負與分數
                label3.Text = "勝負: " + gameLogic.GetWinnerText();
                label4.Text = gameLogic.GetScoreText();
                label4.Visible = true;

                // 下一輪可以再給 Player1 按
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if (gameType == "com vs com")
            {
                ResetGame(); // 重置遊戲狀態
            }
        }

        /// <summary>
        /// 電腦對戰自動模式
        /// </summary>
        private async void AutoPlayComVsCom()
        {
            gameLogic.Start(); // 重置勝場
            button1.Enabled = false;
            button2.Enabled = false;
            label4.Visible = true; // 顯示比分
            while (!gameLogic.IsGameOver())
            {
                await Task.Delay(1000); // 模擬電腦等待 1 秒再擲骰
                pictureBox1.Image = Properties.Resource.roll_dice;
                pictureBox2.Image = Properties.Resource.roll_dice;
                await Task.Delay(1000);
                var result = gameLogic.PlayRound();

                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                pictureBox1.Image = GetDiceImage(gameLogic.Player1Roll);
                pictureBox2.Image = GetDiceImage(gameLogic.Player2Roll);
                label3.Text = gameLogic.GetWinnerText();
                label4.Text = gameLogic.GetScoreText(); // 顯示比分
            }

            string finalWinner = gameLogic.Player1Wins == 3 ? player1.Name : player2.Name;
            MessageBox.Show($"{finalWinner} 搶三勝出！", "比賽結束");

            button2.Enabled = true; // 啟用重新開始按鈕
            button2.Text = "重新開始";
            button2.Visible = true; // 顯示重新開始按鈕
        }

        /// <summary>
        /// 重置遊戲狀態
        /// </summary>
        private void ResetGame()
        {
            // 重置 GameLogic 狀態
            gameLogic.Start();  // 假設 Start() 是重置勝場

            // 重設 UI
            label4.Text = "";
            label4.Visible = false;

            // 啟用按鈕
            button1.Enabled = true;
            button2.Enabled = false;

            // 恢復按鈕文字
            if (gameType == "2p")
            {
                button1.Text = "Player 1 Roll";
                button2.Text = "Player 2 Roll";
                button2.Visible = true;
            }
            else if (gameType == "com")
            {
                button1.Text = "Roll Dice";
                button2.Visible = false;
            }
            else if (gameType == "com vs com")
            {
                button1.Text = "Auto Play";
            }
        }

        /// <summary>
        /// 返回按鈕點擊事件
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            parentForm.UpdateUserInfo();
            parentForm.Show();
            this.Close();
        }

        /// <summary>
        /// 取得骰子圖片
        /// </summary>
        private Image GetDiceImage(int roll)
        {
            switch (roll)
            {
                case 1: return Properties.Resource.dice_six_faces_one;
                case 2: return Properties.Resource.dice_six_faces_two;
                case 3: return Properties.Resource.dice_six_faces_three;
                case 4: return Properties.Resource.dice_six_faces_four;
                case 5: return Properties.Resource.dice_six_faces_five;
                case 6: return Properties.Resource.dice_six_faces_six;
                default: return null;
            }
        }

        /// <summary>
        /// 存檔選單點擊事件
        /// </summary>
        private void 存檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "dice.txt";
                string scoreText = gameLogic.GetScoreText(); // 假設是 "Player1: 2, Player2: 1"
                File.WriteAllText(path, scoreText);
                MessageBox.Show("存檔成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"存檔失敗：{ex.Message}");
            }
        }

        /// <summary>
        /// 載入選單點擊事件
        /// </summary>
        private void 載入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "dice.txt";
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    label4.Text = content;
                    label4.Visible = true;
                    MessageBox.Show("載入成功！");
                }
                else
                {
                    MessageBox.Show("找不到 dice.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入失敗：{ex.Message}");
            }
        }
    }
}

