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
using Queries.Repositories;
using Queries.Interfaces;
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class SupplyController
    {
        private DataGridView dgv;
        private List<Supply> dgvElements;
        private IRepositoryFactory factory;
        private SupplyValidator supplyValidator;
        private List<string> errorList;
        private string error;

        public SupplyController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Supply>();
            this.dgv = dgv;
            this.factory = factory;
            supplyValidator = new SupplyValidator();
        }

        public void ShowTable()
        {
            try
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
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void ShowTable(int ID)
        {
            try
            {
                int id = factory.GetStaffRepository().FindStationIDByStaffID(ID);
                dgvElements = factory.GetSupplyRepository().ShowSupplyTableByID(id);
                dgv.Rows.Clear();
                foreach (Supply supply in dgvElements)
                {
                    int station_id = supply.GetStation_id();
                    dgv.Rows.Add(RemoveSpaces(factory.GetStationRepository().GetStationsAdresByID(station_id)), factory.GetStaffRepository().FindStaffByID(supply.GetStaff_id()), supply.GetFuelSupplyType(),
                        supply.GetFuelSupplyAmount(), supply.GetSupplyDate());
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public bool AddToSupplyTable(Supply sup)
        {
            bool checkFlag = false;
            try
            {
                if (checkFlag = supplyValidator.checkAddition(sup, out errorList))
                {
                    factory.GetSupplyRepository().AddToSupplyTable(sup);
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

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
