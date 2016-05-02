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
using Queries.dgvMediators;

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        dgvStaffFiller fillStaffTable;
        dgvCarFiller fillCarTable;
        public AdminQuery adminQuery;
        public NpgsqlConnection conn;

        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            adminQuery = new AdminQuery(conn/*, dgvVievStaff*/);
            additionalForm = this;
        }

        //private void AdminForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //}

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, adminQuery);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarFiller(dgvVievCars, adminQuery);
            fillCarTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, adminQuery);
            fillStaffTable.showTable();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, adminQuery);
            fillStaffTable.deleteFromTable(dgvVievStaff.CurrentRow.Index);
        }

        private void btnFindDeals_Click(object sender, EventArgs e)
        {
            DealList dealList = new DealList(dgvVievCars.CurrentRow.Index, adminQuery);
            dealList.ShowDialog();
            Hide();
        }
    }
}
