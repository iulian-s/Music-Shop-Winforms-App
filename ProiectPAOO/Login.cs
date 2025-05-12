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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            this.AcceptButton = button1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var repo = new UsersRepository();
            if (repo.CheckLogin(textBox1.Text, textBox2.Text))
            {
                
                var user = repo.GetUserByEmail(textBox1.Text);
                this.Hide();
                if (user.Role == "admin")
                {
                    using (Form1 form = new Form1())
                        form.ShowDialog();
                }
                else
                {
                    using (UserInterface userInterface = new UserInterface(user.Id,user.Username))
                        userInterface.ShowDialog();
                }
                this.Close();
            }

            else
                MessageBox.Show("Login failed! Please check credentials!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            using (SignupForm form = new SignupForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    this.Show();
                if (form.DialogResult == DialogResult.OK)
                    this.Show();
            }
                
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }
    }
}
