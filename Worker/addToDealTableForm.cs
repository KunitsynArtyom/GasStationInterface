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
using System.Collections;
using Queries;
using Queries.Entities;
using Queries.dgvMediators;
using Queries.combBoxFillers;

namespace Worker
{
    public partial class addToDealTableForm : Form
    {
        public Form wf;
        WorkerQuery workerQuery;
        DataGridView dgv;

        public addToDealTableForm(Form workerForm, WorkerQuery workerQuery, DataGridView dgv)
        {
            InitializeComponent();
            wf = workerForm;
            this.workerQuery = workerQuery;
            this.dgv = dgv;
        }

        private void addToDealTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxDealFiller cbsf;
                cbStationList.Visible = false;
                label2.Visible = false;
                cbsf = new comboBoxDealFiller(cbOrgList, workerQuery);
                cbsf.cb_orgFill();
            }
            catch (Exception ex) { }
        }

        private void cbOrgList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbOrgList.SelectedIndex != -1)
                {
                    comboBoxDealFiller cbdf;
                    cbStationList.Visible = true;
                    label2.Visible = true;
                    cbdf = new comboBoxDealFiller(cbStationList, workerQuery);
                    cbdf.cb_stationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }

        private void cbStationList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cbStationList.SelectedIndex != -1)
                {
                    comboBoxDealFiller cbdf;
                    cbStaffList.Visible = true;
                    label2.Visible = true;
                    cbdf = new comboBoxDealFiller(cbStaffList, workerQuery);
                    cbdf.cb_stationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }
    }
}
