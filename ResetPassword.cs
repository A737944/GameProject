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
    public partial class ResetPassword : Form
    {
        private Login loginForm;
        public ResetPassword(Login loginForm)
        {
            InitializeComponent();
            textBox2.PasswordChar = '●';
            textBox3.PasswordChar = '●';
            this.loginForm = loginForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string newPassword = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();
            if(newPassword != confirmPassword)
            {
                MessageBox.Show("密碼不一致，請重新輸入。");
                return;
            }

            var accountExists = loginForm.AccountExists(username);
            if(!accountExists)
            {
                MessageBox.Show("帳號不存在，請檢查後重新輸入。");
                return;
            }
            loginForm.UpdatePassword(username, newPassword);
            MessageBox.Show("密碼重設成功！");
            this.Close(); // 關閉重設密碼視窗
            loginForm.Show(); // 顯示登入視窗
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉重設密碼視窗
            loginForm.Show(); // 返回登入視窗
        }
    }
}
