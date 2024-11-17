namespace PizzaTienda.Application.UseCases.Promocion;
public class PromocionApplication:IPromocionApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public PromocionApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    #region Métodos Asíncronos
    public async Task<Response<bool>> InsertAsync(PromocionDto promocionDto)
    {
        var response = new Response<bool>();
        try
        {
            var promocion = _mapper.Map<PizzaTienda.Domain.Entities.Promocion>(promocionDto);
            response.Data = await _unitOfWork.Promocion.InsertAsync(promocion);

            await _unitOfWork.Save();


            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }
    public async Task<Response<bool>> UpdateAsync(PromocionDto promocionDto)
    {
        var response = new Response<bool>();
        try
        {
            var promocion = _mapper.Map<PizzaTienda.Domain.Entities.Promocion>(promocionDto);
            response.Data = await _unitOfWork.Promocion.UpdateAsync(promocion);
            await _unitOfWork.Save();
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _unitOfWork.Promocion.DeleteAsync(id);
            await _unitOfWork.Save();
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación Exitosa!!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }

    public async Task<Response<PromocionDto>> GetAsync(int id)
    {
        var response = new Response<PromocionDto>();
        try
        {
            var promocion = await _unitOfWork.Promocion.GetAsync(id, CancellationToken.None);
            response.Data = _mapper.Map<PromocionDto>(promocion);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }
    public async Task<Response<IEnumerable<PromocionDto>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<PromocionDto>>();
        try
        {
            var promocion = await _unitOfWork.Promocion.GetAllAsync(CancellationToken.None);
            response.Data = _mapper.Map<IEnumerable<PromocionDto>>(promocion);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }
        return response;
    }

    public async Task<PedidoDto> ExecRulePromotion(PedidoDto pedidoDto)
    {
        IEnumerable<PromocionDto> promocionRes;
        promocionRes = (IEnumerable<PromocionDto>) GetAllAsync().Result.Data;

        var promocionPizzas = promocionRes.Where(x => x.tipo.Equals("1")).FirstOrDefault();
        var promocionDelivery = promocionRes.Where(x => x.tipo.Equals("2")).FirstOrDefault();
        var dia = (int)pedidoDto.creadoEl.DayOfWeek;
        
        if (promocionDelivery != null & (dia == 4))
        {
            pedidoDto.PrecioDelivery = pedidoDto.PrecioDelivery * promocionDelivery.ValorMultiplicador;
            pedidoDto.TotalProducto = (pedidoDto.cantidadProducto * pedidoDto.PrecioProducto) + pedidoDto.PrecioDelivery;

        }
        if (promocionPizzas != null & (dia == 2 | dia == 3))
        {
            pedidoDto.cantidadProducto = pedidoDto.cantidadProducto * promocionPizzas.ValorMultiplicador;
            
        }

        

        return pedidoDto;
    }

    #endregion
}
