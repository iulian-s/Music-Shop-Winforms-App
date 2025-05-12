using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using ProiectPAOO.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProiectPAOO
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            Read_Users();
        }

        private void Read_Users()
        {
            DataTable logsDataTable = new DataTable();

            logsDataTable.Columns.Add("ID");
            logsDataTable.Columns.Add("Username");
            logsDataTable.Columns.Add("Password");
            logsDataTable.Columns.Add("Email");
            logsDataTable.Columns.Add("Name");
            logsDataTable.Columns.Add("Phone Number");
            logsDataTable.Columns.Add("Address");
            logsDataTable.Columns.Add("Role");

            var repo = new UsersRepository();
            var users = repo.GetUsers();

            foreach (var user in users)
            {
                var row = logsDataTable.NewRow();
                row["ID"] = user.Id;
                row["Username"] = user.Username;
                row["Password"] = user.Password;
                row["Email"] = user.Email;
                row["Name"] = user.FullName;
                row["Phone Number"] = user.PhoneNumber;
                row["Address"] = user.Address;
                row["Role"] = user.Role;

                logsDataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = logsDataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                var repo = new UsersRepository();
                var user = repo.GetUserById(id);
                if (user == null) return;
                EditUsers editForm = new EditUsers();
                editForm.EditUser(user);
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    Read_Users();
                }
            }
        }
    }
}
