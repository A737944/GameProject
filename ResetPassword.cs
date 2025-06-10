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
    /// <summary>
    /// 重設密碼表單類別
    /// </summary>
    public partial class ResetPassword : Form
    {
        /// <summary>
        /// 登入表單參考
        /// </summary>
        private Login loginForm;

        /// <summary>
        /// 重設密碼表單建構函式
        /// </summary>
        public ResetPassword(Login loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            // 設定密碼輸入框顯示為黑色圈圈
            textBox2.PasswordChar = '●';
            textBox3.PasswordChar = '●';
        }

        /// <summary>
        /// 重設密碼按鈕點擊事件
        /// </summary>
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
        }

        /// <summary>
        /// 取消按鈕點擊事件
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉重設密碼視窗
            loginForm.Show(); // 返回登入視窗
        }
    }
}
