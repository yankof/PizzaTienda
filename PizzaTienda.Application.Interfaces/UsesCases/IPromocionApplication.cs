
namespace PizzaTienda.Application.Interfaces.UsesCases;
public interface IPromocionApplication
{
    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(PromocionDto promocionDto);
    Task<Response<bool>> UpdateAsync(PromocionDto promocionDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<PromocionDto>> GetAsync(int id);
    Task<Response<IEnumerable<PromocionDto>>> GetAllAsync();


    Task<PedidoDto> ExecRulePromotion(PedidoDto pedidoDto);

    #endregion
}
