using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopContext
{
    class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            ToTable("People");
            HasKey(person => person.PersonKey);
            Property(person => person.PersonKey).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(person => person.FirstName)
                                                    .HasMaxLength(15)
                                                    .IsRequired();

            Property(person => person.LastName)
                                                    .HasMaxLength(15)
                                                    .IsOptional();

            Property(person => person.Age).IsRequired();
            Property(person => person.IsMarried).IsOptional();

            Property(person => person.BirthDate)
                                                    .IsOptional()
                                                    .HasColumnType("datetime2");
        }
    }
}
