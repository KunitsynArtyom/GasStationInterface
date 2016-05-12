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

namespace Queries.TableRepositories
{
    public class StationRepository
    {
        public DBConnection dbc;

        public StationRepository(NpgsqlConnection conn)
        {
            dbc = new DBConnection(conn);
        }

        public List<Station> getStations()
        {
            List<Station> stationList = new List<Station>();
            try
            {

                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]), dbDataRecord["orgname"].ToString(), dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(), dbDataRecord["street"].ToString(), Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
            return stationList;
        }

        public List<Station> findStations(string fCountry, string fCity)
        {
            List<Station> stationList = new List<Station>();
            dbc.openConnection();
            try
            {
                //NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                //    "'%" + fCountry + "%' AND city LIKE" + "'%" + fCity + "%'", dbc.getConnection());
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT * FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                " @fCountry AND city LIKE @fCity ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@fCountry", "%" + fCountry + "%");
                queryCommand.Parameters.AddWithValue("@fCity", "%" + fCity + "%");

                NpgsqlDataReader AZSTableSearcher = queryCommand.ExecuteReader();
                if (AZSTableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableSearcher)
                    {
                        Station st = new Station();
                        st.stationSet(Convert.ToInt32(dbDataRecord["station_id"]),
                            dbDataRecord["orgname"].ToString(),
                            dbDataRecord["country"].ToString(),
                            dbDataRecord["city"].ToString(),
                            dbDataRecord["street"].ToString(),
                            Convert.ToInt32(dbDataRecord["storagecap"]));
                        stationList.Add(st);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }
            return stationList;
        }

        public int FindStationIDByLocation(string location)
        {
            int station_id = 0;
            List<string> splittedLocation = new List<string>();
            string[] split = location.Split(new Char[] { ',' });
            foreach (string s in split)
            {
                splittedLocation.Add(s);
            }
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT station_id FROM \"AZS\".\"GasStation\" WHERE country LIKE" +
                       "@fCountry AND city LIKE @fStreet AND street LIKE" +
                       "@fStreet", dbc.getConnection());

                queryCommand.Parameters.AddWithValue("@fCountry", "%" + splittedLocation[0] + "%");
                queryCommand.Parameters.AddWithValue("@fCity", "%" + splittedLocation[1] + "%");
                queryCommand.Parameters.AddWithValue("@fStreet", "%" + splittedLocation[2] + "%");

                NpgsqlDataReader Station_ID_TableSearcher = queryCommand.ExecuteReader();
                if (Station_ID_TableSearcher.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in Station_ID_TableSearcher)
                    {
                        station_id = Convert.ToInt32(dbDataRecord["station_id"]);
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return station_id;
        }

        public List<string> GetStationsAdres(string Orgname)
        {
            List<string> comboBoxElements = new List<string>();
            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT country, city, street FROM \"AZS\".\"GasStation\" WHERE orgname LIKE @Orgname ", dbc.getConnection());
                queryCommand.Parameters.AddWithValue("@Orgname", "%" + Orgname + "%");
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["country"].ToString() + "," + dbDataRecord["city"].ToString() + "," + dbDataRecord["street"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }

        public List<string> GetOrganisations()
        {
            List<string> comboBoxElements = new List<string>();

            try
            {
                dbc.openConnection();
                NpgsqlCommand queryCommand = new NpgsqlCommand("SELECT DISTINCT orgname FROM \"AZS\".\"GasStation\"", dbc.getConnection());
                NpgsqlDataReader AZSTableReader = queryCommand.ExecuteReader();
                if (AZSTableReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in AZSTableReader)
                    {
                        comboBoxElements.Add(dbDataRecord["orgname"].ToString());
                    }
                }
            }
            catch (NpgsqlException ne)
            {

            }
            finally { dbc.closeConnection(); }

            return comboBoxElements;
        }
    }
}