using Core.Entity;
using Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Masa:CoreEntity
    {
        [Required(ErrorMessage ="DENEME")]
        public string Not { get; set; }
        public Status status { get; set; }
        public Guid AdisyonId { get; set; }

        public virtual List<Adisyon> Adisyons { get; set; }


    }
}
