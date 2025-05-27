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
        private Form1 from1;
        public string GameType { get; private set; }
        public SelectGameMode()
        {
            InitializeComponent();
           
        }

        public void Setparent(Form1 parent)
        {
            from1 = parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GameType = "2p";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameType = "com";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameType = "com vs com";    
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            if (from1 != null)
            {
                from1.Show(); // 如果有父窗體，則顯示它
            }
        }
    }
}
