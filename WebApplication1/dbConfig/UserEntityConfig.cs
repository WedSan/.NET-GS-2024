using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.model;

namespace WebApplication1.dbConfig;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("TB_USUARIO_GE");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID");


        builder.Property(e => e.Name)
            .HasColumnName("NOME");


        builder.Property(e => e.Email)
            .HasColumnName("EMAIL");

        builder.Property(e => e.Password)
            .HasColumnName("SENHA");

        builder.Property(e => e.Telephone)
            .HasColumnName("TELEFONE");

    }
}