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
using Queries.TableRepositories;

namespace Admin
{
    public partial class AdminForm : Form
    {
        private Form additionalForm;
        dgvStaffFiller fillStaffTable;
        dgvCarFiller fillCarTable;
        dgvAccountFiller fillAccountingTable;
        dgvDealFiller fillDealTable;
        StaffRepository staffQuery;
        public NpgsqlConnection conn;

        public AdminForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            additionalForm = this;
            staffQuery = new StaffRepository(conn);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarFiller(dgvVievCars, conn);
            fillCarTable.showTable();
            fillAccountingTable = new dgvAccountFiller(dgvViewAccounting, conn);
            fillAccountingTable.showTable();
            fillDealTable = new dgvDealFiller(dgvVievDeal, conn);
            fillDealTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.showTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStaffTableForm updateForm = new updateStaffTableForm(dgvVievStaff.CurrentRow, conn, dgvVievStaff);
            updateForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToStaffTableForm addForm = new addToStaffTableForm(additionalForm, conn, dgvVievStaff);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.showTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.deleteFromTable(dgvVievStaff.CurrentRow.Index);
            fillStaffTable = new dgvStaffFiller(dgvVievStaff, conn);
            fillStaffTable.showTable();
        }

        private void btnFindDeals_Click(object sender, EventArgs e)
        {
            DealList dealList = new DealList(dgvVievCars.CurrentRow.Index, conn);
            dealList.ShowDialog();


            //Hide();
            //Show();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            addToCarTableForm addForm = new addToCarTableForm(additionalForm, conn, dgvVievCars);
            addForm.ShowDialog();
            fillCarTable = new dgvCarFiller(dgvVievCars, conn);
            fillCarTable.showTable();


            //Hide();
        }

        private void btnDealUpdate_Click(object sender, EventArgs e)
        {
            updateDealTableForm updateDealForm = new updateDealTableForm(dgvVievDeal.CurrentRow, conn, dgvVievDeal);
            updateDealForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealFiller(dgvVievDeal, conn);
            fillDealTable.showTable();
        }
    }
}
