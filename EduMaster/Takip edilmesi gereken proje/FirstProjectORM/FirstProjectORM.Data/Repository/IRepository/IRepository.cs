using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectORM.Data.Repository.Repository
{
    public interface IRepository<T>where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        //Tek satır veri çekmek için kullanırız amacı şudur eager loding ile birden fazla sql sorgularını direkt olarak
        //çekmek için kullanılır include parametresi ise ilişkili tablolarda veri varsa getirsin yoksa null alsın demek istedik
        //id 1 getir mesela
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

        //Burada ise direkt listeleme yapacağız sql sorgularını hızlı bir şekilde getirmesi için expression func kullandık burada tüm veriler
        //gelir. Eğer gerekli ise ilişkili tablolarda gelir gelmezse null gelir ama arka planda sql sorguları yüklenir.
        //müsteri tablosu full listele gibi
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        void RemoveRange(IEnumerable<T> entities);
        //Bu metodu yazmamızın sebebi ilişkiliş tablolardaki alanlarıda rahatlıkla silebilmek amacı ile yaptık 


    }
}
