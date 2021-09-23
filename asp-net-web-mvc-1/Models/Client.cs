using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_web_mvc_1.Models
{
    public class Client
    {
        public int Client_Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public string Phone_Number { get; set; }
        public string Direction { get; set; }
        public string E_Mail { get; set; }
    }
}