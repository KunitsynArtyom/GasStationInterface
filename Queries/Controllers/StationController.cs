using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Npgsql;
using Queries.Entities;
using Queries.Repositories;
using Queries.Interfaces;
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class StationController
    {
        private DataGridView dgv;
        private StationValidator stationValidator;
        private List<Station> dgvElements;
        private IRepositoryFactory factory;
        private List<string> errorList;
        private string error;

        public StationController(DataGridView dgv, IRepositoryFactory factory)
        {
            this.factory = factory;
            this.dgv = dgv;
            stationValidator = new StationValidator();
        }

        public void ShowTable()
        {
            try
            {
                dgvElements = new List<Station>();
                dgvElements = factory.GetStationRepository().getStations();
                dgv.Rows.Clear();
                foreach (Station ps in dgvElements)
                {
                    dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
}

        public void ShowAdminTable()
        {
            try
            {
                dgvElements = new List<Station>();
                dgvElements = factory.GetStationRepository().getStations();
                dgv.Rows.Clear();
                foreach (Station ps in dgvElements)
                {
                    dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet(), ps.GetStorageCap());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void FindInTable(string country, string city)
        {
            try
            {
                dgvElements = new List<Station>();
                dgvElements = factory.GetStationRepository().findStations(country, city);
                dgv.Rows.Clear();
                foreach (Station ps in dgvElements)
                {
                    dgv.Rows.Add(ps.GetOrgName(), ps.GetCountry(), ps.GetCity(), ps.GetStreet());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool AddToTable(Station st)
        {
            bool checkFlag = false;
            try
            {
                if (checkFlag = stationValidator.checkAddition(st, out errorList))
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
            catch (Exception) { MessageBox.Show("Невозможно выполнить операцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return checkFlag;
        }
    }
}
