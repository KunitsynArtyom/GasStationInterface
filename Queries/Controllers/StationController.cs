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
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class StationController
    {
        DataGridView dgv;
        StationValidator stationValidator;
        List<Station> dgvElements;
        IRepositoryFactory factory;
        List<string> errorList;
        string error;

        public StationController(DataGridView dgv, IRepositoryFactory factory)
        {
            this.factory = factory;
            this.dgv = dgv;
            stationValidator = new StationValidator();
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
            try
            {
                if (stationValidator.checkAddition(st, out errorList))
                {
                    factory.GetStationRepository().AddToStationTable(st);
                }
                else
                {
                    int k = 0;
                    foreach (string str in errorList)
                    {
                        k++;
                        error += "Ошибка №" + k + ": " + str + " \n";
                    }
                    MessageBox.Show(error);
                }
            }
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!"); }
        }
    }
}
