using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.Database
{
    public class MySqlRepository
    {

        public static MySqlConnection GetConnetion()
        {
            string connetionString = GetLocalhost();
            return new MySqlConnection(connetionString);
        }

        private static string GetLocalhost()
        {
            return "Server=54.180.57.230;Database=goodsdb;Uid=root;Pwd=pass";
        }


    }
}
