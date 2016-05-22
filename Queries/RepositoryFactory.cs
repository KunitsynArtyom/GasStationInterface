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

namespace Queries
{  
    public class RepositoryFactory : IRepositoryFactory
    {
        DBConnection dbc;

        public RepositoryFactory(DBConnection dbc)
        {
            //if (dbc == null)
            //{
            //    throw new ArgumentNullException("Connection out!");
            //}

            this.dbc = dbc;
        }

        public IStationRepository GetStationRepository()
        {
            return new StationRepository(dbc);
        }

        public IStaffRepository GetStaffRepository()
        {
            return new StaffRepository(dbc);
        }

        public ICarRepository GetCarRepository()
        {
            return new CarRepository(dbc);
        }

        public IDealRepository GetDealRepository()
        {
            return new DealRepository(dbc);
        }

        public IAccountRepository GetAccountRepository()
        {
            return new AccountRepository(dbc);
        }

        public ISupplyRepository GetSupplyRepository()
        {
            return new SupplyRepository(dbc);
        }
    }
}
