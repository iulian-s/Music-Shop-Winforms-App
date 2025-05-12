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
    public partial class EditUsers : Form
    {
        public EditUsers()
        {
            InitializeComponent();
        }

        private int userId = 0;
        internal void EditUser(Users user)
        {
            this.Text = "Edit User";
            label1.Text = "Edit User";
            textBox1.Text = user.Username;
            textBox2.Text = user.Password;
            textBox3.Text = user.Email;
            textBox4.Text = user.FullName;
            textBox5.Text = user.PhoneNumber;
            textBox7.Text = user.Address;
            comboBox1.Text = user.Role == "user" ? "user" : "admin";
            userId = user.Id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users user = new Users
            {
                Id = userId,
                Username = textBox1.Text,
                Password = textBox2.Text,
                Email = textBox3.Text,
                FullName = textBox4.Text,
                PhoneNumber = textBox5.Text,
                Address = textBox7.Text,
                Role = comboBox1.Text
            };
            var repo = new UsersRepository();
            repo.UpdateInfo(user);
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
