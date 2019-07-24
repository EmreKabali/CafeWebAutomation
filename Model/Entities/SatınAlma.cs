using Core.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class SatınAlma:CoreEntity
    {

        public string SatınAlanAdSoyad { get; set; }
        public string Not { get; set; }
        public DateTime    SatınAlmaTarihi { get; set; }



        
        public Guid UrunId { get; set; }
        //Mapping

        public List<Urun>  Urun { get; set; }





    }
}