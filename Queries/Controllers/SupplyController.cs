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
using Queries.Validators;

namespace Queries.dgvControllers
{
    public class SupplyController
    {
        DataGridView dgv;
        List<Supply> dgvElements;
        IRepositoryFactory factory;
        SupplyValidator supplyValidator;
        List<string> errorList;
        string error;

        public SupplyController(DataGridView dgv, IRepositoryFactory factory)
        {
            dgvElements = new List<Supply>();
            this.dgv = dgv;
            this.factory = factory;
            supplyValidator = new SupplyValidator();
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

        public void showTable(int ID)
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

        public void addToSupplyTable(Supply sup)
        {
            try
            {
                if (supplyValidator.checkAddition(sup, out errorList))
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
            catch (NpgsqlException ne) { MessageBox.Show("Невозможно совершить операцию!"); }
        }

        private string RemoveSpaces(string inputString)
        {
            //inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }
    }
}
