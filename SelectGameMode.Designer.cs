namespace GameProject
{
    partial class SelectGameMode
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Location = new Point(12, 33);
            button1.Name = "button1";
            button1.Size = new Size(130, 70);
            button1.TabIndex = 0;
            button1.Text = " 1P vs 2P";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseMove += button1_MouseMove;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGray;
            button2.Location = new Point(166, 33);
            button2.Name = "button2";
            button2.Size = new Size(130, 70);
            button2.TabIndex = 1;
            button2.Text = "1P vs com";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button2_MouseLeave;
            button2.MouseMove += button2_MouseMove;
            // 
            // button3
            // 
            button3.Location = new Point(15, 139);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "上一頁";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightGray;
            button4.Location = new Point(328, 33);
            button4.Name = "button4";
            button4.Size = new Size(130, 70);
            button4.TabIndex = 3;
            button4.Text = "com vs com";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            button4.MouseLeave += button4_MouseLeave;
            button4.MouseMove += button4_MouseMove;
            // 
            // SelectGameMode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 174);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "SelectGameMode";
            Text = "選擇模式";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}