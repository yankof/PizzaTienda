using Microsoft.AspNetCore.Mvc;
using PizzaTienda.Application.DTO;
using PizzaTienda.Application.Interfaces.UsesCases;

namespace PizzaTienda.Services.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : Controller
{
    private readonly IPedidoApplication _pedidosApplication;
    
    public PedidoController(IPedidoApplication pedidoApplication)
    {
        _pedidosApplication = pedidoApplication;
    }

    #region "Métodos Sincronos"

    //[HttpPost("Insert")]
    //public IActionResult Insert([FromBody] PedidoDto pedidosDto)
    //{
    //    if (pedidosDto == null)
    //        return BadRequest();
    //    var response = _pedidosApplication.Insert(pedidosDto);
    //    if (response.IsSuccess)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpPut("Update/{pedidoId}")]
    //public IActionResult Update(int pedidoId, [FromBody] PedidoDto pedidosDto)
    //{
    //    var pedidoDto = _pedidosApplication.Get(pedidoId);
    //    if (pedidoDto.Data == null)
    //        return NotFound(pedidoDto.Message);

    //    if (pedidosDto == null)
    //        return BadRequest();
    //    var response = _pedidosApplication.Update(pedidosDto);
    //    if (response.IsSuccess)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpDelete("Delete/{pedidoId}")]
    //public IActionResult Delete(int pedidoId)
    //{
    //    if (string.IsNullOrEmpty(pedidoId.ToString()))
    //        return BadRequest();
    //    var response = _pedidosApplication.Delete(pedidoId);
    //    if (response.IsSuccess)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpGet("Get/{pedidoId}")]
    //public IActionResult Get(int pedidoId)
    //{
    //    if (string.IsNullOrEmpty(pedidoId.ToString()))
    //        return BadRequest();
    //    var response = _pedidosApplication.Get(pedidoId);
    //    if (response.IsSuccess)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    //[HttpGet("GetAll")]
    //public IActionResult GetAll()
    //{
    //    var response = _pedidosApplication.GetAll();
    //    if (response.IsSuccess)
    //        return Ok(response);

    //    return BadRequest(response.Message);
    //}

    
    #endregion

    #region "Métodos Asincronos"

    [HttpPost("InsertAsync")]
    public async Task<IActionResult> InsertAsync([FromBody] PedidoDto pedidosDto)
    {
        if (pedidosDto == null)
            return BadRequest();
        var response = await _pedidosApplication.InsertAsync(pedidosDto);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPut("UpdateAsync/{pedidoId}")]
    public async Task<IActionResult> UpdateAsync(int pedidoId, [FromBody] PedidoDto pedidosDto)
    {
        var pedidoDto = await _pedidosApplication.GetAsync(pedidoId);
        if (pedidoDto.Data == null)
            return NotFound(pedidoDto.Message);

        if (pedidosDto == null)
            return BadRequest();
        var response = await _pedidosApplication.UpdateAsync(pedidosDto);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpDelete("DeleteAsync/{pedidoId}")]
    public async Task<IActionResult> DeleteAsync(int pedidoId)
    {
        if (string.IsNullOrEmpty(pedidoId.ToString()))
            return BadRequest();
        var response = await _pedidosApplication.DeleteAsync(pedidoId);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet("GetAsync/{pedidoId}")]
    public async Task<IActionResult> GetAsync(int pedidoId)
    {
        if (string.IsNullOrEmpty(pedidoId.ToString()))
            return BadRequest();
        var response = await _pedidosApplication.GetAsync(pedidoId);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _pedidosApplication.GetAllAsync();
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    
    #endregion
}
