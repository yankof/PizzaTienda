namespace PizzaTienda.Application.UseCases.Componente;
public class ComponenteApplication : IComponentApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    //private readonly IAppLogger<CustomersApplication> _logger;
    public ComponenteApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    #region Métodos Síncronos

    public Response<bool> Insert(ComponenteDto componenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var componente = _mapper.Map<PizzaTienda.Domain.Entities.Componentes>(componenteDto);
            response.Data = _unitOfWork.Componentes.Insert(componente);
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

    public Response<bool> Update(ComponenteDto componenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var componente = _mapper.Map<PizzaTienda.Domain.Entities.Componentes>(componenteDto);
            response.Data = _unitOfWork.Componentes.Update(componente);
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
            response.Data = _unitOfWork.Componentes.Delete(id);
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

    public Response<ComponenteDto> Get(int id)
    {
        var response = new Response<ComponenteDto>();
        try
        {
            var componente = _unitOfWork.Componentes.Get(id);
            response.Data = _mapper.Map<ComponenteDto>(componente);
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

    public Response<IEnumerable<ComponenteDto>> GetAll()
    {
        var response = new Response<IEnumerable<ComponenteDto>>();
        try
        {
            var componente = _unitOfWork.Componentes.GetAll();
            response.Data = _mapper.Map<IEnumerable<ComponenteDto>>(componente);
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
    public async Task<Response<bool>> InsertAsync(ComponenteDto componenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var componente = _mapper.Map<PizzaTienda.Domain.Entities.Componentes>(componenteDto);
            response.Data = await _unitOfWork.Componentes.InsertAsync(componente);
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
    public async Task<Response<bool>> UpdateAsync(ComponenteDto componenteDto)
    {
        var response = new Response<bool>();
        try
        {
            var componente = _mapper.Map<PizzaTienda.Domain.Entities.Componentes>(componenteDto);
            response.Data = await _unitOfWork.Componentes.UpdateAsync(componente);
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
            response.Data = await _unitOfWork.Componentes.DeleteAsync(id);
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

    public async Task<Response<ComponenteDto>> GetAsync(int id)
    {
        var response = new Response<ComponenteDto>();
        try
        {
            var componente = await _unitOfWork.Componentes.GetAsync(id, CancellationToken.None);
            response.Data = _mapper.Map<ComponenteDto>(componente);
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
    public async Task<Response<IEnumerable<ComponenteDto>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<ComponenteDto>>();
        try
        {
            var componente = await _unitOfWork.Componentes.GetAllAsync(CancellationToken.None);
            response.Data = _mapper.Map<IEnumerable<ComponenteDto>>(componente);
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
