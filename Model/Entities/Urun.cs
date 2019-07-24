using Core.Entity;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Urun:CoreEntity
    {

        
      
       
        

        public string Ad { get; set; }
        public string Acıklama { get; set; }
        public string Resimyolu { get; set; }
        public Guid KategoriId { get; set; } // Kaldırılacak
        public double Fiyat { get; set; }
        //Yeni EKlendi
        public int StokMiktari { get; set; }
        

        //Mapping


        public virtual Kategori Kategori { get; set; }
        
        



    }
}