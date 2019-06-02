using Dapper;
using ShareBaggageServer.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.AndLogin
{
    public class AccountRepository
    {

        public UserModel FindAccountInfo(string id, string password)
        {
            // 1. Get Select Query
            var query = "SELECT * FROM users WHERE UsersId = @UsersId And UsersId = @UsersPw";

            // 2. Get Mysql Object 
            var connection = MySqlRepository.GetConnetion();
            var serachModel = new SighInModel {  UsersId = id, UsersPw = password };

            // 3. Get By Dapper
            var data = connection.Query<UserModel>(query, serachModel).FirstOrDefault();

            return data;
        }

   

    }
}
