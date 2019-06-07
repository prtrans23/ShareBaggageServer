using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.Location
{
    public class LocationInfo
    {
        public string SellerID { get; set; }
        public string LocationType { get; set; }
        public string SellerAddress { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public string Description { get; set; }
        public bool IsUseLocation { get; set; }
        public decimal RoomSizeX { get; set; }
        public decimal RoomSizeY { get; set; }
        public int PlaceNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public int RoomID { get; set; }
        public decimal distunceX { get; set; }
        public decimal distunceY { get; set; }

    }
}
