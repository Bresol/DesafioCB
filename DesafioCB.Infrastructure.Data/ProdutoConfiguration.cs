using DesafioCB.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DesafioCB.Infrastructure.Data
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.IdProduto);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();
        }
    }
}
