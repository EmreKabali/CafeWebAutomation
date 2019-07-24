using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class SatınAlmaMap:CoreMap<SatınAlma>
    {

        public SatınAlmaMap()
        {
            ToTable("dbo.SatınAlma");
            Property(x => x.SatınAlanAdSoyad).HasMaxLength(50).IsRequired();
            Property(x => x.Not).IsOptional();
            Property(x => x.SatınAlmaTarihi).IsRequired();



        }


       
    }
}
