using asp_net_web_mvc_1.Contracts;
using System;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class ClientRepository : IClientRepository
    {
        public Client CreateClient(Client client)
        {
            var url = $"{Properties.Settings.Default.API}/clients";
            var data = JsonConvert.SerializeObject(client);
            var res = ConnectDatabase.ExecPost(url, data, "application/json");
            return JsonConvert.DeserializeObject<Client>(res);
        }

        public void DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Client FindById(int id)
        {
            var url = $"{Properties.Settings.Default.API}/clients/{id}";
            return JsonConvert.DeserializeObject<Client>(ConnectDatabase.ExecGet(url));
        }

        public IEnumerable<Client> GetAll()
        {
            var url = $"{Properties.Settings.Default.API}/clients";
            return JsonConvert.DeserializeObject<IEnumerable<Client>>(ConnectDatabase.ExecGet(url));
        }

        public void UpdateClient(int id, Client client)
        {
            throw new NotImplementedException();
        }
    }
}