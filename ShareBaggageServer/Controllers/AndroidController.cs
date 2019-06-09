using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareBaggageServer.Models.AndLogin;
using ShareBaggageServer.Models.Location;

namespace ShareBaggageServer.Controllers
{
    public class AndroidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Login(string id, string password)
        {
            AccountRepository _repository = new AccountRepository();
          
            try
            {
                var data = _repository.FindAccountInfo(id, password);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch(Exception e)
            {
                var obj = new { type = "Loginfail" , error = e.Message };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }

        }

        public string GetLocationData(decimal x = 0, decimal y = 0)
        {
            var _repository = new LocationRepository();
            return _repository.GetLocation(x, y);
        }

        public string CustomerApply(int placeNumber, string customerID, int x, int y, int z, DateTime startDate, DateTime endDate)
        {
            var _repository = new LocationRepository();

            try
            {
                _repository.UpdateRoomDisable(placeNumber);

                _repository.MakeReservation(placeNumber, customerID, x, y, z, startDate, endDate);
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return "OK";
        }


        public IActionResult DaumApi()
        {
            Response.ContentType = "text/html";

            return View();
        }


        public string GetCustomerGoodsList(string userId)
        {

            var _repository = new LocationRepository();

            try
            {
                return _repository.GetCustomerList(userId);
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }

        public string GetSellerGoodsList(string sellerId)
        {

            var _repository = new LocationRepository();

            try
            {
                return _repository.GetSellerList(sellerId);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


    }
}