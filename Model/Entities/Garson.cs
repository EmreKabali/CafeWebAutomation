using Core.Entity;
using System;

namespace Model.Entities
{
    public class Garson:CoreEntity
    {

        public string Ad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime Dogumtarihi { get; set; }
        public Guid  AdisyonId { get; set; }


        //Mapping

        public virtual Adisyon Adisyon { get; set; }


    }
}