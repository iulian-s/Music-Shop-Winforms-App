namespace ProiectPAOO
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            toolStripSplitButton1 = new ToolStripSplitButton();
            stringedInstrumentToolStripMenuItem = new ToolStripMenuItem();
            keyboardToolStripMenuItem = new ToolStripMenuItem();
            blowingInstrumentToolStripMenuItem = new ToolStripMenuItem();
            drumsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton3 = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton4 = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripTextBox1 = new ToolStripTextBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1251, 772);
            splitContainer1.SplitterDistance = 734;
            splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSplitButton1, toolStripSeparator1, toolStripButton1, toolStripSeparator2, toolStripButton2, toolStripSeparator3, toolStripButton3, toolStripSeparator4, toolStripButton4, toolStripSeparator5, toolStripLabel1, toolStripTextBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(734, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { stringedInstrumentToolStripMenuItem, keyboardToolStripMenuItem, blowingInstrumentToolStripMenuItem, drumsToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(56, 24);
            toolStripSplitButton1.Text = "Add";
            // 
            // stringedInstrumentToolStripMenuItem
            // 
            stringedInstrumentToolStripMenuItem.Name = "stringedInstrumentToolStripMenuItem";
            stringedInstrumentToolStripMenuItem.Size = new Size(222, 26);
            stringedInstrumentToolStripMenuItem.Text = "Stringed Instrument";
            stringedInstrumentToolStripMenuItem.Click += stringedInstrumentToolStripMenuItem_Click;
            // 
            // keyboardToolStripMenuItem
            // 
            keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            keyboardToolStripMenuItem.Size = new Size(222, 26);
            keyboardToolStripMenuItem.Text = "Keyboard";
            keyboardToolStripMenuItem.Click += keyboardToolStripMenuItem_Click;
            // 
            // blowingInstrumentToolStripMenuItem
            // 
            blowingInstrumentToolStripMenuItem.Name = "blowingInstrumentToolStripMenuItem";
            blowingInstrumentToolStripMenuItem.Size = new Size(222, 26);
            blowingInstrumentToolStripMenuItem.Text = "Blowing Instrument";
            blowingInstrumentToolStripMenuItem.Click += blowingInstrumentToolStripMenuItem_Click;
            // 
            // drumsToolStripMenuItem
            // 
            drumsToolStripMenuItem.Name = "drumsToolStripMenuItem";
            drumsToolStripMenuItem.Size = new Size(222, 26);
            drumsToolStripMenuItem.Text = "Drums";
            drumsToolStripMenuItem.Click += drumsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(39, 24);
            toolStripButton1.Text = "Edit";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(57, 24);
            toolStripButton2.Text = "Delete";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(80, 24);
            toolStripButton3.Text = "View Logs";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 27);
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(48, 24);
            toolStripButton4.Text = "Users";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 27);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(60, 24);
            toolStripLabel1.Text = "Search: ";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.BackColor = SystemColors.ActiveBorder;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView1.Location = new Point(3, 30);
            listView1.Name = "listView1";
            listView1.Size = new Size(731, 739);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Brand";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Color";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Price";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Stock";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Category";
            columnHeader6.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 9);
            label1.Name = "label1";
            label1.Size = new Size(239, 34);
            label1.TabIndex = 1;
            label1.Text = "Instrument Details";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(3, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 739);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(139, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(269, 132);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI", 12F);
            richTextBox1.Location = new Point(47, 205);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(424, 406);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Drums.png");
            imageList1.Images.SetKeyName(1, "Guitar.png");
            imageList1.Images.SetKeyName(2, "Piano.png");
            imageList1.Images.SetKeyName(3, "Sax.png");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1251, 772);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Admin App";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListView listView1;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem stringedInstrumentToolStripMenuItem;
        private ToolStripMenuItem keyboardToolStripMenuItem;
        private ToolStripMenuItem blowingInstrumentToolStripMenuItem;
        private ToolStripMenuItem drumsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ImageList imageList1;
        private Label label1;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton toolStripButton3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator5;
    }
}
