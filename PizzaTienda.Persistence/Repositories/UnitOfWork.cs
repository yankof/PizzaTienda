
using PizzaTienda.Persistence.Context;

namespace PizzaTienda.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public IComponentes Componentes { get; }

    public IPedidos Pedidos { get; }
    
    public IPromocion Promocion {  get; }

    public IProducto Producto { get; }

    public IProductoComponente ProductoComponente { get; }

    private readonly ApplicationDbContext _context;

    public UnitOfWork(IComponentes componentes, IPedidos pedidos, IProducto producto, 
                      IProductoComponente productoComponente, IPromocion promocion, 
                      ApplicationDbContext context)
    {
        Componentes = componentes;
        Pedidos = pedidos;
        Promocion = promocion;
        Producto = producto;
        ProductoComponente = productoComponente;
        _context = context;
        
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }

    public async Task<int> Save(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
