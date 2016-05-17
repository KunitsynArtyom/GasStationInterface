﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.Collections;
using Queries.Entities;
using Queries.Interfaces;
using Queries.TableRepositories;


namespace Queries.Interfaces
{
    public interface IRepositoryFactory
    {
        StationRepository GetStationRepository();

        StaffRepository GetStaffRepository();

        CarRepository GetCarRepository();

        DealRepository GetDealRepository();

        AccountRepository GetAccountRepository();

        
    }
}
