using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GameProject.GameFramework;

namespace GameProject
{
    public partial class DiceGame : Form
    {
        private SelectGameMode parentModeFrom; 
        private string gameMode;
        private string gameType;
        private GameFramework.DiceGameLogic gameLogic;
        private GameFramework.Player player1;
        private GameFramework.Player player2;
        private Random random = new Random();

        private int? player1Roll = null;
        private int? player2Roll = null;

        public DiceGame(string mode, SelectGameMode parent)
        {

            InitializeComponent();
            gameType = mode;
            parentModeFrom = parent;

            this.Text = $"骰子遊戲-{gameType}";

            if (gameType == "2p")
            {
                player1 = new GameFramework.Player("Player 1");
                player2 = new GameFramework.Player("Player 2");

                button1.Text = "Player 1 Roll";
                button2.Text = "Player 2 Roll";
                button2.Visible = true;
                button2.Enabled = false;
            }
            else if (gameType == "com")
            {
                player1 = new GameFramework.Player("You");
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameType == "2p")
            {
                // 清除顯示，等待 Player 2 擲骰
                label1.Text = "等待玩家2擲骰";
                label2.Text = "";
                label3.Text = "";

                button1.Enabled = false;
                button2.Enabled = true;
            }
            else if (gameType == "com")
            {
                var result = gameLogic.PlayRound();

                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                label3.Text = gameLogic.GetWinnerText();
            }
            else if (gameType == "com vs com")
            {
                button2.Visible = false;
                AutoPlayComVsCom();

                // 啟用重新開始按鈕
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gameType == "2p")
            {
                var result = gameLogic.PlayRound();

                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                label3.Text = gameLogic.GetWinnerText();

                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if (gameType == "com vs com")
            {
                ResetGame(); // 重置遊戲狀態
            }

        }

        private async void AutoPlayComVsCom()
        {
            gameLogic.Start(); // 重置勝場
            button1.Enabled = false;
            button2.Enabled = false;
            label4.Visible = true; // 顯示比分
            while (!gameLogic.IsGameOver())
            {
                await Task.Delay(1000); // 模擬電腦等待 1 秒再擲骰

                var result = gameLogic.PlayRound();

                label1.Text = $"{player1.Name} 丟出 {gameLogic.Player1Roll}";
                label2.Text = $"{player2.Name} 丟出 {gameLogic.Player2Roll}";
                label3.Text = gameLogic.GetWinnerText();
                label4.Text = gameLogic.GetScoreText(); // 顯示比分
            }

            string finalWinner = gameLogic.Player1Wins == 3 ? player1.Name : player2.Name;
            MessageBox.Show($"{finalWinner} 搶三勝出！", "比賽結束");

            button2.Enabled = true; // 啟用重新開始按鈕
            button2.Text = "重新開始";
            button2.Visible = true; // 顯示重新開始按鈕
        }
        private void ResetGame()
        {
            // 重置 GameLogic 狀態
            gameLogic.Start();  // 假設 Start() 是重置勝場

            // 重設 UI
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
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
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // 關閉當前遊戲視窗
            if (parentModeFrom != null)
            {
                parentModeFrom.Show(); // 如果有父窗體，則顯示它
            }
        }
    }
}
