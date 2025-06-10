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
    /// <summary>
    /// 登入表單類別
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// 帳戶列表
        /// </summary>
        private List<Account> accounts = new List<Account>();
        
        /// <summary>
        /// 帳戶資料檔案路徑
        /// </summary>
        private const string jsonPath = "accounts.json";

        /// <summary>
        /// 登入表單建構函式
        /// </summary>
        public Login()
        {
            InitializeComponent();
            LoadAccounts();
            // 設定密碼輸入框顯示為黑色圈圈
            textBox2.PasswordChar = '●';
        }

        /// <summary>
        /// 載入帳戶資料
        /// </summary>
        public void LoadAccounts()
        {
            accounts.Clear();
            if(File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                var loadAccounts = JsonSerializer.Deserialize<List<Account>>(json);
                if (loadAccounts != null)
                {
                    accounts = loadAccounts;
                }
            }
        }

        /// <summary>
        /// 儲存帳戶資料
        /// </summary>
        public void SaveAccounts()
        {
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(jsonPath, json);
        }

        /// <summary>
        /// 註冊按鈕點擊事件
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register(this);
            registerForm.Show();
        }

        /// <summary>
        /// 登入按鈕點擊事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            var account = accounts.Find(a => a.Username == username);
            if(account == null)
            {
                MessageBox.Show("帳號不存在，請檢查後重新輸入。");   
            }
            else if(account.Password != password)
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

        /// <summary>
        /// 重設密碼按鈕點擊事件
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword resetPasswordForm = new ResetPassword(this);
            resetPasswordForm.Show();
        }

        /// <summary>
        /// 取得指定使用者名稱的帳戶
        /// </summary>
        public Account GetAccount(string username) 
        {
            return accounts.Find(a => a.Username == username);
        }

        /// <summary>
        /// 檢查使用者名稱是否存在
        /// </summary>
        public bool UsernameExists(string username)
        {
            return accounts.Exists(a => a.Username == username);
        }

        /// <summary>
        /// 新增帳戶
        /// </summary>
        public void AddAccount(Account newAccount)
        {
            accounts.Add(newAccount);
            SaveAccounts();
        }

        /// <summary>
        /// 更新密碼
        /// </summary>
        public void UpdatePassword(string username, string newPassword)
        {
            var account = GetAccount(username);
            if (account != null)
            {
                account.Password = newPassword;
                SaveAccounts();
            }
        }

        /// <summary>
        /// 檢查帳戶是否存在
        /// </summary>
        public bool AccountExists(string username)
        {
            return accounts.Any(a => a.Username == username);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
