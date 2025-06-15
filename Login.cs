using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Login : Form
    {
        private List<Account> accounts = new List<Account>();
        private const string jsonPath = "accounts.json";
        public Login()
        {
            InitializeComponent();
            LoadAccounts();
            textBox2.PasswordChar = '●';
        }

        public void LoadAccounts()
        {
            accounts.Clear();
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var loadAccounts = JsonSerializer.Deserialize<List<Account>>(json);
                if (loadAccounts != null)
                {
                    accounts = loadAccounts;
                }
            }
        }

        public void SaveAccounts()
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(jsonPath, json);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register(this);
            registerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            var account = accounts.Find(a => a.Username == username);
            if (account == null)
            {
                MessageBox.Show("帳號不存在，請檢查後重新輸入。");
            }
            else if (account.Password != password)
            {
                MessageBox.Show("密碼錯誤，請檢查後重新輸入。");
            }
            else
            {
                MessageBox.Show("登入成功！");
                this.Hide();
                Form1 form1 = new Form1(account, this);
                form1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword resetPasswordForm = new ResetPassword(this);
            resetPasswordForm.Show();
        }

        public Account GetAccount(string username)
        {
            return accounts.Find(a => a.Username == username);
        }
        public bool UsernameExists(string username)
        {
            return accounts.Exists(a => a.Username == username);
        }

        public void AddAccount(Account newAccount)
        {
            accounts.Add(newAccount);
            SaveAccounts();
        }

        public void UpdatePassword(string username, string newPassword)
        {
            var account = GetAccount(username);
            if (account != null)
            {
                account.Password = newPassword;
                SaveAccounts();
            }
        }


        public bool AccountExists(string username)
        {
            return accounts.Any(a => a.Username == username);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
