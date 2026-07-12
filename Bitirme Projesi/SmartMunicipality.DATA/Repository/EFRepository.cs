using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::SmartMunicipality.Data;
using global::SmartMunicipality.DATA.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SmartMunicipality.DATA.Repository
{
        public class EFRepository<T> : IEFRepository<T> where T : class
        {
            private readonly ApplicationDbContext _context;

            internal DbSet<T> _dbSet;

            public EFRepository(ApplicationDbContext context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public void Add(T entity)
            {
                _dbSet.Add(entity);
            }

            public IEnumerable<T> GetAll(
                Expression<Func<T, bool>>? filter = null,
                string? includeProperties = null)
            {
                IQueryable<T> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var item in includeProperties
                                 .Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }

                return query.ToList();
            }

            public T? GetFirstOrDefault(
                Expression<Func<T, bool>> filter,
                string? includeProperties = null)
            {
                IQueryable<T> query = _dbSet.Where(filter);

                if (includeProperties != null)
                {
                    foreach (var item in includeProperties
                                 .Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }

                return query.FirstOrDefault();
            }

            public void Remove(T entity)
            {
                _dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entities)
            {
                _dbSet.RemoveRange(entities);
            }

            public void Update(T entity)
            {
                _dbSet.Update(entity);
            }
        }
    }

