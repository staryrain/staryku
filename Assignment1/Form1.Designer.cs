namespace project1
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(78, 307);
            button1.Name = "button1";
            button1.Size = new Size(132, 44);
            button1.TabIndex = 0;
            button1.Text = "开始运算";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(239, 207);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 30);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(558, 207);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(59, 30);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(759, 208);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(193, 30);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(435, 405);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(309, 30);
            textBox4.TabIndex = 4;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(87, 470);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "重置";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 147);
            label1.Name = "label1";
            label1.Size = new Size(57, 24);
            label1.TabIndex = 6;
            label1.Text = "数字1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(838, 145);
            label2.Name = "label2";
            label2.Size = new Size(57, 24);
            label2.TabIndex = 7;
            label2.Text = "数字2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(554, 343);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 8;
            label3.Text = "运算结果";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 42);
            label4.Name = "label4";
            label4.Size = new Size(298, 24);
            label4.TabIndex = 9;
            label4.Text = "简易计算器（可进行加减乘除计算）";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(558, 145);
            label5.Name = "运算符";
            label5.Size = new Size(63, 24);
            label5.TabIndex = 10;
            label5.Text = "label5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 637);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}