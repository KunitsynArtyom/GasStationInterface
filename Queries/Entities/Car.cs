using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class Car
    {
        protected int b_car_id { set; get; }
        protected string b_carmark { set; get; }
        protected string b_cardnum { set; get; }

        public void buyerSet(int car_id, string carmark, string cardnum)
        {
            b_car_id = car_id;
            b_carmark = carmark;
            b_cardnum = cardnum;
        }

        public int GetCar_id() => b_car_id;
        public string GetCarMark() => b_carmark;
        public string GetCardNum() => b_cardnum;
    }
}
