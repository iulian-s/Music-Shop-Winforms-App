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

namespace ProiectPAOO
{
    public partial class AddEditStringed : Form
    {
        public AddEditStringed()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        private int instrumentId = 0;
        internal void EditInstrument(Instruments instr, StringedInstruments stringed)
        {
            this.Text = "Edit Instrument";
            label1.Text = "Edit Stringed Instrument";
            textBox1.Text = instr.Name;
            textBox2.Text = instr.Brand;
            textBox3.Text = instr.Color;
            textBox4.Text = instr.Price.ToString();
            textBox5.Text = instr.Stock.ToString();
            textBox7.Text = instr.ImagePath;
            this.instrumentId = instr.Id;
            numericUpDown1.Value = stringed.NumberOfStrings;
            textBox11.Text = stringed.Type;
            numericUpDown2.Value = stringed.Scale;
            numericUpDown3.Value = stringed.Frets;
            textBox8.Text = stringed.Wood;
        }
        private void button2_Click(object sender, EventArgs e) //Save Method
        {
            Instruments instrument = new Instruments
            {
                Id = instrumentId,
                Name = textBox1.Text,
                Brand = textBox2.Text,
                Color = textBox3.Text,
                Price = Convert.ToDecimal(textBox4.Text),
                Stock = Convert.ToInt32(textBox5.Text),
                Category = "Stringed",
                ImagePath = textBox7.Text
            };
            StringedInstruments stringed = new StringedInstruments
            {
                NumberOfStrings = (int)numericUpDown1.Value,
                Type = textBox11.Text,
                Scale = (int)numericUpDown2.Value,
                Frets = (int)numericUpDown3.Value,
                Wood = textBox8.Text
            };
            var repo = new InstrumentRepository();
            if(instrumentId == 0 )
            {
                repo.AddStringedInstrument(instrument, stringed);
            }
            else
            {
                repo.UpdateStringedInstrument(instrument, stringed);
            }

                this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e) //Cancel Method
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e) //Chose pic for instrument
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string imagesPath = Path.Combine(Application.StartupPath, "Images");
                ofd.InitialDirectory = imagesPath;
                ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                ofd.Title = "Select an Image from Images Folder";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = ofd.FileName;
                    string relativePath = Path.GetRelativePath(Application.StartupPath, selectedImagePath);
                    textBox7.Text = relativePath;
                }
            }
        }
    }
}
