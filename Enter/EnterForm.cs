using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using User;
using Admin;


namespace Enter
{
    public partial class EnterForm : Form //форма логина
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private void btnUserLog_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS");
            UserForm userForm = new UserForm(conn);
            Hide();
            userForm.ShowDialog();
            Show();
        }

        private void btnAdminLog_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = postgres; Password = qwerty1; Database = AZS"); // якобы заходим под админом
            AdminForm adminForm = new AdminForm(conn);
            Hide();
            adminForm.ShowDialog();
            Show();
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //connection.Close();
        }
    }
}
