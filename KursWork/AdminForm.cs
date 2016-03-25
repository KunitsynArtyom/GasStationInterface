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

namespace KursWork
{
    public partial class AdminForm : Form
    {
        AdminQuery adminQuery;
        public NpgsqlConnection conn;
        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            adminQuery = new AdminQuery(conn, dgvVievStaff);
        }

        private void AdminForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EnterForm frm1 = new EnterForm();
            frm1.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            adminQuery.showStaffTabele();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            adminQuery.showStaffTabele();
        }
    }
}
