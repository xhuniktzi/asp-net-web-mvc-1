
using asp_net_web_mvc_1.Contracts;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class BranchRepository : IBranchRepository
    {
        public Branch FindById(int id)
        {
            var url = $"{Properties.Settings.Default.API}/branches/{id}";
            return JsonConvert.DeserializeObject<Branch>(ConnectDatabase.ExecGet(url));
        }

        public IEnumerable<Branch> GetAll()
        {
            var url = $"{Properties.Settings.Default.API}/branches";
            return JsonConvert.DeserializeObject<IEnumerable<Branch>>(ConnectDatabase.ExecGet(url));
        }
    }
}