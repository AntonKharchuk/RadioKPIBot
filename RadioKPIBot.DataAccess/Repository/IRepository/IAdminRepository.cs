using RadioKPIBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioKPIBot.DataAccess.Repository.IRepository
{  
    public interface IAdminRepository : IRepository<Admin>
    {
        void Update(Admin obj);
    }
}
