using Core.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Adisyon:CoreEntity
    {
        public Guid MasaId { get; set; }
        public int siparis { get; set; }
        public double ToplamFiyat { get; set; }
        public double fiyat2 { get; set; }
        public Guid UrunId { get; set; }




        public virtual Masa Masa { get; set; }
        public virtual List<Urun> Uruns { get; set; }
        public virtual List<Garson> Garsons { get; set; }
       


    }
}