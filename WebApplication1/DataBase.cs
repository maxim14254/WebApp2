using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;


namespace WebApplication1
{
    public class DataBase
    {
        string email;
        string name;
        string familia;
        string telephone;
        string id;
        public DataBase(string email = null, string name = null, string familia = null, string telephone = null, string id = null)
        {
            this.email = email;
            this.name = name;
            this.familia = familia;
            this.telephone = telephone;
            this.id = id;
        }

        public string CreateBase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
            string connectionString2 = ConfigurationManager.ConnectionStrings["DataConnection2"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString2))
                {
                    connection.Open();
                    if (Proverka(email, connection) == null)
                    {
                        string str = $"INSERT INTO Users (Name, Familia, Email, Telephone) VALUES (N'{name}', N'{familia}', N'{email}', N'{telephone}')";
                        SqlCommand myCommand = new SqlCommand(str, connection);
                        int e = myCommand.ExecuteNonQuery();      
                        return "Данные успешно добавлены";
                    }
                    else
                    {
                        return "Пользователь с таким E-Mail уже есть";
                    }
                }
            }
            catch
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    connection.Open();

                    string str = $"CREATE DATABASE MyDatabase ON PRIMARY (NAME = MyDatabase_Data, FILENAME = '{path}MyDatabase.mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) LOG ON (NAME = MyDatabase_Log, FILENAME = '{path}MyDatabaseLog.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
                    SqlCommand myCommand = new SqlCommand(str, connection);
                    myCommand.ExecuteNonQuery();

                    str = "USE [MyDatabase] CREATE TABLE Users(ID INT IDENTITY(1,1) NOT NULL, Name NVARCHAR(20) NOT NULL, Familia NVARCHAR(20) NOT NULL, Email NVARCHAR(20) NOT NULL, Telephone NVARCHAR(20) NOT NULL, PRIMARY KEY(ID))";
                    myCommand = new SqlCommand(str, connection);
                    myCommand.ExecuteNonQuery();

                    str = $"INSERT INTO Users (Name, Familia, Email, Telephone) VALUES (N'{name}', N'{familia}', N'{email}', N'{telephone}')";
                    myCommand = new SqlCommand(str, connection);
                    myCommand.ExecuteNonQuery();
                }
                return "Данные успешно добавлены";
            }

        }
        public List<ModelUser> GetUsers()
        {
            List<ModelUser> Users = new List<ModelUser>();
            string connectionString2 = ConfigurationManager.ConnectionStrings["DataConnection2"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString2))
                {
                    connection.Open();
                    string str = "SELECT * FROM Users";
                    SqlCommand myCommand = new SqlCommand(str, connection);
                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Users.Add(new ModelUser { Id = (int)reader.GetValue(0), Name = (string)reader.GetValue(1), Familia = (string)reader.GetValue(2), Email = (string)reader.GetValue(3), Telephone = (string)reader.GetValue(4) });
                        }
                    }
                    reader.Close();
                }
            }
            catch(System.Data.SqlClient.SqlException) { }
            return Users;
        }
        public void DeleteUser()
        {
            string connectionString2 = ConfigurationManager.ConnectionStrings["DataConnection2"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                connection.Open();
                string str = $"DELETE FROM Users WHERE Email = N'{email}'";
                SqlCommand myCommand = new SqlCommand(str, connection);
                myCommand.ExecuteNonQuery();
            }
        }
        public void EditUser()
        {
            string connectionString2 = ConfigurationManager.ConnectionStrings["DataConnection2"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                connection.Open();
                string str = $"UPDATE Users SET Name = N'{name}', Email = N'{email}', Familia = N'{familia}', Telephone = N'{telephone}' WHERE ID = '{id}'";
                SqlCommand myCommand = new SqlCommand(str, connection);
                myCommand.ExecuteNonQuery();
            }
        }

        public object Proverka(string email, SqlConnection connection)
        {
            string str = $"SELECT id FROM Users WHERE Email='{email}'";
            SqlCommand myCommand = new SqlCommand(str, connection);
            var e = myCommand.ExecuteScalar();
            return e;
        }
    }
}
