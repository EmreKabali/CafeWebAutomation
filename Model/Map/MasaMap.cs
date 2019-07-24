using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class MasaMap:CoreMap<Masa>
    {


        public MasaMap()
        {

            ToTable("dbo.Masa");
            Property(x => x.Not).IsOptional();
            Property(x => x.status).IsOptional();


        }

    }
}
