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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static GameProject.GameFramework;
using GameProject.Properties;

namespace GameProject
{
    public partial class RPSGame : Form
    {
        private SelectGameMode parentModeFrom;
        private string gameMode;
        private GameFramework.RPSGameLogic gameLogic;
        private GameFramework.Player player1;
        private GameFramework.Player player2;
        private Random random = new Random();
        private Form1 parentForm;
        private RPSMove? tempP1Move = null;
        private int p1Wins = 0, p2Wins = 0;



        public RPSGame(string mode, Form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
            gameMode = mode;

            this.Text = $"剪刀 石頭 布 - {gameMode}";
            if (gameMode == "2p")
            {
                player1 = new GameFramework.Player("Player 1");
                player2 = new GameFramework.Player("Player 2");
                gameLogic = new GameFramework.RPSGameLogic(player1, player2);
                label4.Visible = false; // 隱藏比分顯示

            }
            else if (gameMode == "com")
            {
                player1 = new GameFramework.Player("You");
                player2 = new GameFramework.Player("Computer");
                gameLogic = new GameFramework.RPSGameLogic(player1, player2);
                label4.Visible = false;

            }
            else if (gameMode == "com vs com")
            {
                player1 = new GameFramework.Player("Computer 1");
                player2 = new GameFramework.Player("Computer 2");
                gameLogic = new GameFramework.RPSGameLogic(player1, player2);
                button1.Text = "Auto Play";
                button2.Visible = false;
                button3.Visible = false;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            HandleClick(RPSMove.Scissors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleClick(RPSMove.Rock);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleClick(RPSMove.Paper);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private async void HandleClick(RPSMove move)
        {
            if (gameMode == "2p")
            {
                if (tempP1Move == null)
                {
                    tempP1Move = move;
                    label1.Text = $"Player 1 選擇了 {move}";
                    pictureBox1.Image = GetMoveImage(move);
                }
                else
                {
                    gameLogic.SetMoves(tempP1Move.Value, move);
                    GameResult result = gameLogic.PlayRound();
                    label2.Text = $"Player 2 選擇了 {move}。";
                    UpdateResult(gameLogic.GetResultText(), result);
                    tempP1Move = null; // 重置 Player 1 的選擇
                    pictureBox2.Image = GetMoveImage(move);
                    label4.Text = gameLogic.GetScoreText();
                    label4.Visible = true;
                }

            }
            else if (gameMode == "com")
            {
                pictureBox1.Image = GetMoveImage(move);
                RPSMove comMove = (RPSMove)random.Next(0, 3); // 隨機選擇剪刀、石頭或布
                gameLogic.SetMoves(move, comMove);
                GameResult result = gameLogic.PlayRound();
                label1.Text = $"你選擇了 {move}";
                label2.Text = $"電腦選擇了 {comMove}。";
                UpdateResult(gameLogic.GetResultText(), result);
                pictureBox2.Image = GetMoveImage(comMove);
                label4.Text = gameLogic.GetScoreText();
                label4.Visible = true;
            }
            else if (gameMode == "com vs com")
            {
                AutoPlayComVsCom();
            }
        }

        private void UpdateResult(string resultText, GameResult result)
        {

            if (result == GameResult.Win)
            {

                label3.Text = $"{player1.Name} Wins";
            }
            else if (result == GameResult.Lose)
            {

                label3.Text = $"{player2.Name} Wins";
            }
            else
            {
                label3.Text = "平局";
            }
        }
        private async void AutoPlayComVsCom()
        {
            gameLogic.Start(); // 重置勝場（確保你在 RPSGameLogic 有這個方法）

            button1.Enabled = false;
            button2.Enabled = false;

            while (!gameLogic.IsGameOver())
            {
                await Task.Delay(1000); // 模擬電腦出拳延遲

                RPSMove com1Move = (RPSMove)random.Next(0, 3);
                RPSMove com2Move = (RPSMove)random.Next(0, 3);
                gameLogic.SetMoves(com1Move, com2Move);

                GameResult result = gameLogic.PlayRound();

                label1.Text = $"電腦1選擇了 {com1Move}";
                label2.Text = $"電腦2選擇了 {com2Move}";
                pictureBox1.Image = GetMoveImage(com1Move);
                pictureBox2.Image = GetMoveImage(com2Move);
                UpdateResult(gameLogic.GetResultText(), result);
                label4.Text = gameLogic.GetScoreText(); // 顯示比分
            }

            // 比賽結束後彈出勝方
            string finalWinner = gameLogic.Player1Wins == 3 ? player1.Name : player2.Name;
            MessageBox.Show($"{finalWinner} 搶三勝出！", "比賽結束");

            button2.Text = "重新開始";
            button2.Visible = true;
            button2.Enabled = true;
        }

        private Image GetMoveImage(RPSMove move)
        {
            switch (move)
            {
                case RPSMove.Rock:
                    return Properties.Resource.rock;
                case RPSMove.Paper:
                    return Properties.Resource.paper;
                case RPSMove.Scissors:
                    return Properties.Resource.scissors;
                default:
                    return null;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void 存檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "rps.txt";
                string scoreText = gameLogic.GetScoreText(); // 假設是剪刀石頭布勝場統計
                File.WriteAllText(path, scoreText);
                MessageBox.Show("RPS 存檔成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"存檔失敗：{ex.Message}");
            }
        }

        private void 載入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "rps.txt";
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    label4.Text = content;
                    label4.Visible = true;
                    MessageBox.Show("RPS 載入成功！");
                }
                else
                {
                    MessageBox.Show("找不到 rps.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入失敗：{ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


}
