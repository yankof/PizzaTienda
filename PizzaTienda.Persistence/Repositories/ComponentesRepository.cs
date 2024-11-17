using PizzaTienda.Persistence.Context;
using System.Threading;

namespace PizzaTienda.Persistence.Repositories;
public class ComponentesRepository : IComponentes
{
    protected readonly ApplicationDbContext _context;

    public ComponentesRepository(ApplicationDbContext context)
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

    public Componentes Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Componentes> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(Componentes entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Componentes entity)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Metodos Asincronos

    public async Task<bool> InsertAsync(Componentes entity)
    {
        _context.Add(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(Componentes componente)
    {
        var entity = await _context.Set<Componentes>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(componente.Id));
        if (entity == null)
        {
            return await Task.FromResult(false);
        }
        entity.Descripcion = componente.Descripcion;
        entity.tipo = componente.tipo;
        entity.estatus = componente.estatus;
        entity.creadoEl = componente.creadoEl;
        entity.creadoPor = componente.creadoPor;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<Componentes>()
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

    
    public async Task<IEnumerable<Componentes>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Componentes>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Componentes> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.
                Set<Componentes>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    #endregion

}
