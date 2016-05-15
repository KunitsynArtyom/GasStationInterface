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
using Queries.TableRepositories;

namespace Queries.dgvControllers
{
    public class dgvSupplyController
    {
        DataGridView dgv;
        SupplyRepository supplyQuery;
        StationRepository stationQuery;
        StaffRepository staffQuery;
        List<Supply> dgvElements;

        public dgvSupplyController(DataGridView dgv, DBConnection dbc)
        {
            dgvElements = new List<Supply>();
            this.dgv = dgv;
            supplyQuery = new SupplyRepository(dbc);
            stationQuery = new StationRepository(dbc);
            staffQuery = new StaffRepository(dbc);
        }

        public void showTable()
        {
            dgvElements = supplyQuery.ShowSupplyTable();
            dgv.Rows.Clear();
            foreach (Supply supply in dgvElements)
            {
                int station_id = supply.GetStation_id();
                dgv.Rows.Add(RemoveSpaces(stationQuery.GetStationsAdresByID(station_id)), staffQuery.FindStaffByID(supply.GetStaff_id()), supply.GetFuelSupplyType(),
                    supply.GetFuelSupplyAmount(), supply.GetSupplyDate());
                MessageBox.Show(station_id.ToString());
            }
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
