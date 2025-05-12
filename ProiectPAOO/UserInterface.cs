using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProiectPAOO.Repositories;

namespace ProiectPAOO
{
    public partial class UserInterface : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        public static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        private int _id;
        private string _username;
        private decimal defaultMinValue;
        private decimal defaultMaxValue;
        public UserInterface(int id, string username)
        {
            InitializeComponent();
            _username = username;
            _id = id;
            label1.Text = _username;
            SetPlaceholder(textBox2, "e.g Guitar");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            imageList1.ImageSize = new Size(32, 32);
            listView1.SmallImageList = imageList1;
            LoadInstruments();
            defaultMinValue = numericUpDown1.Value;
            defaultMaxValue = numericUpDown2.Value;
            label14.Visible = false;
            richTextBox1.Visible = false;
            pictureBox2.Visible = false;
            button2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(label1, new Point(0, label1.Height));
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(label1, new Point(0, label1.Height));
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
            label14.Visible = true;
            pictureBox2.Visible = true;
            button2.Visible = true;
            var selectedItem = listView1.SelectedItems[0];
            int id = (int)selectedItem.Tag;
            string category = selectedItem.SubItems[5].Text;
            //MessageBox.Show("id = " + id + " cat " + category);

            var repo = new InstrumentRepository();
            var instrumentDetails = repo.GetInstrumentById(id);
            string fullImagePath = Path.Combine(Application.StartupPath, instrumentDetails.ImagePath);

            if (File.Exists(fullImagePath))
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                pictureBox2.Image = Image.FromFile(fullImagePath);
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
            var instruments = repo.SearchInstruments(query);

            foreach (var instr in instruments)
            {
                string fullImagePath = Path.Combine(Application.StartupPath, instr.ImagePath);

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchInstruments(textBox2.Text);
            if (string.IsNullOrEmpty(textBox2.Text))
                ResetFilters();
        }



        private void AddFilters()
        {
            listView1.Items.Clear();
            var repo = new InstrumentRepository();
            string selectedCategory = comboBox1.Text;
            string selectedOrder = comboBox2.Text;
            bool filterStock = checkBox1.Checked;
            string color = textBox1.Text;
            var instruments = repo.CategoryFilter(selectedCategory, selectedOrder, filterStock, (decimal)numericUpDown1.Value, (decimal)numericUpDown2.Value, color);

            foreach (var instr in instruments)
            {
                string fullImagePath = Path.Combine(Application.StartupPath, instr.ImagePath);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddFilters();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            AddFilters();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFilters();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AddFilters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFilters();
        }

        private void ResetFilters()
        {
            LoadInstruments();
            numericUpDown1.Value = defaultMinValue;
            numericUpDown2.Value = defaultMaxValue;
            checkBox1.CheckState = CheckState.Unchecked;
            textBox1.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var repo = new InstrumentRepository();
            var selectedItem = listView1.SelectedItems[0];
            int id = (int)selectedItem.Tag;
            var instrument = repo.GetInstrumentById(id);
            var cartRepo = new ClientRepository();
            cartRepo.AddToCart(_id, id);
            MessageBox.Show(instrument.Name + " was added to the cart");
        }

        private void shoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            using (ShoppingCart form = new ShoppingCart(_id, _username))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    this.Show();
                if (form.DialogResult == DialogResult.OK)
                    this.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            using (UserSettings form = new UserSettings(_id))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    this.Show();
                Show();
            }
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            using (UserOrders form = new UserOrders(_id, _username))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    this.Show();
                Show();
            }
        }
    }
}
