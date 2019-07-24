using Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map
{
   public  class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {


        //Validasyon işlemlerini yaparız
        //Coreentity base sınıfımın validasyon işlemleri
        public CoreMap()
        {

            Property(x => x.ID).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedMachine).HasColumnName("CreatedMachine");
            Property(x => x.CreatedUser).HasColumnName("CreatedUser");
            //Örnek denemeler için createddate ve statuleri şimdilik IsOptional yaptım /Değiştirelecek
            Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedMachine).HasColumnName("ModifiedMachine").IsOptional();
            Property(x => x.ModifiedUser).HasColumnName("ModifiedUser").IsOptional();
            Property(x => x.Statu).HasColumnName("Statu");



        }




    }
}
