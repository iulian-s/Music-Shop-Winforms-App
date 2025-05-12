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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProiectPAOO
{
    public partial class AddEditBlowing : Form
    {
        public AddEditBlowing()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        private int instrumentId = 0;
        internal void EditInstrument(Instruments instr, BlowingInstruments blow)
        {
            this.Text = "Edit Instrument";
            label1.Text = "Edit Blowing Instrument";
            textBox1.Text = instr.Name;
            textBox2.Text = instr.Brand;
            textBox3.Text = instr.Color;
            textBox4.Text = instr.Price.ToString();
            textBox5.Text = instr.Stock.ToString();
            textBox7.Text = instr.ImagePath;
            this.instrumentId = instr.Id;

            textBox6.Text = blow.Material;
            textBox11.Text = blow.KeyType;
            textBox8.Text = blow.Tuning;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)//Save
        {
            Instruments instrument = new Instruments
            {
                Id = instrumentId,
                Name = textBox1.Text,
                Brand = textBox2.Text,
                Color = textBox3.Text,
                Price = Convert.ToDecimal(textBox4.Text),
                Stock = Convert.ToInt32(textBox5.Text),
                Category = "Blowing",
                ImagePath = textBox7.Text
            };
            BlowingInstruments blow = new BlowingInstruments
            {
                Material = textBox6.Text,
                KeyType = textBox11.Text,
                Tuning = textBox8.Text
            };
            var repo = new InstrumentRepository();
            if (instrumentId == 0)
            {
                repo.AddBlowingInstrument(instrument, blow);
            }
            else
            {
                repo.UpdateBlowingInstrument(instrument, blow);
            }

            this.DialogResult = DialogResult.OK;
        
        }

        private void button3_Click(object sender, EventArgs e)//Cancel
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
