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

namespace Queries.comboBoxFillers
{
    public class comboBoxCardNumFiller
    {
        ComboBox cb;
        List<string> comboBoxElements;
        IRepositoryFactory factory;
        CarRepository carQuery;
        public comboBoxCardNumFiller(ComboBox cb, IRepositoryFactory factory)
        {
            this.cb = cb;
            this.factory = factory;
            //carQuery = factory.GetCarRepository();
        }

        public void cb_CardNumFill()
        {
            comboBoxElements = factory.GetCarRepository().GetCardNumList();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }
    }
}
