using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMunicipality.DATA.IRepository
{
    using System.Linq.Expressions;

        public interface IEFRepository<T> where T : class
        {
            void Add(T entity);

            void Update(T entity);

            void Remove(T entity);

            T? GetFirstOrDefault(
                Expression<Func<T, bool>> filter,
                string? includeProperties = null);

            IEnumerable<T> GetAll(
                Expression<Func<T, bool>>? filter = null,
                string? includeProperties = null);

            void RemoveRange(IEnumerable<T> entities);
        }
    }

