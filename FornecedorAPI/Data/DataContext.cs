using Microsoft.EntityFrameworkCore;

namespace FornecedorAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<FornecedorEndereco> FornecedorEnderecos { get; set; }
    }
}
