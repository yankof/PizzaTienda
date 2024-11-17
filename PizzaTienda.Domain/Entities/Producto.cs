namespace PizzaTienda.Domain.Entities;
public class Producto
{
    public int Id { get; set; }
    public string descripcion { get; set; }
    public string abreviacion { get; set; }
    public string estatus { get; set; }
    public string creadoPor { get; set; }
    public DateTime creadoEl { get; set; }
}
