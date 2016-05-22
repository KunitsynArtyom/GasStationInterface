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
using Queries.Interfaces;

namespace Queries.dgvControllers
{
    public class dgvSupplyController
    {
        DataGridView dgv;
        SupplyRepository supplyQuery;
        StationRepository stationQuery;
        StaffRepository staffQuery;
        List<Supply> dgvElements;
        IRepositoryFactory factory;

        public dgvSupplyController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Supply>();
            this.dgv = dgv;
            this.factory = factory;
            //supplyQuery = factory.GetSupplyRepository();
            //stationQuery = factory.GetStationRepository();
            //staffQuery = factory.GetStaffRepository();
        }

        public void showTable()
        {
            dgvElements = factory.GetSupplyRepository().ShowSupplyTable();
            dgv.Rows.Clear();
            foreach (Supply supply in dgvElements)
            {
                int station_id = supply.GetStation_id();
                dgv.Rows.Add(RemoveSpaces(factory.GetStationRepository().GetStationsAdresByID(station_id)), factory.GetStaffRepository().FindStaffByID(supply.GetStaff_id()), supply.GetFuelSupplyType(),
                    supply.GetFuelSupplyAmount(), supply.GetSupplyDate());
            }
        }

        public void addToSupplyTable(Supply sup)
        {
            factory.GetSupplyRepository().AddToSupplyTable(sup);
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
