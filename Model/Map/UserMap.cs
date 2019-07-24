using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class UserMap:CoreMap<User>
    {


        public UserMap()
        {
            ToTable("dbo.User");
            Property(x => x.Adi).HasMaxLength(50).IsOptional();
            Property(x => x.Soyadi).HasMaxLength(50).IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.KullaniciAdi).HasMaxLength(50).IsRequired();
            Property(x => x.Sifre).HasMaxLength(50).IsRequired();
            Property(x => x.MD5Sifre).IsOptional();
            Property(x => x.KullaniciRolu).IsOptional();




        }

    }
}
