using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.model;

namespace WebApplication1.dbConfig;

public class AddressEntityConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("TB_ENDERECO_GE");

        builder.HasKey(e => e.id);
        
        builder.Property(e => e.id).HasColumnName("ID");

        builder.HasOne(e => e.user)
            .WithMany()
            .HasForeignKey("ID_USUARIO")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.street)
            .HasColumnName("LOGRADOURO");

        builder.Property(e => e.neighborhood)
            .HasColumnName("BAIRRO");

        builder.Property(e => e.postalCode)
            .HasColumnName("CEP");

        builder.Property(e => e.city)
            .HasColumnName("CIDADE");
        
        builder.Property(e => e.houseNumber)
            .HasColumnName("NUMERO_RESIDENCIA");

        builder.Property(e => e.localType)
            .HasColumnName("TIPO_LOCAL");


    }
    
    
}