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
        StationRepository stationQuery;
        List<Station> dgvElements;
        IRepositoryFactory factory;

        public dgvStationController(DataGridView dgv, IRepositoryFactory factory)
        {
            //stationQuery = factory.GetStationRepository();
            this.factory = factory;
            this.dgv = dgv;
        }

        public void showTable()
        {
            dgvElements = new List<Station>();
            dgvElements = factory.GetStationRepository().getStations();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(),ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void showAdminTable()
        {
            dgvElements = new List<Station>();
            dgvElements = factory.GetStationRepository().getStations();
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet(), ps.GetStorageCap());
            }
        }

        public void findInTable(string country, string city)
        {
            dgvElements = new List<Station>();
            dgvElements = factory.GetStationRepository().findStations(country, city);
            dgv.Rows.Clear();
            foreach (Station ps in dgvElements)
            {
                dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
            }
        }

        public void addToTable(Station st)
        {
            factory.GetStationRepository().AddToStationTable(st);
        }
    }
}
