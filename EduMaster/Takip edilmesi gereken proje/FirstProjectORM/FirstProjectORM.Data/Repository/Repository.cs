using FirstProjectORM.Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbset;

        public Repository(ApplicationDbContext context)
        {
            _context= context;
            _dbset= _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {

                query = query.Where(filter);

            }
            if (includeProperties != null)
            {

                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(item);

                }

            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {

                query = query.Where(filter);

            }
            if (includeProperties != null)
            {

                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(item);

                }

            }

            return query.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        void IRepository<T>.Remove(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}
