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
        private readonly DBConnection dbc;

        public RepositoryFactory(DBConnection dbc)
        {
            if (dbc == null)
            {
                throw new ArgumentNullException("Connection out!");
            }

            this.dbc = dbc;
        }

        public StationRepository GetStationRepository()
        {
            return new StationRepository(dbc);
        }

        public StaffRepository GetStaffRepository()
        {
            return new StaffRepository(dbc);
        }

        public CarRepository GetCarRepository()
        {
            return new CarRepository(dbc);
        }

        public DealRepository GetDealRepository()
        {
            return new DealRepository(dbc);
        }

        public AccountRepository GetAccountRepository()
        {
            return new AccountRepository(dbc);
        }

        public SupplyRepository GetSupplyRepository()
        {
            return new SupplyRepository(dbc);
        }
    }
}
