using Parcial2_Albitre_Maite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_Albitre_Maite.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public TipoProducto Tipo { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public Producto(string nombre, TipoProducto tipo, double precio, int cantidad) 
        {
            Nombre = nombre;
            Tipo = tipo;
            Precio = precio;
            Cantidad = cantidad;
        }
        public override string ToString()
        {
            return $"{Nombre} - {Tipo} - {Precio} - {Cantidad}";
        }
    }
}
