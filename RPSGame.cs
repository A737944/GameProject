using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        public RPSGame(string mode, SelectGameMode parent)
        {
            InitializeComponent();
            gameMode = mode;
            parentModeFrom = parent;
            this.Text = $"剪刀 石頭 布 - {gameMode}";
            if (gameMode == "2p")
            {
                player1 = new GameFramework.Player("Player 1");
                player2 = new GameFramework.Player("Player 2");
                
            }
            else if (gameMode == "com")
            {
                player1 = new GameFramework.Player("You");
                player2 = new GameFramework.Player("Computer");
               
            }
            else if (gameMode == "com vs com")
            {
                player1 = new GameFramework.Player("Computer 1");
                player2 = new GameFramework.Player("Computer 2");
                player2 = new GameFramework.Player("Computer 2");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉當前遊戲視窗
            if (parentModeFrom != null)
            {
                parentModeFrom.Show(); // 如果有父窗體，則顯示它
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
