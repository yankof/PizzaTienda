namespace PizzaTienda.Application.Interfaces.UsesCases;
public interface IProductoComponenteApplication
{
    #region Métodos Síncronos

    Response<bool> Insert(ProductoComponenteDto productoComponenteDto);
    Response<bool> Update(ProductoComponenteDto productoComponenteDto);
    Response<bool> Delete(int id);

    Response<ProductoComponenteDto> Get(int id);
    Response<IEnumerable<ProductoComponenteDto>> GetAll();

    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(ProductoComponenteDto productoComponenteDto);
    Task<Response<bool>> UpdateAsync(ProductoComponenteDto productoComponenteDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<ProductoComponenteDto>> GetAsync(int id);
    Task<Response<IEnumerable<ProductoComponenteDto>>> GetAllAsync();

    #endregion
}
