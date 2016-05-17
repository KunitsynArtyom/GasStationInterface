using System;
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

namespace Queries.TableRepositories
{
    public class SupplyRepository : ISupplyRepository
    {
        public DBConnection dbc;

        public SupplyRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public List<Supply> ShowSupplyTable()
        {
            List<Supply> supplyList = new List<Supply>();
            try
            {
                //dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"Supply\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Supply supply = new Supply();

                        supply.supplySet(Convert.ToInt32(dbDataRecord["station_id"]), Convert.ToInt32(dbDataRecord["staff_id"]),
                            dbDataRecord["fuelsupplytype"].ToString(), Convert.ToInt32(dbDataRecord["fuelsupplyamount"]),
                            Convert.ToDateTime(dbDataRecord["supplydate"].ToString()));
                        supplyList.Add(supply);
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }

            return supplyList;
        }
    }
}
