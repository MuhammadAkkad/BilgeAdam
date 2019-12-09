using System.Data.Entity.ModelConfiguration;

namespace CodeFirstIMDB
{
    public class DestinationConfiguration :
       EntityTypeConfiguration<Destination>
    {
        public DestinationConfiguration()
        {

            Property(d => d.Name).IsRequired();
            Property(d => d.Description).HasMaxLength(500).HasColumnType("TEXT");
            Property(d => d.Photo).HasColumnType("image");
 

            /*
             if you try to set the
            data type of a String to a database int, at runtime the DbModelBuilder will throw an
            error saying Member Mapping specified is not valid,
             */
        }
    }
}
