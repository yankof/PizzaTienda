using System.Net.NetworkInformation;

namespace PizzaTienda.Domain.Entities;
public class Pedido
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
    public string creadoPor { get; set; }
    public DateTime creadoEl { get; set; }
}
