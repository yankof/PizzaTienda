using PizzaTienda.Domain.Entities;

namespace PizzaTienda.Application.DTO;
public class PedidoDto
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string nombreCliente { get; set; }
    public string direccionCliente { get; set; }
    public string nitCliente { get; set; }
    public string telefonoCliente { get; set; }

    public int idProducto { get; set; }
    public string descripcionProducto { get; set; }
    public decimal cantidadProducto { get; set; }
    public decimal PrecioProducto { get; set; }
    public decimal PrecioDelivery { get; set; }
    public decimal TotalProducto { get; set; }

    public string estatus { get; set; }
    public string creadoPor { get; set; } = "Admin";
    public DateTime creadoEl { get; set; } = DateTime.Now;

}
