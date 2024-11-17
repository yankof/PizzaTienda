
namespace PizzaTienda.Application.UseCases.ProductoComponente;
public class ProductoComponenteApplication : IProductoComponenteApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    //private readonly IAppLogger<CustomersApplication> _logger;
    public ProductoComponenteApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    #region Métodos Síncronos

    public Response<bool> Insert(ProductoComponenteDto productoComponenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var productoComponente = _mapper.Map<PizzaTienda.Domain.Entities.ProductoComponente>(productoComponenteDto);
            response.Data = _unitOfWork.ProductoComponente.Insert(productoComponente);
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

    public Response<bool> Update(ProductoComponenteDto productoComponenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var productoComponente = _mapper.Map<PizzaTienda.Domain.Entities.ProductoComponente>(productoComponenteDto);
            response.Data = _unitOfWork.ProductoComponente.Update(productoComponente);
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
            response.Data = _unitOfWork.ProductoComponente.Delete(id);
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

    public Response<ProductoComponenteDto> Get(int id)
    {
        var response = new Response<ProductoComponenteDto>();
        try
        {
            var productoComponente = _unitOfWork.ProductoComponente.Get(id);
            response.Data = _mapper.Map<ProductoComponenteDto>(productoComponente);
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

    public Response<IEnumerable<ProductoComponenteDto>> GetAll()
    {
        var response = new Response<IEnumerable<ProductoComponenteDto>>();
        try
        {
            var productoComponente = _unitOfWork.ProductoComponente.GetAll();
            response.Data = _mapper.Map<IEnumerable<ProductoComponenteDto>>(productoComponente);
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
    public async Task<Response<bool>> InsertAsync(ProductoComponenteDto productoComponenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var productoComponente = _mapper.Map<PizzaTienda.Domain.Entities.ProductoComponente>(productoComponenteDto);
            response.Data = await _unitOfWork.ProductoComponente.InsertAsync(productoComponente);
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
    public async Task<Response<bool>> UpdateAsync(ProductoComponenteDto productoComponenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var productoComponente = _mapper.Map<PizzaTienda.Domain.Entities.ProductoComponente>(productoComponenteDto);
            response.Data = await _unitOfWork.ProductoComponente.UpdateAsync(productoComponente);
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
            response.Data = await _unitOfWork.ProductoComponente.DeleteAsync(id);
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

    public async Task<Response<ProductoComponenteDto>> GetAsync(int id)
    {
        var response = new Response<ProductoComponenteDto>();
        try
        {
            var productoComponente = await _unitOfWork.ProductoComponente.GetAsync(id, CancellationToken.None);
            response.Data = _mapper.Map<ProductoComponenteDto>(productoComponente);
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
    public async Task<Response<IEnumerable<ProductoComponenteDto>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<ProductoComponenteDto>>();
        try
        {
            var productoComponente = await _unitOfWork.ProductoComponente.GetAllAsync(CancellationToken.None);
            response.Data = _mapper.Map<IEnumerable<ProductoComponenteDto>>(productoComponente);
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
