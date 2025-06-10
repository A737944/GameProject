using GameProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    /// <summary>
    /// 遊戲模式選擇表單類別
    /// </summary>
    public partial class SelectGameMode : Form
    {
        /// <summary>
        /// 選擇的遊戲模式
        /// </summary>
        public string SelectedMode { get; private set; }

        /// <summary>
        /// 遊戲類型
        /// </summary>
        public string gameType;

        /// <summary>
        /// 遊戲模式選擇表單建構函式
        /// </summary>
        public SelectGameMode(string gameType)
        {
            InitializeComponent();
            this.gameType = gameType;
            this.Text = $"Select Game Mode-{gameType}";
        }

        /// <summary>
        /// 雙人模式按鈕點擊事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            SelectedMode = "2p";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 電腦模式按鈕點擊事件
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            SelectedMode = "com";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 電腦對戰模式按鈕點擊事件
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            SelectedMode = "com vs com";    
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 取消按鈕點擊事件
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        { 
           this.DialogResult = DialogResult.Cancel; // 如果不選擇任何模式，則返回 Cancel
           this.Close(); // 關閉對話框
        }
    }
}
