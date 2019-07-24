using Core.Entity;
using Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Fis:CoreEntity
    {
        public double toplamfiyat { get; set; }
        public int deger { get; set; }
        public OdemeSekli OdemeSekli { get; set; }


    }
}
