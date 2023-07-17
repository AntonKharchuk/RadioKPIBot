using RadioKPIBot.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RadioKPIBot.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext _db;

        internal DbSet<T> _dbSet;

        public Repository(AppDbContext db, string? includeProps = null)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> quary = _dbSet;
            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    quary = quary.Include(item);
                }
            }

            return quary.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> quary = _dbSet;
            quary = quary.Where(filter);
            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    quary = quary.Include(item);
                }
            }

            return quary.FirstOrDefault();

        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
