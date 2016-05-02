using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Entities
{
    public class Worker
    {
        protected int w_staff_id { set; get; }
        protected int w_station_id { set; get; }
        protected string w_surname { set; get; }
        protected string w_name { set; get; }
        protected string w_gender { set; get; }
        protected DateTime w_birthdate { set; get; }
        protected string w_function { set; get; }
        protected int w_manager { set; get; }
        protected int w_salary { set; get; }

        public void workerSet(int staff_id, int station_id, string surname, string name, string gender, DateTime birthdate, string function, int manager, int salary)
        {
            w_staff_id = staff_id;
            w_station_id = station_id;
            w_surname = surname;
            w_name = name;
            w_gender = gender;
            w_birthdate = birthdate;
            w_function = function;
            w_manager = manager;
            w_salary = salary;
        }

        public void workerSet(string surname, string name, string gender, DateTime birthdate, string function, int manager, int salary)
        {
            w_surname = surname;
            w_name = name;
            w_gender = gender;
            w_birthdate = birthdate;
            w_function = function;
            w_manager = manager;
            w_salary = salary;
        }

        public int GetStaff_id() => w_staff_id;
        public int GetStation_id() => w_station_id;
        public string GetSurname() => w_surname;
        public string GetName() => w_name;
        public string GetGender() => w_gender;
        public DateTime GetBirthdate() => w_birthdate;
        public string GetFunction() => w_function;
        public int GetManager() => w_manager;
        public int GetSalary() => w_salary;
    }
}
