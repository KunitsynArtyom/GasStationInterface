﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class Account
    {
        public string a_station_adres;
        public int a_station_id { private set; get; }
        public string a_fuelaccounttype { private set; get; }
        public int a_fuelaccountamount { private set; get; }
        public DateTime a_accountdate { private set; get; }

        public void accountSet(int station_id, string station_adres, string fuelaccounttype, int fuelaccountamount, DateTime accountdate)
        {
            a_station_id = station_id;
            a_station_adres = station_adres;
            a_fuelaccounttype = fuelaccounttype;
            a_fuelaccountamount = fuelaccountamount;
            a_accountdate = accountdate;
        }

        public int GetStation_id() => a_station_id;
        public string GetStationAdres() => a_station_adres;
        public string GetFuelAccountType() => a_fuelaccounttype;
        public int GetFuelAccountAmount() => a_fuelaccountamount;
        public DateTime GetAccountDate() => a_accountdate;
    }
}
