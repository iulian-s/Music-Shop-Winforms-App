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
using ProiectPAOO.Models;

namespace ProiectPAOO
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string username = textBox3.Text.Trim();
            var repo = new UsersRepository();
            if (!repo.IsValidEmail(email))
            {
                MessageBox.Show("Invalid or already used email.");
                return;
            }
            if (repo.UsernameExists(username))
            {
                MessageBox.Show("Username already taken. Please choose another one.");
                return;
            }
            Users newUser = new Users
            {
                Email = email,
                Username = username,
                Password = textBox2.Text.Trim()
            };
            repo.CreateUser(newUser);
            MessageBox.Show("Account created successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }
    }
}
