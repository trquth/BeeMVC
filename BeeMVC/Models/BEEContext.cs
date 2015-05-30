using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeeMVC.Models.Mapping;

namespace BeeMVC.Models
{
    public partial class BEEContext : DbContext
    {
        static BEEContext()
        {
            Database.SetInitializer<BEEContext>(null);
        }

        public BEEContext()
            : base("Name=BEEContext")
        {
        }

        public DbSet<BeeData> BeeDatas { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BeeDataMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
