namespace GameProject
{
    partial class RankList
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            button1 = new Button();
<<<<<<< HEAD
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
=======
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
<<<<<<< HEAD
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft JhengHei UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(132, 24);
=======
            label1.Font = new Font("Microsoft JhengHei UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(127, 9);
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            label1.Name = "label1";
            label1.Size = new Size(131, 47);
            label1.TabIndex = 0;
            label1.Text = "排行榜";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
<<<<<<< HEAD
            listView1.Location = new Point(2, 85);
=======
            listView1.Location = new Point(2, 59);
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            listView1.Name = "listView1";
            listView1.Size = new Size(392, 236);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "排名";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "玩家名稱";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "勝場";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 100;
            // 
            // button1
            // 
<<<<<<< HEAD
            button1.Location = new Point(2, 327);
=======
            button1.Location = new Point(2, 301);
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            button1.Name = "button1";
            button1.Size = new Size(136, 43);
            button1.TabIndex = 2;
            button1.Text = "上一頁";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
<<<<<<< HEAD
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resource.龍;
            pictureBox1.Location = new Point(2, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
=======
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            // RankList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            ClientSize = new Size(394, 382);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "RankList";
            Text = "RankList";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
=======
            ClientSize = new Size(406, 356);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "RankList";
            Text = "RankList";
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button button1;
<<<<<<< HEAD
        private PictureBox pictureBox1;
=======
>>>>>>> c4835412c89aba569ccdec3750af1fe2694a8485
    }
}