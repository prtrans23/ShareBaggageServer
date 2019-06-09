using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.Location
{
    public class SellerLIst
    {
        public string CustomerID { get; set; }
        public string usersName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GoodsSize { get; set; }
        public string Money { get; set; }

    }
}
