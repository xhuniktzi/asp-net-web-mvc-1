using asp_net_web_mvc_1.Models;
using System.Collections.Generic;

namespace asp_net_web_mvc_1.Contracts
{
    interface IBranchRepository
    {
        IEnumerable<Branch> GetAll();
        Branch FindById(int id);
    }
}
