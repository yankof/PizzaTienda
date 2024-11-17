using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTienda.Domain.Entities;
public class Promocion
{
    [Key]
    public int IdPromocion { get; set; }
    public string Nombre { get; set; }
    public string tipo { get; set; }
    public decimal ValorMultiplicador { get; set; }
    
}
