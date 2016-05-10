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

namespace Queries
{
    interface IUserQuery
    {
        List<Station> getStations();

        List<Station> findStation(string fCountry, string fCity);
    }
}
