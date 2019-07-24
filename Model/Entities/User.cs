using Core.Entity;
using Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public  class User:CoreEntity
    {


        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string MD5Sifre { get; set; }

        public Roles    KullaniciRolu { get; set; }






    }
}
