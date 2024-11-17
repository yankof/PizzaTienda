namespace PizzaTienda.Application.Interfaces.Persistence;
public interface IGenericRepository<T> where T : class
{
    #region Métodos Síncronos

    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(int id);

    T Get(int id);
    IEnumerable<T> GetAll();
    int Count();

    #endregion

    #region Métodos Asíncronos
    Task<bool> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);

    Task<T> GetAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<int> CountAsync();
    #endregion
}
