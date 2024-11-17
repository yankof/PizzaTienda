namespace PizzaTienda.Application.Interfaces.Persistence;
public interface IUnitOfWork : IDisposable
{
    IComponentes Componentes { get; }
    IPedidos Pedidos { get; }
    IPromocion Promocion { get; }
    IProducto Producto { get; }
    IProductoComponente ProductoComponente { get; }

    Task<int> Save(CancellationToken cancellationToken = default);
}
