namespace ProiectPAOO
{
    partial class EditUsers
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
            button3 = new Button();
            button2 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(667, 416);
            button3.Name = "button3";
            button3.Size = new Size(121, 29);
            button3.TabIndex = 46;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(525, 416);
            button2.Name = "button2";
            button2.Size = new Size(121, 29);
            button2.TabIndex = 45;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(209, 219);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(214, 27);
            textBox5.TabIndex = 43;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(209, 181);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(214, 27);
            textBox4.TabIndex = 42;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(209, 141);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(214, 27);
            textBox3.TabIndex = 41;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(209, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 27);
            textBox2.TabIndex = 40;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(209, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 27);
            textBox1.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(71, 222);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 38;
            label6.Text = "Phone number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 184);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 37;
            label5.Text = "Full name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 144);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 36;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 107);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 35;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 68);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 34;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.Font = new Font("Comic Sans MS", 15F);
            label1.Location = new Point(0, 5);
            label1.Name = "label1";
            label1.Size = new Size(801, 36);
            label1.TabIndex = 33;
            label1.Text = "Edit User Info";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(209, 261);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(214, 27);
            textBox7.TabIndex = 49;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(71, 302);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 48;
            label7.Text = "Role";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(71, 264);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 47;
            label8.Text = "Address";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "user", "admin" });
            comboBox1.Location = new Point(209, 299);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(214, 28);
            comboBox1.TabIndex = 50;
            // 
            // EditUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditUsers";
            Text = "EditUsers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox7;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
    }
}