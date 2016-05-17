using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;
using Queries.TableRepositories;
using Queries.Interfaces;

namespace Queries.dgvControllers
{
    public class dgvStationController
    {
        DataGridView dgv;
        IRepositoryFactory factory;
        StationRepository stationQuery;
        List<Station> dgvElements;
        DBConnection dbc;

        public dgvStationController(DataGridView dgv, DBConnection dbc)
        {
            factory = new RepositoryFactory(dbc);
            stationQuery = factory.GetStationRepository();
            this.dbc = dbc;
            //stationQuery = new StationRepository(dbc);
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = new List<Station>();
            dgvElements = stationQuery.getStations();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(),ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void showAdminTable()
        {
            dgvElements = new List<Station>();
            dgvElements = stationQuery.getStations();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet(), ps.GetStorageCap());
            }
        }

        public void findInTable(string country, string city)
        {
            dgvElements = new List<Station>();
            dgvElements = stationQuery.findStations(country, city);
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void addToTable(Station st)
        {
            stationQuery.AddToStationTable(st);
        }
    }
}
