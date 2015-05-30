using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeeMVC.Models.Mapping
{
    public class BeeDataMap : EntityTypeConfiguration<BeeData>
    {
        public BeeDataMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BeeName)
                .HasMaxLength(50);

            this.Property(t => t.Dead)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("BeeData");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BeeName).HasColumnName("BeeName");
            this.Property(t => t.Health).HasColumnName("Health");
            this.Property(t => t.Dead).HasColumnName("Dead");
        }
    }
}
