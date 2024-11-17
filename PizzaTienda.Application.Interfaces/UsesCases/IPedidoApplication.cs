namespace PizzaTienda.Application.Interfaces.UsesCases;
public interface IPedidoApplication
{
    #region Métodos Síncronos

    Response<bool> Insert(PedidoDto pedidoDto);
    Response<bool> Update(PedidoDto pedidoDto);
    Response<bool> Delete(int id);

    Response<PedidoDto> Get(int id);
    Response<IEnumerable<PedidoDto>> GetAll();

    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(PedidoDto pedidoDto);
    Task<Response<bool>> UpdateAsync(PedidoDto pedidoDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<PedidoDto>> GetAsync(int id);
    Task<Response<IEnumerable<PedidoDto>>> GetAllAsync();

    #endregion
}
