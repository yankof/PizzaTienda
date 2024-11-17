using System;
using System.Collections.Generic;
namespace PizzaTienda.Persistence.Repositories;
public class PromocionRepository : IPromocion
{
    protected readonly ApplicationDbContext _context;

    public PromocionRepository(ApplicationDbContext context)
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

    public Promocion Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Promocion> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(Promocion entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Promocion entity)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Metodos Asincronos

    public async Task<bool> InsertAsync(Promocion entity)
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

    public async Task<bool> UpdateAsync(Promocion promocion)
    {
        var entity = await _context.Set<Promocion>().AsNoTracking().SingleOrDefaultAsync(x => x.IdPromocion.Equals(promocion.IdPromocion));
        if (entity == null)
        {
            return await Task.FromResult(false);
        }

        entity.IdPromocion = promocion.IdPromocion;
        entity.Nombre = promocion.Nombre;
        entity.tipo = promocion.tipo;
        entity.ValorMultiplicador = promocion.ValorMultiplicador;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<Promocion>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.IdPromocion.Equals(id));

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


    public async Task<IEnumerable<Promocion>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Promocion>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Promocion> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.
                Set<Promocion>().AsNoTracking().
                SingleOrDefaultAsync(x => x.IdPromocion.Equals(id), cancellationToken);
    }

    #endregion
}
