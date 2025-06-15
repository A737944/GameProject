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
    public partial class SelectGameMode : Form
    {

        public string SelectedMode { get; private set; }
        public string gameType;
        public SelectGameMode(string gameType)
        {
            InitializeComponent();
            this.gameType = gameType;
            this.Text = $"Select Game Mode-{gameType}";


        }


        private void button1_Click(object sender, EventArgs e)
        {
            SelectedMode = "2p";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectedMode = "com";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectedMode = "com vs com";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // 如果不選擇任何模式，則返回 Cancel
            this.Close(); // 關閉對話框
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.IndianRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.IndianRed;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGray;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.IndianRed;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightGray;
        }
    }
}
