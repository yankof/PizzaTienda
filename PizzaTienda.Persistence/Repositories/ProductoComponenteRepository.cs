using PizzaTienda.Persistence.Context;

namespace PizzaTienda.Persistence.Repositories;
public class ProductoComponenteRepository : IProductoComponente
{
    protected readonly ApplicationDbContext _context;

    public ProductoComponenteRepository(ApplicationDbContext context)
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

    public ProductoComponente Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductoComponente> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(ProductoComponente entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(ProductoComponente entity)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Metodos Asincronos

    public async Task<bool> InsertAsync(ProductoComponente entity)
    {
        _context.Add(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(ProductoComponente productoComponente)
    {
        var entity = await _context.Set<ProductoComponente>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(productoComponente.Id));
        if (entity == null)
        {
            return await Task.FromResult(false);
        }

        entity.idProducto = productoComponente.idProducto;
        entity.idComponente = productoComponente.idComponente;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<ProductoComponente>()
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


    public async Task<IEnumerable<ProductoComponente>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<ProductoComponente>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<ProductoComponente> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.
                Set<ProductoComponente>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    #endregion
}
