using asp_net_web_mvc_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asp_net_web_mvc_1.Contracts
{
    interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client FindById(int id);
        Client CreateClient(Client client);
        void DeleteClient(int id);
        void UpdateClient(int id, Client client);
    }
}
