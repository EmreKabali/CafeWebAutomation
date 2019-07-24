using Core.Entity;
using Core.Entity.Enums;
using Model.Entities;
using Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class CafeContext : DbContext
    {

        public CafeContext() 
        {
            Database.Connection.ConnectionString = "server=.;database=AustProjectDB;Trusted_Connection=True";
        }


        public DbSet<Adisyon> Adisyons { get; set; }
        
        public DbSet<Garson> Garsons { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Masa> Masas { get; set; }
        public DbSet<SatınAlma> SatınAlmas { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fis> Fis { get; set; }




        //Oluşturduğumuz mapping sınıflarının configüre edildiği alandır.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AdisyonMap());
           
            modelBuilder.Configurations.Add(new GarsonMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MasaMap());
            modelBuilder.Configurations.Add(new SatınAlmaMap());
            modelBuilder.Configurations.Add(new UrunMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new FisMap());

            base.OnModelCreating(modelBuilder);
        }

        //Tekrar Bakılacak Nokta!!

        public override int SaveChanges()
        {

            
            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();

            string user = Environment.UserName;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
           

            foreach (var item in modifierEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item == null)
                {
                    entity.CreatedUser = user;
                    entity.CreatedMachine = computerName;
                    entity.CreatedDate = dateTime;
                   
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedMachine= computerName;
                    entity.ModifiedUser= user;
                   
                }
            }

            return base.SaveChanges();
        }


       

    }
}
