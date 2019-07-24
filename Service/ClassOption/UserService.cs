using Model.Entities;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ClassOption
{
    public class UserService:BaseService<User>
    {
       

        /// <summary>
        /// Db de kullanıcı kontrolünü sağlayan method(Linq Expression)
        /// </summary>

        public bool Kullanicikontrol(string kullanicimail,string sifre)
        {
            
            return Any(x => x.Email == kullanicimail && x.Sifre == sifre);

        }

        public User FindByUserName(string mail,string sifre)
        {
            return GetByDefault(x => x.Email==mail&& x.Sifre==sifre);
        }





    }
}
