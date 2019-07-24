using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICoreService<T> where T:Entity.CoreEntity
    {

        //CRUD vb diğer işlemlerimizi yapacağımız methodların generic olması için oluşturdugum interface
        //T -  Generic tip alması

            //Buradan implement edeceğiz




        void Add(T item);
        void Add(List<T> items);


        void Update(T item);
        void Remove(Guid id);

        void RemoveAll(Expression<Func<T, bool>> exp);

        T GetById(Guid id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetirListe();    // T ile başlayanlardan sonrakiler geri dönüş Tip leridir .

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);
        int Save();




    }
}
