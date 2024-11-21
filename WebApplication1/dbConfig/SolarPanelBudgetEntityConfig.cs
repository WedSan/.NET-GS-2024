using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.model;

namespace WebApplication1.dbConfig;

public class SolarPanelBudgetEntityConfig : IEntityTypeConfiguration<SolarPanelBudget>
{
    public void Configure(EntityTypeBuilder<SolarPanelBudget> builder)
    {
        builder.ToTable("TB_ORCAMENTO_PAINEL_SOLAR_GE");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.HasOne(x => x.address)
            .WithMany()
            .HasForeignKey("ID_ENDERECO")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.investmentCost)
            .HasColumnName("CUSTO_INVESTIMENTO");

        builder.Property(x => x.systemSize)
            .HasColumnName("TAMANHO_SISTEMA");
        
        builder.Property(x => x.amountModules)
            .HasColumnName("NUMERO_MODULOS");

        builder.Property(x => x.estimatedAnnualProduction)
            .HasColumnName("PRODUCAO_ANUAL_ESTIMADA");
    }
}