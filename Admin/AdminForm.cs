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
using Queries;

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        dgvStaffFiller fillTable;
        public AdminQuery adminQuery;
        public NpgsqlConnection conn;

        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            adminQuery = new AdminQuery(conn/*, dgvVievStaff*/);
            additionalForm = this;
        }

        private void AdminForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillTable = new dgvStaffFiller(dgvVievStaff, adminQuery);
            fillTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillTable = new dgvStaffFiller(dgvVievStaff, adminQuery);
            fillTable.showTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStaffTableForm updateForm = new updateStaffTableForm(dgvVievStaff.CurrentRow, adminQuery, dgvVievStaff);
            updateForm.ShowDialog();
            Hide();
            Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToStaffTableForm addForm = new addToStaffTableForm(additionalForm, adminQuery, dgvVievStaff);
            addForm.ShowDialog();
            Hide();
            Show();
        }
    }
}
