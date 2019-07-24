using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class KategoriMap:CoreMap<Kategori>
    {


        public KategoriMap()
        {
            ToTable("Kategori");
            Property(x => x.KategoriAdı).HasMaxLength(50).IsOptional();
            Property(x => x.KategoriAçıklaması).IsOptional();
            Property(x => x.Statüsü).IsOptional();




        }

        
    }
}
