using System.Data.Entity.ModelConfiguration;

namespace CodeFirstIMDB
{
    public class LodgingConfiguration :
            EntityTypeConfiguration<Lodging>
    {
        public LodgingConfiguration()
        {
            Property(l => l.Name).IsRequired().HasMaxLength(200);
        }
    }
}
