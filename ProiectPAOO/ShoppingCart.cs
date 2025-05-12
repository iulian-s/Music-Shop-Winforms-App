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
    public partial class ShoppingCart : Form
    {
        private int _id;
        private string _username;
        public ShoppingCart(int id, string username)
        {
            InitializeComponent();
            _id = id;
            _username = username;
            label13.Text = _username + "'s shopping cart";
            LoadItems();
        }

        private void LoadItems()
        {
            listView1.Items.Clear();
            imageList1.Images.Clear();

            var repo = new InstrumentRepository();
            var cartRepo = new ClientRepository();
            var userRepo = new UsersRepository();
            var cartItems = cartRepo.GetCartByUserId(_id);
            var user = userRepo.GetUserById(_id);
            var address = user.Address;
            decimal totalPrice = 0;
            foreach (var cartItem in cartItems)
            {
                var instr = repo.GetInstrumentById(cartItem.InstrumentId);
                if (instr == null || instr.Stock <= 0) continue;

                string fullImagePath = Path.Combine(Application.StartupPath, instr.ImagePath);

                // Load image if exists
                if (!string.IsNullOrEmpty(instr.ImagePath) && File.Exists(fullImagePath))
                {
                    if (!imageList1.Images.ContainsKey(instr.ImagePath))
                    {
                        imageList1.Images.Add(instr.ImagePath, Image.FromFile(fullImagePath));
                    }
                }

                var listViewItem = new ListViewItem(instr.Name);
                listViewItem.SubItems.Add(instr.Price.ToString("C"));
                listViewItem.SubItems.Add(cartItem.Quantity.ToString());
                listViewItem.Tag = instr.Id;

                if (imageList1.Images.ContainsKey(instr.ImagePath))
                {
                    listViewItem.ImageKey = instr.ImagePath;
                }

                listView1.Items.Add(listViewItem);


                totalPrice += instr.Price * cartItem.Quantity;
                label4.Text = totalPrice.ToString() + "$";
                textBox1.Text = address.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you really sure you want to place and order?" +
                "Please check all info before doing so", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var repo = new LogRepository();
                var cartRepo = new ClientRepository();
                var cart = cartRepo.GetCartByUserId(_id);
                var totalPriceText = label4.Text.Replace("$", "").Trim();

                repo.AddLog(_id, cart, textBox1.Text, decimal.Parse(totalPriceText));
                cartRepo.ClearCart();
                LoadItems();
                var userRepo = new UsersRepository();
                var user = userRepo.GetUserById(_id);
                var name = user.FullName;
                var pdfExporter = new PdfExporter();
                string fileName = $"OrderReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                pdfExporter.ExportCartToPdf(cart, name, textBox1.Text, path, decimal.Parse(totalPriceText));

                MessageBox.Show("Order placed and receipt saved to PDF.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int instrumentId = (int)selectedItem.Tag;

                var repo = new ClientRepository();
                repo.IncrementQuantity(instrumentId);
                LoadItems();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int instrumentId = (int)selectedItem.Tag;

                var repo = new ClientRepository();
                var currentQuantity = repo.GetItemQuantity(instrumentId);
                if(currentQuantity > 1) 
                    repo.DecrementQuantity(instrumentId);
                else repo.RemoveItemFromCart(instrumentId);
                LoadItems();
            }
        }
    }
}
