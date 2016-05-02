﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class Deal
    {
        public int d_deal_id { private set; get; }
        public int d_car_id { private set; get; }
        public int d_station_id { private set; get; }
        public int d_staff_id { private set; get; }
        public string d_fueltype { private set; get; }
        public int d_fuelamount { private set; get; }
        public string d_cardnum { private set; get; }
        public DateTime d_dealdate { private set; get; }

        public void dealSet(int deal_id, int car_id, int station_id, int staff_id, string fueltype, int fuelamount, string cardnum, DateTime dealdate)
        {
            d_deal_id = deal_id;
            d_car_id = car_id;
            d_station_id = station_id;
            d_staff_id = staff_id;
            d_fueltype = fueltype;
            d_fuelamount = fuelamount;
            d_cardnum = cardnum;
            d_dealdate = dealdate;
        }

        public void dealSet(string fueltype, int fuelamount, string cardnum, DateTime dealdate)
        {
            d_fueltype = fueltype;
            d_fuelamount = fuelamount;
            d_cardnum = cardnum;
            d_dealdate = dealdate;
        }

        public int GetDeal_id() => d_deal_id;
        public int GetCar_id() => d_car_id;
        public int GetStation_id() => d_station_id;
        public int GetStaff_id() => d_staff_id;
        public string GetFuelType() => d_fueltype;
        public int GetFuelAmount() => d_fuelamount;
        public string GetCardNum() => d_cardnum;
        public DateTime GetDate() => d_dealdate;
    }
}
