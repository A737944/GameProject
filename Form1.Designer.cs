namespace GameProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(111, 19);
            label1.Name = "label1";
            label1.Size = new Size(123, 35);
            label1.TabIndex = 0;
            label1.Text = "歡迎回來";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Location = new Point(53, 105);
            button1.Name = "button1";
            button1.Size = new Size(161, 65);
            button1.TabIndex = 1;
            button1.Text = "骰子遊戲";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseMove += button1_MouseMove;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGray;
            button2.Location = new Point(354, 105);
            button2.Name = "button2";
            button2.Size = new Size(161, 65);
            button2.TabIndex = 2;
            button2.Text = "猜拳遊戲";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button2_MouseLeave;
            button2.MouseMove += button2_MouseMove;
            // 
            // button3
            // 
            button3.Location = new Point(53, 209);
            button3.Name = "button3";
            button3.Size = new Size(125, 44);
            button3.TabIndex = 17;
            button3.Text = "上一頁";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(354, 209);
            button4.Name = "button4";
            button4.Size = new Size(125, 44);
            button4.TabIndex = 18;
            button4.Text = "排行榜";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 265);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "遊戲選單";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
