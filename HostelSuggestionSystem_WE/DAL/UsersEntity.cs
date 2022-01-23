using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HostelSuggestionSystem_WE.Models;

namespace HostelSuggestionSystem_WE.DAL
{
    public class UsersEntity
    {
        public UsersEntity()
        {
            connection = new SqlConnection(connString);
        }
        private string connString = ConfigurationManager.ConnectionStrings["weProjectDbEntities"].ConnectionString;
        private SqlConnection connection;
        private string query;
        private SqlCommand cmd;
        private SqlDataReader reader;
        
        public bool IsValidUser(Users user)
        {
            bool IsValid = false;
            query = $"SELECT * FROM Users WHERE UserName LIKE '{user.UserName}' AND Password LIKE '{user.Password}'";
            cmd = new SqlCommand(query, connection);
            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IsValid = true;
            }
            connection.Close();
            return IsValid;
        }
        public int RegisterUser(Users user)
        {
            int count = 0;
            query = $"INSERT INTO Users VALUES ('{user.UserName}','{user.Password}')";
            cmd = new SqlCommand(query,connection);
            connection.Open();
            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                count = 0;
            }
            return count;
        }
    }
}