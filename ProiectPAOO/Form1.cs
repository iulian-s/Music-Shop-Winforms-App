using System;
using Microsoft.Data.SqlClient;
using ProiectPAOO.Models;
using ProiectPAOO.Repositories;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Interop;
namespace ProiectPAOO
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        public static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            imageList1.ImageSize = new Size(32, 32);
            listView1.SmallImageList = imageList1;
            LoadInstruments();
            SetPlaceholder(toolStripTextBox1.TextBox, "e.g Guitar");
            HideInfo();
        }

        private void HideInfo()
        {
            label1.Visible = false;
            richTextBox1.Visible = false;
            pictureBox1.Visible = false;
        }
        private void LoadInstruments()
        {
            listView1.Items.Clear();
            imageList1.Images.Clear();
            var repo = new InstrumentRepository();

            var instruments = repo.GetInstruments();

            foreach (var instr in instruments)
            {
                string fullImagePath = Path.Combine(Application.StartupPath, instr.ImagePath);
                if (instr.Stock > 0)
                {
                    if (!string.IsNullOrEmpty(instr.ImagePath) && File.Exists(fullImagePath))
                    {
                        if (!imageList1.Images.ContainsKey(instr.ImagePath))
                        {
                            imageList1.Images.Add(instr.ImagePath, Image.FromFile(fullImagePath));
                        }
                    }
                    var item = new ListViewItem(instr.Name);
                    item.SubItems.Add(instr.Brand);
                    item.SubItems.Add(instr.Color);
                    item.SubItems.Add(instr.Price.ToString("C"));
                    item.SubItems.Add(instr.Stock.ToString());
                    item.SubItems.Add(instr.Category);
                    item.Tag = instr.Id;
                    if (imageList1.Images.ContainsKey(instr.ImagePath))
                    {
                        item.ImageKey = instr.ImagePath;
                    }

                    listView1.Items.Add(item);
                }

                //MessageBox.Show($"Loaded image: {instr.ImagePath}, Exists: {File.Exists(fullImagePath)}");

            }
        }

        private void DisplayInstrumentInfo()
        {
            if (listView1.SelectedItems.Count == 0) return;
            richTextBox1.Visible = true;
            label1.Visible = true;
            pictureBox1.Visible = true;
            var selectedItem = listView1.SelectedItems[0];
            int id = (int)selectedItem.Tag;
            string category = selectedItem.SubItems[5].Text;
            //MessageBox.Show("id = " + id + " cat " + category);

            var repo = new InstrumentRepository();
            var instrumentDetails = repo.GetInstrumentById(id);
            string fullImagePath = Path.Combine(Application.StartupPath, instrumentDetails.ImagePath);

            if (File.Exists(fullImagePath))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                pictureBox1.Image = Image.FromFile(fullImagePath);
            }
            else
            {
                MessageBox.Show("Image not found: " + fullImagePath);
            }

            switch (category)
            {
                case "Stringed":
                    richTextBox1.Text = "";
                    var stringedDetails = repo.GetStringedInstrumentsById(id);
                    richTextBox1.Text = "Number of strings: " + stringedDetails.NumberOfStrings +
                                        "\nType: " + stringedDetails.Type +
                                        "\nScale: " + stringedDetails.Scale +
                                        "\nNumber of Frets: " + stringedDetails.Frets +
                                        "\nWood: " + stringedDetails.Wood;
                    break;

                case "Keyboard":
                    richTextBox1.Text = "";
                    var keyboardDetails = repo.GetKeyboardInstrumentsById(id);
                    var yesNoBoolean = keyboardDetails.IsDigital ? "Digital" : "Acoustic";
                    richTextBox1.Text = "Number of keys: " + keyboardDetails.KeysCount +
                                        "\nType: " + yesNoBoolean;

                    break;

                case "Blowing":
                    richTextBox1.Text = "";
                    var blowingDetails = repo.GetBlowingInstrumentsById(id);
                    richTextBox1.Text = "Material: " + blowingDetails.Material +
                                        "\nKeyType: " + blowingDetails.KeyType +
                                        "\nTuning: " + blowingDetails.Tuning;
                    break;

                case "Drums":
                    richTextBox1.Text = "";
                    var drumDetails = repo.GetDrumsById(id);
                    var DrumYesNoBoolean = drumDetails.IsElectric ? "Electric" : "Acoustic";
                    richTextBox1.Text = "Category: " + drumDetails.DrumType +
                                        "\nType: " + DrumYesNoBoolean +
                                        "\nNumber of drums included: " + drumDetails.NumberOfDrums;
                    break;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayInstrumentInfo();
        }

        private void SearchInstruments(string query)
        {
            listView1.Items.Clear();
            var repo = new InstrumentRepository();
            var instruments = repo.GetInstruments()
                                .Where(i => i.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                i.Brand.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                i.Category.Contains(query, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            foreach (var instr in instruments)
            {
                string fullImagePath = Path.Combine(Application.StartupPath, instr.ImagePath);
                if (instr.Stock > 0)
                {
                    if (!string.IsNullOrEmpty(instr.ImagePath) && File.Exists(fullImagePath))
                    {
                        if (!imageList1.Images.ContainsKey(instr.ImagePath))
                        {
                            imageList1.Images.Add(instr.ImagePath, Image.FromFile(fullImagePath));
                        }
                    }
                    var item = new ListViewItem(instr.Name);
                    item.SubItems.Add(instr.Brand);
                    item.SubItems.Add(instr.Color);
                    item.SubItems.Add(instr.Price.ToString("C"));
                    item.SubItems.Add(instr.Stock.ToString());
                    item.SubItems.Add(instr.Category);
                    item.Tag = instr.Id;
                    if (imageList1.Images.ContainsKey(instr.ImagePath))
                    {
                        item.ImageKey = instr.ImagePath;
                    }
                    listView1.Items.Add(item);
                }
            }

        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string query = toolStripTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                LoadInstruments();
            }
            else SearchInstruments(query);
        }

        private void stringedInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I wish i'd get pegged by a big tiddie goth mommy gf");
            AddEditStringed form = new AddEditStringed();
            if (form.ShowDialog() == DialogResult.OK)
            {
                HideInfo();

                LoadInstruments();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            var val = listView1.SelectedItems[0];
            // if (string.IsNullOrEmpty(val.ToString())) return;
            int instrumentId = (int)val.Tag;

            var repo = new InstrumentRepository();
            var instr = repo.GetInstrumentById(instrumentId);
            var stringed = repo.GetStringedInstrumentsById(instrumentId);
            var keyboard = repo.GetKeyboardInstrumentsById(instrumentId);
            var blowing = repo.GetBlowingInstrumentsById(instrumentId);
            var drum = repo.GetDrumsById(instrumentId);

            if (instr == null) return;
            switch (instr.Category)
            {
                case "Stringed":
                    AddEditStringed stringedForm = new AddEditStringed();
                    stringedForm.EditInstrument(instr, stringed);
                    if (stringedForm.ShowDialog() == DialogResult.OK)
                    {
                        HideInfo();
                        LoadInstruments();
                    }
                    break;
                case "Keyboard":
                    AddEditKeyboard keyForm = new AddEditKeyboard();
                    keyForm.EditInstrument(instr, keyboard);
                    if (keyForm.ShowDialog() == DialogResult.OK)
                    {
                        HideInfo();
                        LoadInstruments();
                    }
                    break;
                case "Blowing":
                    AddEditBlowing blowForm = new AddEditBlowing();
                    blowForm.EditInstrument(instr, blowing);
                    if (blowForm.ShowDialog() == DialogResult.OK)
                    {
                        HideInfo();
                        LoadInstruments();
                    }
                    break;
                case "Drums":
                    AddEditDrums drumForm = new AddEditDrums();
                    drumForm.EditInstrument(instr, drum);
                    if (drumForm.ShowDialog() == DialogResult.OK)
                    {
                        HideInfo();
                        LoadInstruments();
                    }
                    break;
            }
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditKeyboard form = new AddEditKeyboard();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadInstruments();
            }
        }

        private void blowingInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditBlowing form = new AddEditBlowing();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadInstruments();
            }
        }

        private void drumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditDrums form = new AddEditDrums();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadInstruments();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            var val = listView1.SelectedItems[0];
            //if (string.IsNullOrEmpty(val.ToString())) return;
            int instrumentId = (int)val.Tag;
            var repo = new InstrumentRepository();
            var instr = repo.GetInstrumentById(instrumentId);


            switch (instr.Category)
            {
                case "Stringed":
                    repo.DeleteStringedInstruments(instrumentId);
                    HideInfo();
                    LoadInstruments();
                    break;
                case "Keyboard":
                    repo.DeleteKeyboardInstruments(instrumentId);
                    HideInfo();
                    LoadInstruments();
                    break;
                case "Blowing":
                    repo.DeleteBlowingInstruments(instrumentId);
                    HideInfo();
                    LoadInstruments();
                    break;
                case "Drums":
                    repo.DeleteDrums(instrumentId);
                    HideInfo();
                    LoadInstruments();
                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Logs logForm = new Logs();
            if (logForm.ShowDialog() == DialogResult.OK)
            {
                LoadInstruments();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            if (usersForm.ShowDialog() == DialogResult.OK)
            {
                LoadInstruments();
            }
        }
    }
}
