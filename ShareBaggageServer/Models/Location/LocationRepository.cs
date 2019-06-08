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
    us.usersName as UsersName,
    ABS(sp.locationX - {locX}) as distunceX, 
    ABS(sp.locationY - {locY}) as distunceY 
from 
	seller_places as sp
		left join
	users as us
    on sp.SellerID = us.usersId
where
    sp.IsUseLocation = 1
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


        public void UpdateRoomDisable(int placeNumber)
        {
            // 1. Get Insert Query
            var query = @"
UPDATE 
	seller_places
SET
	IsUseLocation = 0
WHERE 
	PlaceNumber = {PlaceNumber} ;
";
            query = query.Replace("{PlaceNumber}", placeNumber.ToString());


            // 2. Get Mysql Object 
            var connection = MySqlRepository.GetConnetion();


            // 3. Set By Dapper
            connection.Execute(query);
        }

        public string GetSellerByPlacenumber(int placeNumber)
        {
            var query = @"
select 
	SellerID
from 
	seller_places
where
    RoomID = @RoomID
";

            // 2. Get Mysql Object 
            var connection = MySqlRepository.GetConnetion();


            // 3. Get By Dapper
            var data = connection.Query<string>(query, new { RoomID = placeNumber}).FirstOrDefault();

            return data;
        }


        public void MakeReservation(int placeNumber, string customerID, int x, int y, int z, DateTime startDate, DateTime endDate)
        {

            // before Get
            string sellerID = GetSellerByPlacenumber(placeNumber);
            
            //

            var query = @"
INSERT INTO `customer_reservation`
(`ReservationID`,
`RoomID`,
`SellerID`,
`CustomerID`,
`sizeX`,
`sizeY`,
`sizeZ`,
`StartDate`,
`EndDate`,
`IsAccectReservation`)
VALUES
(
NULL,
@SellerID,
@RoomID,
@CustomerID,
@sizeX,
@sizeY,
@sizeZ,
@StartDate,
@EndDate,
@IsAccectReservation);
";

            var obj = new
            {
                RoomID = placeNumber,
                SellerID = sellerID,
                CustomerID = customerID,
                sizeX = x,
                sizeY = y,
                sizeZ = z,
                StartDate = startDate,
                EndDate = endDate,
                IsAccectReservation = 0
            };


            // 2. Get Mysql Object 
            var connection = MySqlRepository.GetConnetion();


            // 3. Get By Dapper
            connection.Execute(query, obj);
        }
    }
}
