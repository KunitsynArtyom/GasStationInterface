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
using Queries.dgvControllers;
using Queries.TableRepositories;
using Queries.Controllers;
using Queries.Interfaces;

namespace Admin
{
    public partial class AdminForm : Form
    {
        IRepositoryFactory factory;
        private Form additionalForm;
        dgvStaffController fillStaffTable;
        dgvCarController fillCarTable;
        dgvAccountController fillAccountingTable;
        dgvDealController fillDealTable;
        dgvStationController fillStationTable;

        public AdminForm(IRepositoryFactory factory)
        {
            InitializeComponent();
            this.factory = factory;        
            additionalForm = this;                 
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillStationTable = new dgvStationController(dgvVievAZS, factory);
            fillStationTable.showAdminTable();
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarController(dgvViewCars, factory);
            fillCarTable.showTable();
            fillAccountingTable = new dgvAccountController(dgvViewAccounting, factory);
            fillAccountingTable.showTable();
            fillDealTable = new dgvDealController(dgvViewDeal, factory);
            fillDealTable.showTable();
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateStaffTableForm updateForm = new UpdateStaffTableForm(dgvViewStaff.CurrentRow, factory, dgvViewStaff);
            updateForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToStaffTableForm addForm = new AddToStaffTableForm(additionalForm, factory, dgvViewStaff);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //fillStaffTable = new dgvStaffController(dgvViewStaff, dbc);
            //fillStaffTable.deleteFromTable(dgvViewStaff.CurrentRow.Index);


            var cell = dgvViewStaff[0, dgvViewStaff.CurrentRow.Index];
            int id = Convert.ToInt32(cell.Value);


            StaffController sc = new StaffController();
            if (sc.checkDelete(id))
            {
                dgvStaffController dgsc = new dgvStaffController(dgvViewStaff, factory);
                dgsc.deleteFromTable(id);
            }
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
            //sc.checkDelete(dgvViewStaff.CurrentRow.Index);
            //fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            //fillStaffTable.showTable();
        }

        private void btnFindDeals_Click(object sender, EventArgs e)
        {
            var cell = dgvViewCars[0, dgvViewCars.CurrentRow.Index];
            int id = Convert.ToInt32(cell.Value);
            DealList dealList = new DealList(id, factory);
            dealList.ShowDialog();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            AddToCarTableForm addForm = new AddToCarTableForm(additionalForm, factory, dgvViewCars);
            addForm.ShowDialog();
            fillCarTable = new dgvCarController(dgvViewCars, factory);
            fillCarTable.showTable();


            //Hide();
        }

        private void btnDealUpdate_Click(object sender, EventArgs e)
        {
            UpdateDealTableForm updateDealForm = new UpdateDealTableForm(dgvViewDeal.CurrentRow, factory, dgvViewDeal);
            updateDealForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvViewDeal, factory);
            fillDealTable.showTable();
        }

        private void btnStationAdd_Click(object sender, EventArgs e)
        {
            AddToStationTableForm addForm = new AddToStationTableForm(additionalForm, factory, dgvViewCars);
            addForm.ShowDialog();
            Hide();
            Show();
            fillStationTable = new dgvStationController(dgvVievAZS, factory);
            fillStationTable.showAdminTable();
        }

        private void RefreshTables_Click(object sender, EventArgs e)
        {
            fillStationTable = new dgvStationController(dgvVievAZS, factory);
            fillStationTable.showAdminTable();
            fillStaffTable = new dgvStaffController(dgvViewStaff, factory);
            fillStaffTable.showTable();
            fillCarTable = new dgvCarController(dgvViewCars, factory);
            fillCarTable.showTable();
            fillAccountingTable = new dgvAccountController(dgvViewAccounting, factory);
            fillAccountingTable.showTable();
            fillDealTable = new dgvDealController(dgvViewDeal, factory);
            fillDealTable.showTable();
        }

        private void AddNewAdmin_Click(object sender, EventArgs e)
        {
            AddNewAdminForm addAdminForm = new AddNewAdminForm(factory);
            addAdminForm.ShowDialog();
            Hide();
            Show();
        }
    }
}
