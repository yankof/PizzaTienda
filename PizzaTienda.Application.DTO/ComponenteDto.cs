using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTienda.Application.DTO;
public class ComponenteDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public string tipo { get; set; }
    public string estatus { get; set; } 
    public string creadoPor { get; set; } = "Admin";
    public DateTime creadoEl { get; set; } = DateTime.Now;
}
