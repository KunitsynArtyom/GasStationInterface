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

namespace Queries.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private DBConnection dbc;

        public AccountRepository(DBConnection dbc)
        {
            this.dbc = dbc;
        }

        public void Dispose()
        {

        }

        public List<Account> GetAccounting()
        {
            List<Account> dgvElements = new List<Account>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT  * FROM \"AZS\".\"Accounting\" ORDER BY accountdate", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Account account = new Account();
                        account.accountSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["station_adres"].ToString(), dbDataRecord["accountrole"].ToString(),
                            dbDataRecord["fuelaccounttype"].ToString(), Convert.ToInt32(dbDataRecord["fuelaccountamount"]),
                            Convert.ToDateTime(dbDataRecord["accountdate"].ToString()));
                        dgvElements.Add(account);
                    }
                }
                AZSTableReader.Close();
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return dgvElements;
        }
    }
}
