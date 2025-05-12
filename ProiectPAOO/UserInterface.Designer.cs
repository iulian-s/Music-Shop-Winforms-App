namespace ProiectPAOO
{
    partial class UserInterface
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            shoppingCartToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            label13 = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            pictureBox2 = new PictureBox();
            label14 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label8 = new Label();
            button1 = new Button();
            label9 = new Label();
            textBox1 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            checkBox1 = new CheckBox();
            label12 = new Label();
            textBox2 = new TextBox();
            imageList1 = new ImageList(components);
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1103, 21);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 0;
            label1.Text = "pisica";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(1077, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, ordersToolStripMenuItem, shoppingCartToolStripMenuItem, logoutToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 120);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(210, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(210, 22);
            ordersToolStripMenuItem.Text = "Orders";
            ordersToolStripMenuItem.Click += ordersToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(210, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // shoppingCartToolStripMenuItem
            // 
            shoppingCartToolStripMenuItem.Name = "shoppingCartToolStripMenuItem";
            shoppingCartToolStripMenuItem.Size = new Size(210, 22);
            shoppingCartToolStripMenuItem.Text = "Shopping Cart";
            shoppingCartToolStripMenuItem.Click += shoppingCartToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(155, 47);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label13);
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(label14);
            splitContainer1.Size = new Size(1067, 617);
            splitContainer1.SplitterDistance = 596;
            splitContainer1.TabIndex = 2;
            // 
            // label13
            // 
            label13.BackColor = SystemColors.ControlLightLight;
            label13.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(3, 0);
            label13.Name = "label13";
            label13.Size = new Size(590, 40);
            label13.TabIndex = 1;
            label13.Text = "List of instruments";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.Location = new Point(3, 38);
            listView1.Name = "listView1";
            listView1.Size = new Size(589, 579);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Brand";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Color";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Price";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 100;
            // 
            // button2
            // 
            button2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(139, 456);
            button2.Name = "button2";
            button2.Size = new Size(135, 47);
            button2.TabIndex = 5;
            button2.Text = "Add to Cart";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(66, 273);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(268, 148);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(89, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(225, 177);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label14
            // 
            label14.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(38, 0);
            label14.Name = "label14";
            label14.Size = new Size(329, 40);
            label14.TabIndex = 2;
            label14.Text = "Instrument details";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All", "Stringed", "Keyboard", "Blowing", "Drums" });
            comboBox1.Location = new Point(258, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 26);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(173, 15);
            label2.Name = "label2";
            label2.Size = new Size(76, 18);
            label2.TabIndex = 4;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(432, 15);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 6;
            label3.Text = "Sort";
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Ascending (A-Z)", "Descending (A-Z)", "Price low to high", "Price high to low" });
            comboBox2.Location = new Point(474, 12);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 26);
            comboBox2.TabIndex = 5;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(51, 19);
            label4.Name = "label4";
            label4.Size = new Size(52, 18);
            label4.TabIndex = 7;
            label4.Text = "Filters";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 67);
            label5.Name = "label5";
            label5.Size = new Size(44, 18);
            label5.TabIndex = 8;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(29, 246);
            label6.Name = "label6";
            label6.Size = new Size(109, 2);
            label6.TabIndex = 9;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 94);
            label7.Name = "label7";
            label7.Size = new Size(46, 18);
            label7.TabIndex = 10;
            label7.Text = "From";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(29, 115);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(103, 27);
            numericUpDown1.TabIndex = 11;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(29, 166);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(103, 27);
            numericUpDown2.TabIndex = 13;
            numericUpDown2.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 145);
            label8.Name = "label8";
            label8.Size = new Size(28, 18);
            label8.TabIndex = 12;
            label8.Text = "To";
            // 
            // button1
            // 
            button1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(37, 199);
            button1.Name = "button1";
            button1.Size = new Size(91, 29);
            button1.TabIndex = 0;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(59, 268);
            label9.Name = "label9";
            label9.Size = new Size(49, 18);
            label9.TabIndex = 14;
            label9.Text = "Color";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 289);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(103, 27);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Location = new Point(29, 345);
            label10.Name = "label10";
            label10.Size = new Size(109, 2);
            label10.TabIndex = 16;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(59, 369);
            label11.Name = "label11";
            label11.Size = new Size(49, 18);
            label11.TabIndex = 17;
            label11.Text = "Stock";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(29, 399);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(95, 22);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Available";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(671, 15);
            label12.Name = "label12";
            label12.Size = new Size(56, 18);
            label12.TabIndex = 19;
            label12.Text = "Search";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(733, 11);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 31);
            textBox2.TabIndex = 20;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // button3
            // 
            button3.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 461);
            button3.Name = "button3";
            button3.Size = new Size(137, 29);
            button3.TabIndex = 21;
            button3.Text = "Reset Filters";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1162, 665);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(label12);
            Controls.Add(checkBox1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(textBox1);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(label8);
            Controls.Add(numericUpDown1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(splitContainer1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "UserInterface";
            Text = "Music shop";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label8;
        private Button button1;
        private Label label9;
        private TextBox textBox1;
        private Label label10;
        private Label label11;
        private CheckBox checkBox1;
        private Label label12;
        private TextBox textBox2;
        private ListView listView1;
        private Label label13;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox2;
        private Label label14;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button button2;
        private ImageList imageList1;
        private ToolStripMenuItem shoppingCartToolStripMenuItem;
        private Button button3;
    }
}