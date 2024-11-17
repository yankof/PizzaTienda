namespace PizzaTienda.Application.Interfaces.UsesCases;
public interface IComponentApplication
{
    #region Métodos Síncronos

    Response<bool> Insert(ComponenteDto componenteDto);
    Response<bool> Update(ComponenteDto componenteDto);
    Response<bool> Delete(int id);

    Response<ComponenteDto> Get(int id);
    Response<IEnumerable<ComponenteDto>> GetAll();
    
    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(ComponenteDto componenteDto);
    Task<Response<bool>> UpdateAsync(ComponenteDto componenteDto);
    Task<Response<bool>> DeleteAsync(int id);

    Task<Response<ComponenteDto>> GetAsync(int id);
    Task<Response<IEnumerable<ComponenteDto>>> GetAllAsync();
    
    #endregion
}
