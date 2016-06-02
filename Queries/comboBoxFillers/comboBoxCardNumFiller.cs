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

namespace Queries.comboBoxFillers
{
    public class ComboBoxCardNumFiller
    {
        private ComboBox cb;
        private List<string> comboBoxElements;
        private IRepositoryFactory factory;

        public ComboBoxCardNumFiller(ComboBox cb, IRepositoryFactory factory)
        {
            this.cb = cb;
            this.factory = factory;
        }

        public void CbCardNumFill()
        {
            comboBoxElements = factory.GetCarRepository().GetCardNumList();
            foreach (string st in comboBoxElements)
            {
                cb.Items.Add(st);
            }
        }
    }
}
