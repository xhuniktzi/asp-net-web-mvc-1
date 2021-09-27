
using asp_net_web_mvc_1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class BranchRepository : IBranchRepository
    {
        public IEnumerable<Branch> GetAll()
        {
            var url = $"{Properties.Settings.Default.API}/branches";
            return JsonConvert.DeserializeObject<IEnumerable<Branch>>(ConnectDatabase.ExecGet(url));
        }
    }
}