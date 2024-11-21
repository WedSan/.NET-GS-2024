using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.model;

namespace WebApplication1.dbConfig;

public class EletricityHistoryEntityConfig : IEntityTypeConfiguration<EletricityHistory>
{
    public void Configure(EntityTypeBuilder<EletricityHistory> builder)
    {
        builder.ToTable("TB_HISTORICO_ENERGIA_ELETRICA_GE");

        builder.HasKey(x => x.id);
        
        builder.Property(x => x.id)
            .HasColumnName("ID");

        builder.HasOne(x => x.address)
            .WithMany()
            .HasForeignKey("ID_ENDERECO")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.eletricityConsumption)
            .HasColumnName("CONSUMO");
        
        builder.Property(x => x.unitMeasurement)
            .HasColumnName("UNIDADE_MEDIDA");
        
        builder.Property(x => x.registrationDate)
            .HasColumnName("DATA_REGISTRO");
        
        builder.Property(x => x.cost)
            .HasColumnName("CUSTO");
    }
}