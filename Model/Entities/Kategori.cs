using Core.Entity;
using Core.Entity.Enums;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Kategori:CoreEntity
    {

        public string KategoriAdı { get; set; }
        public string KategoriAçıklaması { get; set; }
        public Status    Statüsü { get; set; } // Kaldırılacak COre katmanında statu veriyoruz


        public virtual List<Urun> Uruns { get; set; }



    }
}