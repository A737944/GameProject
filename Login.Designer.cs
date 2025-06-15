namespace GameProject
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(116, 48);
            label1.Name = "label1";
            label1.Size = new Size(229, 44);
            label1.TabIndex = 0;
            label1.Text = "遊戲登陸畫面";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 20.25F);
            label2.Location = new Point(41, 145);
            label2.Name = "label2";
            label2.Size = new Size(69, 35);
            label2.TabIndex = 1;
            label2.Text = "帳號";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 20.25F);
            label3.Location = new Point(41, 197);
            label3.Name = "label3";
            label3.Size = new Size(69, 35);
            label3.TabIndex = 2;
            label3.Text = "密碼";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft JhengHei UI", 14.25F);
            textBox2.Location = new Point(116, 197);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 35);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft JhengHei UI", 14.25F);
            textBox1.Location = new Point(116, 145);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(229, 35);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(54, 268);
            button1.Name = "button1";
            button1.Size = new Size(62, 46);
            button1.TabIndex = 6;
            button1.Text = "登陸";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(278, 268);
            button2.Name = "button2";
            button2.Size = new Size(67, 46);
            button2.TabIndex = 7;
            button2.Text = "忘記密碼";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(168, 268);
            button3.Name = "button3";
            button3.Size = new Size(62, 46);
            button3.TabIndex = 8;
            button3.Text = "註冊";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(54, 330);
            button4.Name = "button4";
            button4.Size = new Size(67, 46);
            button4.TabIndex = 9;
            button4.Text = "結束遊戲";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 378);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}