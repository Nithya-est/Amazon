using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Amazon.Models
{
    public class Dbconnection
    {
        public List<ItemProperty> dbconnect()//creating method to connect db,we have to
                                             //return the value whch are taken from db so
                                             //that only we have created the itempropery

        {
            List<ItemProperty> items = new List<ItemProperty>();//create obj here for the above list
            string connectionstring = ConfigurationManager.ConnectionStrings["db_customerEntities"].ToString();//get connection string form web config to connect db and mvc
            SqlConnection sqlConnection = new SqlConnection(connectionstring);//we have to pass our connectionstring to the already written class of SqlConnection
            sqlConnection.Open();//the above created object(sqlconnection) will open the cnctn
            string cmd1 = "USE db_customer";//to use db write the db name in this
            string cmd2 = "select price,name,color from item1";//if it runs values will be getted..we have to use sql data reader to read this
            SqlCommand sqlCommand = new SqlCommand(cmd1, sqlConnection);//we have to pass 2parameter  
            SqlCommand sqlCommand1 = new SqlCommand(cmd2, sqlConnection);//we have to store the value in list
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                items.Add(new ItemProperty
                {
                    price = (int)sqlDataReader["price"],
                    name = sqlDataReader["name"].ToString(),
                    color = sqlDataReader["color"].ToString(),
                });

            }
            return items;
        }
    }
}