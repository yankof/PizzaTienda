using PizzaTienda.Application.DTO;
using PizzaTienda.Application.Interfaces.UsesCases;
using System.Text.Json;
using System.Text;
using PizzaTienda.Domain.Entities;

namespace PizzaTienda.Application.UseCases.Pedido;
public class PedidoApplication : IPedidoApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPromocionApplication _promocion;
    //private readonly IAppLogger<CustomersApplication> _logger;
    public PedidoApplication(IUnitOfWork unitOfWork, IMapper mapper, IPromocionApplication promocion)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _promocion = promocion;
    }

    #region Métodos Síncronos

    public Response<bool> Insert(PedidoDto pedidoDto)
    {
        var response = new Response<bool>();
        try
        {
            var pedido = _mapper.Map<PizzaTienda.Domain.Entities.Pedido>(pedidoDto);
            response.Data = _unitOfWork.Pedidos.Insert(pedido);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!!";
            }
        }
        catch (Exception e)
        {
            //throw new Exception(e.Message);
            response.Message = e.Message;
        }
        return response;
    }

    public Response<bool> Update(PedidoDto pedidoDto)
    {
        var response = new Response<bool>();
        try
        {
            var pedido = _mapper.Map<PizzaTienda.Domain.Entities.Pedido>(pedidoDto);
            response.Data = _unitOfWork.Pedidos.Update(pedido);
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

    public Response<bool> Delete(int id)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _unitOfWork.Pedidos.Delete(id);
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

    public Response<PedidoDto> Get(int id)
    {
        var response = new Response<PedidoDto>();
        try
        {
            var pedido = _unitOfWork.Pedidos.Get(id);
            response.Data = _mapper.Map<PedidoDto>(pedido);
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

    public Response<IEnumerable<PedidoDto>> GetAll()
    {
        var response = new Response<IEnumerable<PedidoDto>>();
        try
        {
            var pedido = _unitOfWork.Pedidos.GetAll();
            response.Data = _mapper.Map<IEnumerable<PedidoDto>>(pedido);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
                //_logger.LogInformation("Consulta Exitosa!!!");
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            //_logger.LogError(e.Message);
        }
        return response;
    }
    #endregion

    #region Métodos Asíncronos
    public async Task<Response<bool>> InsertAsync(PedidoDto pedidoDto)
    {
        var response = new Response<bool>();
        try
        {
            //*************colocamos la reglas de la validacion en esta parte
            pedidoDto = await _promocion.ExecRulePromotion(pedidoDto);
            //*************
            var pedido = _mapper.Map<PizzaTienda.Domain.Entities.Pedido>(pedidoDto);
            response.Data = await _unitOfWork.Pedidos.InsertAsync(pedido);
            
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
    public async Task<Response<bool>> UpdateAsync(PedidoDto pedidoDto)
    {
        var response = new Response<bool>();
        try
        {
            var pedido = _mapper.Map<PizzaTienda.Domain.Entities.Pedido>(pedidoDto);
            response.Data = await _unitOfWork.Pedidos.UpdateAsync(pedido);
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
            response.Data = await _unitOfWork.Pedidos.DeleteAsync(id);
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

    public async Task<Response<PedidoDto>> GetAsync(int id)
    {
        var response = new Response<PedidoDto>();
        try
        {
            var pedido = await _unitOfWork.Pedidos.GetAsync(id, CancellationToken.None);
            response.Data = _mapper.Map<PedidoDto>(pedido);
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
    public async Task<Response<IEnumerable<PedidoDto>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<PedidoDto>>();
        try
        {
            var pedido = await _unitOfWork.Pedidos.GetAllAsync(CancellationToken.None);
            response.Data = _mapper.Map<IEnumerable<PedidoDto>>(pedido);
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

    #endregion
}
