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
using Queries.dgvMediators;

namespace User
{
    public partial class UserForm : Form //форма пользователя
    {
        UserQuery userQuery;
        dgvStationFiller fillTable;
        public NpgsqlConnection conn;
        public UserForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            userQuery = new UserQuery(conn/*, dgvVievAZS*/);
            fillTable = new dgvStationFiller(dgvVievAZS, userQuery);
        }

        private void UserForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //EnterForm frm1 = new EnterForm();
            //frm1.Show();
        }


        private void UserForm_Load(object sender, EventArgs e)
        {
            //uq = new UserQuery(dgvVievAZS);
            //userQuery.showAZSTable();
            //fillTable = new dgvStationFiller(dgvVievAZS, userQuery);
            fillTable.showTable();
        }

        private void dataView1_Click(object sender, EventArgs e)
        {
            //uq = new UserQuery(dgvVievAZS);
            //userQuery.showAZSTable();
            //fillTable = new dgvStationFiller(dgvVievAZS, userQuery);
            fillTable.showTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fCountry = tbCountry.Text;
            string fCity = tbCity.Text;
            fillTable.findInTable(fCountry, fCity);
            //uq = new UserQuery(dgvVievAZS);
            //userQuery.findAZS(tbCountry, tbCity);
        }
    }
}
