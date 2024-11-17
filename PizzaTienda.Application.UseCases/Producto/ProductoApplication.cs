
namespace PizzaTienda.Application.UseCases.Producto;
public class ProductoApplication : IProductoApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    //private readonly IAppLogger<CustomersApplication> _logger;
    public ProductoApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    #region Métodos Síncronos

    public Response<bool> Insert(ProductoDto productoDto)
    {
        var response = new Response<bool>();
        try
        {
            var producto = _mapper.Map<PizzaTienda.Domain.Entities.Producto>(productoDto);
            response.Data = _unitOfWork.Producto.Insert(producto);

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

    public Response<bool> Update(ProductoDto productoDto)
    {
        var response = new Response<bool>();
        try
        {
            var producto = _mapper.Map<PizzaTienda.Domain.Entities.Producto>(productoDto);
            response.Data = _unitOfWork.Producto.Update(producto);
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
            response.Data = _unitOfWork.Producto.Delete(id);
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

    public Response<ProductoDto> Get(int id)
    {
        var response = new Response<ProductoDto>();
        try
        {
            var producto = _unitOfWork.Producto.Get(id);
            response.Data = _mapper.Map<ProductoDto>(producto);
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

    public Response<IEnumerable<ProductoDto>> GetAll()
    {
        var response = new Response<IEnumerable<ProductoDto>>();
        try
        {
            var producto = _unitOfWork.Producto.GetAll();
            response.Data = _mapper.Map<IEnumerable<ProductoDto>>(producto);
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
    public async Task<Response<bool>> InsertAsync(ProductoDto productoDto)
    {
        var response = new Response<bool>();
        try
        {
            var producto = _mapper.Map<PizzaTienda.Domain.Entities.Producto>(productoDto);
            response.Data = await _unitOfWork.Producto.InsertAsync(producto);
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
    public async Task<Response<bool>> UpdateAsync(ProductoDto productoDto)
    {
        var response = new Response<bool>();
        try
        {
            var producto = _mapper.Map<PizzaTienda.Domain.Entities.Producto>(productoDto);
            response.Data = await _unitOfWork.Producto.UpdateAsync(producto);
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
            response.Data = await _unitOfWork.Producto.DeleteAsync(id);
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

    public async Task<Response<ProductoDto>> GetAsync(int id)
    {
        var response = new Response<ProductoDto>();
        try
        {
            var producto = await _unitOfWork.Producto.GetAsync(id, CancellationToken.None);
            response.Data = _mapper.Map<ProductoDto>(producto);
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
    public async Task<Response<IEnumerable<ProductoDto>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<ProductoDto>>();
        try
        {
            var producto = await _unitOfWork.Producto.GetAllAsync(CancellationToken.None);
            response.Data = _mapper.Map<IEnumerable<ProductoDto>>(producto);
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
