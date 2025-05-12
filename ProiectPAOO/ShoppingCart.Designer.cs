namespace ProiectPAOO
{
    partial class ShoppingCart
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
            label13 = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            imageList1 = new ImageList(components);
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label13
            // 
            label13.BackColor = SystemColors.ControlLightLight;
            label13.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(40, 29);
            label13.Name = "label13";
            label13.Size = new Size(405, 35);
            label13.TabIndex = 3;
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader4, columnHeader5 });
            listView1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.Location = new Point(40, 67);
            listView1.Name = "listView1";
            listView1.Size = new Size(405, 244);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Price";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Quantity";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 100;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(451, 31);
            label1.Name = "label1";
            label1.Size = new Size(151, 35);
            label1.TabIndex = 4;
            label1.Text = "Quantity modifiers";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLightLight;
            button1.Image = Properties.Resources.add;
            button1.Location = new Point(475, 85);
            button1.Name = "button1";
            button1.Size = new Size(41, 29);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLightLight;
            button2.Image = Properties.Resources.minus1;
            button2.Location = new Point(522, 85);
            button2.Name = "button2";
            button2.Size = new Size(41, 29);
            button2.TabIndex = 6;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 401);
            label2.Name = "label2";
            label2.Size = new Size(225, 18);
            label2.TabIndex = 7;
            label2.Text = "Your current shipping adress:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(261, 397);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(377, 31);
            textBox1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(244, 329);
            label3.Name = "label3";
            label3.Size = new Size(51, 18);
            label3.TabIndex = 9;
            label3.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(295, 329);
            label4.Name = "label4";
            label4.Size = new Size(0, 18);
            label4.TabIndex = 10;
            // 
            // button3
            // 
            button3.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(659, 454);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 11;
            button3.Text = "Send order";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(793, 454);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ShoppingCart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 495);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label13);
            Controls.Add(listView1);
            Name = "ShoppingCart";
            Text = "ShoppingCart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label13;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Label label1;
        private Button button1;
        private Button button2;
        private ImageList imageList1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Button button3;
        private Button button4;
    }
}