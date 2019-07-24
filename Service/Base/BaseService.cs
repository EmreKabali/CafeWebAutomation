using Core.Entity;
using Core.Service;
using Model.Context;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Singleton Pattern
        //DB' yi bir çok kez instance işleminden kurtardık(kazanç=performans+zaman)
        private  static CafeContext _context;

        public static CafeContext Context
        {

            get
            {
                if (_context==null)
                {

                    _context = new CafeContext();
                }

                return _context;

            }



        }

        //Ekleme
        /// <summary>
        /// İtem Ekleme(Tek)
        /// </summary>
       
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Save();
        }
        


        //List

        /// <summary>
        /// İtem liste ekleme
        /// </summary>
                
        public void Add(List<T> items)
        {
            Context.Set<T>().AddRange(items);
            Save();
        }


        /// <summary>
        /// Kayıt varmı yokmu return=true-false(Linq expression)
        /// </summary>
        

        public bool Any(Expression<Func<T, bool>> exp)=>
        
            Context.Set<T>().Any(exp);
        

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).FirstOrDefault();
        }


        /// <summary>
        /// ID ye göre bulma Find(get)
        /// </summary>
       
        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }



        /// <summary>
        /// Liste olarak getirme (Linq Expression)
        /// </summary>
        
        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).ToList();
        }



        /// <summary>
        /// Liste olarak getirme (Statüsü Active olanlar)
        /// </summary>
        
        public List<T> GetirListe()
        {
            ///İs deleted active olanları getiriyoruz verielr silinmesin diye
            return Context.Set<T>().Where(x => x.IsDeleted == Core.Entity.Enums.IsDeleted.active).ToList();
        }


        /// <summary>
        /// Id ye göre Silme İşlemi
        /// </summary>
        
        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.IsDeleted = Core.Entity.Enums.IsDeleted.delete;
            Update(item);
        }


        /// <summary>
        /// Database den komple silme durumlarında kullanılacak
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {

            T item = GetById(id);
            Context.Set<T>().Remove(item);
            Save();

        }

        /// <summary>
        /// Liste olarak Silme (Statüsü Deleted olanlar)
        /// </summary>
       
        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.IsDeleted = Core.Entity.Enums.IsDeleted.delete;
                Update(item);

            }
        }


        /// <summary>
        /// Kaydetme işlemi SaveChanges (return int)
        /// </summary>
        
        public int Save()
        {
            return Context.SaveChanges();
        }


        /// <summary>
        /// ID ye göre güncelleme CurrentValueSet
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = Context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        //Not:Service methodları DBSet ten miras aldıgı icin turkce method isimlerini  kabul etmedi .


    }
}
