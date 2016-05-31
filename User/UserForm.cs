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
using Queries.Interfaces;

namespace User
{
    public partial class UserForm : Form //форма пользователя
    {
        IRepositoryFactory factory;
        StationController fillStaffTable;
        DealController fillDealTable;
        public NpgsqlConnection conn;
        string cardnum;

        public UserForm(string cardnum, IRepositoryFactory factory)
        {
            InitializeComponent();
            this.cardnum = cardnum;
            this.factory = factory; 
            //fillStaffTable = new StationController(dgvVievAZS, factory);
            //fillDealTable = new DealController(dgvUserDeals, factory);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            fillStaffTable = new StationController(dgvVievAZS, factory);
            fillStaffTable.showTable();
            fillDealTable = new DealController(dgvUserDeals, factory);
            fillDealTable.showUserTable(cardnum);
        }

        private void dataView1_Click(object sender, EventArgs e)
        {
            fillStaffTable.showTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fCountry = tbCountry.Text;
            string fCity = tbCity.Text;
            fillStaffTable.findInTable(fCountry, fCity);
        }
    }
}
