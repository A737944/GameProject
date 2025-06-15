using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Reflection.Emit;

namespace GameProject
{
    public partial class RankList : Form
    {
        private Form1 parentForm;
        public RankList(Form1 parent = null)
        {
            InitializeComponent();
            parentForm = parent;
            LoadRankList();
            label1.Parent = pictureBox1;
        }

        public void LoadRankList()
        {
            string jsonPath = "accounts.json";
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("找不到 accounts.json");
                return;
            }

            string json = File.ReadAllText(jsonPath);
            var accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(json);
            if (accounts == null) return;

            // 依勝場數排序（由大到小）
            var sortedAccounts = accounts.OrderByDescending(a => a.WinCount).ToList();

            listView1.Items.Clear();
            int rank = 1;
            foreach (var acc in sortedAccounts)
            {
                var item = new ListViewItem(rank.ToString());
                item.SubItems.Add(acc.Username);
                item.SubItems.Add(acc.WinCount.ToString());
                listView1.Items.Add(item);
                rank++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Show();
            }
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
