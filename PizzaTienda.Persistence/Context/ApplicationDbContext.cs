using PizzaTienda.Domain.Entities;

namespace PizzaTienda.Persistence.Context;
public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
    {
        
    }

    public DbSet<Componentes> Componentes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ProductoComponente> ProductoComponentes { get; set; }
    public DbSet<Promocion> promocions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Componentes>().ToTable("Componentes");
        modelBuilder.Entity<Pedido>().ToTable("Pedido");
        modelBuilder.Entity<Producto>().ToTable("Producto");
        modelBuilder.Entity<ProductoComponente>().ToTable("ProductoComponente");
        modelBuilder.Entity<Promocion>().ToTable("Promocion");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
