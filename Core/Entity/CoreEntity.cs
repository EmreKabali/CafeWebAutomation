using Core.Entity.Enums;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class CoreEntity:IEntity<Guid>
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        //Base sınıfımızdır.Class ı tek başına sade bırakmak güvenli olmadığından IEntity interface ini oluşturdum.
        //Ortak propertyler.
        //Düzenleme yapılacak.

        public CoreEntity()
        {
            logger.Debug("Debugging Coreentity");

            this.Statu = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedMachine = Environment.MachineName;
            this.CreatedUser = Environment.UserName;
            this.IsDeleted = IsDeleted.active;
            
            




        }


        public Guid ID { get; set; }
        public Status Statu { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedMachine { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public string CreatedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public string ModifiedMachine { get; set; }
        



    }
}
