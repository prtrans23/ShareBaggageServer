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

    }
}