using PizzaTienda.Persistence.Context;

namespace PizzaTienda.Persistence.Repositories;
public class ProductoRepository: IProducto
{
    protected readonly ApplicationDbContext _context;

    public ProductoRepository(ApplicationDbContext context)
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

    public Producto Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Producto> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(Producto entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Producto entity)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Metodos Asincronos

    public async Task<bool> InsertAsync(Producto entity)
    {
        _context.Add(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(Producto producto)
    {
        var entity = await _context.Set<Producto>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(producto.Id));
        if (entity == null)
        {
            return await Task.FromResult(false);
        }

        entity.descripcion = producto.descripcion.ToString();
        entity.abreviacion = producto.abreviacion.ToString();
        entity.estatus = producto.estatus.ToString();
        entity.creadoEl = producto.creadoEl;
        entity.creadoPor = producto.creadoPor;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<Producto>()
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


    public async Task<IEnumerable<Producto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Producto>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Producto> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.
                Set<Producto>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    #endregion

}
