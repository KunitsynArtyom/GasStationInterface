using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class Account
    {
        public int a_account_id { private set; get; }
        public int a_station_id { private set; get; }
        public int a_staff_id { private set; get; }
        public string a_fuelaccounttype { private set; get; }
        public int a_fuelaccountamount { private set; get; }
        public DateTime a_accountdate { private set; get; }

        public void accountSet(int account_id, int station_id, int staff_id, string fuelaccounttype, int fuelaccountamount, DateTime accountdate)
        {
            a_account_id = account_id;
            a_station_id = station_id;
            a_staff_id = station_id;
            a_fuelaccounttype = fuelaccounttype;
            a_fuelaccountamount = fuelaccountamount;
            a_accountdate = accountdate;
        }

        public int GetAccount_id() => a_account_id;
        public int GetStation_id() => a_station_id;
        public int GetStaff_id() => a_staff_id;
        public string GetFuelAccountType() => a_fuelaccounttype;
        public int GetFuelAccountAmount() => a_fuelaccountamount;
        public DateTime GetAccountDate() => a_accountdate;
    }
}
