using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTienda.Application.DTO;
public class ProductoComponenteDto
{
    public int Id { get; set; }
    public int idProducto { get; set; }
    public int idComponente { get; set; }
}
