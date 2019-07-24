using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class UrunMap:CoreMap<Urun>
    {
        public UrunMap()
        {
            ToTable("dbo.Urun");
            Property(x => x.Ad).HasMaxLength(50).IsRequired();
            Property(x => x.Acıklama).IsOptional();
            Property(x => x.Resimyolu).IsOptional();
            Property(x => x.Fiyat).IsRequired();
            
            Property(x => x.StokMiktari).IsRequired();


        }

       


    }
}
