using Core.Entity;
using Core.Service;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseClass
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {

        // Singleton pattern i ile DB yi sürekli instance almayı engelleyoruz.

        private static CafeContext _cafecontext;


        public static CafeContext Context
        {


            get

            {
                if (_cafecontext == null)
                {

                    _cafecontext = new CafeContext();

                }

                return _cafecontext;

            }
        }   



        public bool Any(Expression<Func<T, bool>> exp)
        {
            
        }

        public void Ekleme(T item)
        {
            CafeContext.Set<T>.Ekleme(item);
            Kaydet();
        }

        public void EklemeListe(List<T> items)
        {
           
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            
        }

        public T GetById(Guid id)
        {
          
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            
        }

        public List<T> GetirListe()
        {
            
        }

        public void Guncelle(T item)
        {
            
        }

        public int Kaydet()
        {
          
        }

        public void Sil(Guid id)
        {
           
        }

        public void SilListe(Expression<Func<T, bool>> exp)
        {
           
        }
    }
}
