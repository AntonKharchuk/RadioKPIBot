using RadioKPIBot.DataAccess.Repository.IRepository;
using RadioKPIBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioKPIBot.DataAccess.Repository
{
   
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private AppDbContext _db;

        public AdminRepository(AppDbContext db) : base(db)  
        {
            _db = db;
        }

        public void Update(Admin obj)
        {
            _db.UserData.Update(obj);
        }
    }
}
