using Dapper;
using ShareBaggageServer.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.Location
{
    public class LocationRepository
    {
        public string GetLocation(decimal locX, decimal locY)
        {

            // 1. Get Select Query

            string query = @"
select 
	sp.SellerID,
    sp.LocationType,
    sp.LocationX,
    sp.LocationY,
    sp.Description,
    sp.IsUseLocation,
    sp.RoomSizeX,
    sp.RoomSizeY,
    sp.PlaceNumber,
    sp.TimeStamp,
    sp.RoomID,
    us.usersName,
    ABS(sp.locationX - 3.12) as distunceX, 
    ABS(sp.locationY - 3.11) as distunceY 
from 
	seller_places as sp
		left join
	users as us
    on sp.SellerID = us.usersId
order by 
	distunceX,
    distunceY
";
            query = query.Replace("{locX}", locX.ToString());
            query = query.Replace("{locY}", locY.ToString());


            // 2. Get Mysql Object 
            var connection = MySqlRepository.GetConnetion();
            LocationInfo model = new LocationInfo
            {
                LocationX = locX,
                LocationY = locY
            };

            // 3. Get By Dapper
            var data = connection.Query<LocationInfo>(query, model).ToList();

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


    }
}
