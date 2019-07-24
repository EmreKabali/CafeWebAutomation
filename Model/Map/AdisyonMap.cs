using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class AdisyonMap:CoreMap<Adisyon>
    {

        public AdisyonMap()
        {
            ToTable("dbo.Adisyon");
            Property(x => x.fiyat2).IsOptional();
            Property(x => x.ToplamFiyat).IsOptional();
            
           

        }


        
    }
}
