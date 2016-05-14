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
using System.Collections;
using Queries;
using Queries.Entities;
using Queries.dgvControllers;
using Queries.comboBoxFillers;

namespace Worker
{
    public partial class addToDealTableForm : Form
    {
        public Form wf;
        DataGridView dgv;
        DBConnection dbc;

        public addToDealTableForm(Form workerForm, DBConnection dbc, DataGridView dgv)
        {
            InitializeComponent();
            wf = workerForm;
            this.dbc = dbc;
            this.dgv = dgv;
        }

        private void addToDealTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxDealFiller cbsf;
                cbStationList.Visible = false;
                label2.Visible = false;
                cbsf = new comboBoxDealFiller(cbOrgList, dbc);
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
                    cbdf = new comboBoxDealFiller(cbStationList, dbc);
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
                    cbdf = new comboBoxDealFiller(cbStaffList, dbc);
                    cbdf.cb_stationFill(cbOrgList.Text);
                }
            }
            catch (Exception ex) { }
        }
    }
}
