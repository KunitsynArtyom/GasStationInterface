﻿using System;
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
using Queries.Interfaces;
using Queries.dgvControllers;

namespace Worker
{
    public partial class WorkerForm : Form
    {
        int ID;
        IRepositoryFactory factory;
        public Form additionalForm;
        dgvDealController fillDealTable;
        dgvSupplyController fillSupplyTable;

        public WorkerForm(int ID, IRepositoryFactory factory)
        {
            InitializeComponent();
            this.ID = ID;
            this.factory = factory;
            additionalForm = this;
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            fillDealTable = new dgvDealController(dgvVievDeal, factory);
            fillDealTable.showWorkerTable(ID);
            fillSupplyTable = new dgvSupplyController(dgvViewSupply, factory);
            fillSupplyTable.showTable(ID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToDealTableForm addForm = new AddToDealTableForm(ID, factory, dgvVievDeal);
            addForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvVievDeal, factory);
            fillDealTable.showWorkerTable(ID);
            fillSupplyTable = new dgvSupplyController(dgvViewSupply, factory);
            fillSupplyTable.showTable(ID);
        }

        private void btnAddSupply_Click(object sender, EventArgs e)
        {
            AddToSupplyTableForm addForm = new AddToSupplyTableForm(ID, factory, dgvViewSupply);
            addForm.ShowDialog();
            Hide();
            Show();
            fillDealTable = new dgvDealController(dgvVievDeal, factory);
            fillDealTable.showWorkerTable(ID);
            fillSupplyTable = new dgvSupplyController(dgvViewSupply, factory);
            fillSupplyTable.showTable(ID);
        }
    }
}
