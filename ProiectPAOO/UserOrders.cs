using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProiectPAOO.Repositories;

namespace ProiectPAOO
{
    public partial class UserOrders : Form
    {
        private int _id;
        private string _username;
        public UserOrders(int id, string username)
        {
            InitializeComponent();
            _id = id;
            _username = username;
            label1.Text = username + "'s orders";
            LoadLogs();
        }

        private void LoadLogs()
        {
            listView1.Items.Clear();

            var repo = new LogRepository();
            var instrRepo = new InstrumentRepository();

            var logs = repo.GetLogsByUserId(_id);

            foreach (var log in logs)
            {
                var instr = instrRepo.GetInstrumentById(log.InstrumentId);
                var item = new ListViewItem(instr.Brand + " " + instr.Name);
                item.SubItems.Add(log.Quantity.ToString());
                item.SubItems.Add(log.PurchaseDate.ToString());
                item.SubItems.Add(log.TotalPrice.ToString("C"));
                item.SubItems.Add(log.ShippingAddress.ToString());
                item.SubItems.Add(log.OrderStatus);
                item.Tag = log.Id;

                listView1.Items.Add(item);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selectedItem = listView1.SelectedItems[0];
            var id = (int)selectedItem.Tag;
            var repo = new LogRepository();
            var message = MessageBox.Show("Are you sure you want to cancel the order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(message == DialogResult.Yes)
            {
                repo.CancelOrder(id);
                LoadLogs();
            }
            
        }
    }
}
