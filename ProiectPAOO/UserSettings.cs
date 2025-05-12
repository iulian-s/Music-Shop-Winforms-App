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
    public partial class UserSettings : Form
    {
        private int _id;
        public UserSettings(int id)
        {
            InitializeComponent();
            textBox5.UseSystemPasswordChar = true;
            _id = id;
            DisplayInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox5.UseSystemPasswordChar = false;
            else textBox5.UseSystemPasswordChar = true;
        }

        private void DisplayInfo()
        {
            var repo = new UsersRepository();
            var user = repo.GetUserById(_id);
            if (user != null)
            {
                textBox1.Text = user.Id.ToString();
                textBox2.Text = user.Username.ToString();
                textBox3.Text = user.Email.ToString();
                textBox4.Text = user.FullName.ToString();
                textBox5.Text = user.Password.ToString();
                textBox7.Text = user.PhoneNumber.ToString();
                textBox6.Text = user.Address.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users user = new Users
            {
                Id = _id,
                Username = textBox2.Text,
                Password = textBox5.Text,
                Email = textBox3.Text,
                FullName = textBox4.Text,
                PhoneNumber = textBox7.Text,
                Address = textBox6.Text,
                
            };
            var repo = new UsersRepository();
            repo.UpdateInfoForClients(user);
            MessageBox.Show("Changes applied successfully");
        }
    }
}
