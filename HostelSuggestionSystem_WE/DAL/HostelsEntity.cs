using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HostelSuggestionSystem_WE.Models;


namespace HostelSuggestionSystem_WE.DAL
{
    public class HostelsEntity
    {
        public HostelsEntity()
        {
            connection = new SqlConnection(connString);
        }
        private string connString = ConfigurationManager.ConnectionStrings["weProjectDbEntities"].ConnectionString;
        private SqlConnection connection;
        private string query;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        public DataTable GetHostels()
        {
            DataSet ds = new DataSet();
            query = "SELECT * FROM Hostels";
            cmd = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds,"Hostels");
            builder = new SqlCommandBuilder(adapter);
            return ds.Tables["Hostels"];
        }
        public DataTable GetHostelsByFilter(string filter, string filterBody)
        {
            DataSet ds = new DataSet();
            switch (filter)
            {
                case "Distance":
                    query = "SELECT * FROM Hostels ORDER BY HostelDistance ASC";
                    break;
                case "Rating":
                    query = "SELECT * FROM Hostels ORDER BY HostelRating DSC";
                    break;
                case "City":
                    query = $"SELCT * FROM Hostels WHERE HostelCity LIKE '{filterBody}'";
                    break;
                default:
                    ds = null;
                    break;
            }
            try
            {
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            if (ds != null)
            {
                return ds.Tables["Hostels"];
            }
            return GetHostels();
        }
        public int AddHostels(Hostels hostels)
        {
            DataTable dt = new DataTable();
            dt = GetHostels();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            return adapter.Update(dt);
        }
        public int UpdateHostel(Hostels hostel)
        {
            int rowsAffected = 0;
            query = $"UPDATE Hostels SET" +
                $"HostelName = '{hostel.HostelName}', " +
                $"HostelAddress = '{hostel.HostelAddress}', " +
                $"HostelCity = '{hostel.HostelCity}', " +
                $"HostelDistance = '{hostel.HostelDistance}', " +
                $"HostelRating = '{hostel.HostelRating}', " +
                $"HostelImageUrl = '{hostel.HostelImageUrl}' " +
                $"WHERE HostelId = '{hostel.HostelId}'";
            connection.Open();
            cmd = new SqlCommand(query, connection);
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            connection.Close();
            return rowsAffected;
        }
    }
}