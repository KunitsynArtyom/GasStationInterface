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

namespace Queries.Controllers
{
    public class SupplyController
    {
        List<string> ErrorList = new List<string>();

        public SupplyController()
        {

        }

        public bool checkAddition(Supply sup)
        {
            bool checkFlag = true;
            if (sup.GetStation_id() < 0)
            {
                checkFlag = false;
            }
            if (sup.GetStaff_id() < 0)
            {
                checkFlag = false;
            }
            if (sup.GetFuelSupplyType() == String.Empty)
            {
                checkFlag = false;
                ErrorList.Add("Тип топлива не выбран!");
            }
            if (sup.GetFuelSupplyAmount() < 0)
            {
                checkFlag = false;
                ErrorList.Add("Количество топлива введено неправильно!");
            }

            return checkFlag;
        }
    }
}
