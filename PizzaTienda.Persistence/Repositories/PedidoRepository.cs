
using PizzaTienda.Persistence.Context;

namespace PizzaTienda.Persistence.Repositories;
public class PedidoRepository : IPedidos
{
    protected readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Metodos Sincronos
    public int Count()
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Pedido Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pedido> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(Pedido entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Pedido entity)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Metodos Asincronos

    public async Task<bool> InsertAsync(Pedido entity)
    {
        try
        {
            _context.Add(entity);

        }
        catch (Exception ex)
        {

            throw;
        }
        //await _context.SaveChangesAsync();

        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(Pedido pedido)
    {
        var entity = await _context.Set<Pedido>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(pedido.Id));
        if (entity == null)
        {
            return await Task.FromResult(false);
        }

        entity.IdCliente = pedido.IdCliente;
        entity.nombreCliente = pedido.nombreCliente;
        entity.nombreCliente = pedido.nombreCliente;
        entity.direccionCliente = pedido.direccionCliente;
        entity.nitCliente = pedido.nitCliente;
        entity.telefonoCliente = pedido.telefonoCliente;
        entity.idProducto = pedido.idProducto;
        entity.descripcionProducto = pedido.descripcionProducto;
        entity.cantidadProducto = pedido.cantidadProducto;
        entity.PrecioProducto = pedido.PrecioProducto;
        entity.PrecioDelivery = pedido.PrecioDelivery;
        entity.TotalProducto = pedido.TotalProducto;

        entity.estatus = pedido.estatus;
        entity.creadoEl = pedido.creadoEl;
        entity.creadoPor = pedido.creadoPor;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<Pedido>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

        if (entity == null)
        {
            return await Task.FromResult(false);
        }

        _context.Remove(entity);
        return await Task.FromResult(true);
    }

    public async Task<int> CountAsync()
    {
        return await Task.Run(() => 1000);
    }


    public async Task<IEnumerable<Pedido>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Pedido>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Pedido> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.
                Set<Pedido>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    #endregion

}
