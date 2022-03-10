using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noesis.WeatherMap.Data.Entities;
using System.Web.Mvc;
using System.Text.Json;

namespace Noesis.WeatherMap.Data.Controllers


{
    public class UserController
    {
        public List<User> GetUsers()
        {
            var con = @"Server=NELT1348\MSSQLSERVER01;Database=NoesisWeatherMap;Trusted_Connection=True;";


            SqlConnection myConnection = new SqlConnection(con);
            
            
                
            List<User> userList = new List<User>();
            myConnection.Open();
            SqlCommand command = new SqlCommand("Select * from Users", myConnection);
            using (SqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    User users = new User();
                    users.Id = Convert.ToInt32(Reader["Id"].ToString());
                    users.Name = Reader["Name"].ToString();

                    userList.Add(users);
                }

                myConnection.Close();
            }

           
            return userList;
        }
    }
}
