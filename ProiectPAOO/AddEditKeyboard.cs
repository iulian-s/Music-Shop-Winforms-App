using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProiectPAOO.Models;
using ProiectPAOO.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProiectPAOO
{
    public partial class AddEditKeyboard : Form
    {
        public AddEditKeyboard()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        private int instrumentId = 0;

        internal void EditInstrument(Instruments instr, KeyboardInstruments key)
        {
            this.Text = "Edit Instrument";
            label1.Text = "Edit Keyboard Instrument";
            textBox1.Text = instr.Name;
            textBox2.Text = instr.Brand;
            textBox3.Text = instr.Color;
            textBox4.Text = instr.Price.ToString();
            textBox5.Text = instr.Stock.ToString();
            textBox7.Text = instr.ImagePath;
            this.instrumentId = instr.Id;

            numericUpDown1.Value = key.KeysCount;
            checkBox1.CheckState = key.IsDigital ? CheckState.Checked : CheckState.Unchecked;
        }

        private void button1_Click(object sender, EventArgs e) //Add pic
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string imagesPath = Path.Combine(Application.StartupPath, "Images");
                ofd.InitialDirectory = imagesPath;
                ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                ofd.Title = "Select an Image from Images Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = ofd.FileName;
                    string relativePath = Path.GetRelativePath(Application.StartupPath, selectedImagePath);
                    textBox7.Text = relativePath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Save
        {
            Instruments instrument = new Instruments
            {
                Id = instrumentId,
                Name = textBox1.Text,
                Brand = textBox2.Text,
                Color = textBox3.Text,
                Price = Convert.ToDecimal(textBox4.Text),
                Stock = Convert.ToInt32(textBox5.Text),
                Category = "Keyboard",
                ImagePath = textBox7.Text
            };
            KeyboardInstruments key = new KeyboardInstruments
            {
                KeysCount = Convert.ToInt32(numericUpDown1.Value),
                IsDigital = Convert.ToBoolean(checkBox1.CheckState)
            };
            var repo = new InstrumentRepository();
            if (instrumentId == 0)
            {
                repo.AddKeyboardInstrument(instrument, key);
            }
            else
            {
                repo.UpdateKeyboardInstrument(instrument, key);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e) //Cancel
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
