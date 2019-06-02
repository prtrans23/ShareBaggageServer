using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBaggageServer.Models.AndLogin
{
    public class UserModel
    {
        public string usersId { get; set; }
        public string usersPw { get; set; }
        public string usersName { get; set; }
        public string usersNum { get; set; }
        public string usersAddr { get; set; }
        public string usersKinds { get; set; }
    }
}
