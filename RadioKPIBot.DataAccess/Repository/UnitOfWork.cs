using RadioKPIBot.DataAccess.Repository.IRepository;
using RadioKPIBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioKPIBot.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IAdminRepository Admin{ get; private set; }


        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Admin = new AdminRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
