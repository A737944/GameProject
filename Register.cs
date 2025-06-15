using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class Register : Form
    {
        private Login loginForm;
        public Register(Login loginForm)
        {
            InitializeComponent();
            textBox2.PasswordChar = '●';
            textBox3.PasswordChar = '●';
            this.loginForm = loginForm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();

           if(string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("請輸入帳號密碼");
                return;
            }
           if(password != confirmPassword)
            {
                MessageBox.Show("密碼不一致，請重新輸入。");
                return;
            }
            // 檢查帳號是否已存在
           if(loginForm.UsernameExists(username))
            {
                MessageBox.Show("帳號已存在，請使用其他帳號。");
                return;
            }
            // 創建新帳號並儲存
            Account newAccount = new Account { Username = username, Password = password , WinCount = 0};
            loginForm.AddAccount(newAccount);
            MessageBox.Show("註冊成功！");
            this.Close(); // 關閉註冊視窗
            loginForm.Show(); // 顯示登入視窗
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            this.Close(); // 關閉註冊視窗
            loginForm.Show(); // 顯示登入視窗
        }
    }
}
