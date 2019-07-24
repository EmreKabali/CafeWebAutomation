using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class GarsonMap:CoreMap<Garson>
    {

        public GarsonMap()
        {
            ToTable("dbo.Garsons");
            Property(x => x.Ad).HasMaxLength(50);
            Property(x => x.Yas).IsOptional();
            Property(x => x.Cinsiyet).IsRequired();
            Property(x => x.Dogumtarihi).HasColumnType("datetime2").IsOptional();


        }
        

    }
}
