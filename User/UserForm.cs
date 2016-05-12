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

namespace User
{
    public partial class UserForm : Form //форма пользователя
    {
        StationRepository stationQuery;
        dgvStationFiller fillTable;
        public NpgsqlConnection conn;
        public UserForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            stationQuery = new StationRepository(conn);
            fillTable = new dgvStationFiller(dgvVievAZS, conn);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            fillTable.showTable();
        }

        private void dataView1_Click(object sender, EventArgs e)
        {
            fillTable.showTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fCountry = tbCountry.Text;
            string fCity = tbCity.Text;
            fillTable.findInTable(fCountry, fCity);
        }
    }
}
