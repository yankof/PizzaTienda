namespace PizzaTienda.Application.Interfaces.UsesCases;
public interface IProductoApplication
{
    #region Métodos Síncronos

    Response<bool> Insert(ProductoDto productoDto);
    Response<bool> Update(ProductoDto productoDto);
    Response<bool> Delete(int id);

    Response<ProductoDto> Get(int id);
    Response<IEnumerable<ProductoDto>> GetAll();

    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(ProductoDto productoDto);
    Task<Response<bool>> UpdateAsync(ProductoDto productoDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<ProductoDto>> GetAsync(int id);
    Task<Response<IEnumerable<ProductoDto>>> GetAllAsync();

    #endregion
}
