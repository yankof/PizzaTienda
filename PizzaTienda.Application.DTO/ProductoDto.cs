namespace PizzaTienda.Application.DTO;
public class ProductoDto
{
    public int Id { get; set; }
    public string descripcion { get; set; }
    public string abreviacion { get; set; }
    public string estatus { get; set; }
    public string creadoPor { get; set; } = "Admin";
    public DateTime creadoEl { get; set; } = DateTime.Now;
}
