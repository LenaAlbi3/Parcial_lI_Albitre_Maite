using Parcial2_Albitre_Maite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parcial2_Albitre_Maite.Models
{
    public static class Inventario
    {
        static List<Producto> products = new();
        static readonly string ArchivoProductos = "Inventario.txt";
        public static void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string name = Console.ReadLine();
            Console.Write("Seleccione el tipo de producto: ");
            foreach (var prod in Enum.GetValues(typeof(TipoProducto)))
            {
                Console.WriteLine($"{(int)prod}. {prod}");
            }
            int tipoProd = int.Parse(Console.ReadLine());
            TipoProducto tipo = (TipoProducto)tipoProd;
            Console.WriteLine("Ingrese el precio del producto: ");
            double prec = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad disponible del producto: ");
            int cant = int.Parse(Console.ReadLine());
            Producto producto = new Producto(name, tipo, prec, cant);
            products.Add(producto);
            Console.WriteLine("Producto agregado exitosamente");
            Inventario.GuardarDato(producto);

        }

        public static void EliminarProducto(string nombre)
        {
            var producto = products.Find(p => p.Nombre == nombre);
            if(producto != null)
            {
                products.Remove(producto);
                Console.WriteLine("Producto eliminado exitosamente");

            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
            Inventario.GuardarDatos();

        }
        public static void ModificarProducto(string nombre)
        {
            var producto = products.Find(p => p.Nombre == nombre);
            if (producto != null)
            {
                Console.Write("Seleccione el tipo de producto: ");
                foreach (var prod in Enum.GetValues(typeof(TipoProducto)))
                {
                    Console.WriteLine($"{(int)prod}. {prod}");
                }
                int tipoProd = int.Parse(Console.ReadLine());
                TipoProducto tipo = (TipoProducto)tipoProd;
                Console.WriteLine("Ingrese el precio del producto: ");
                double prec = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad disponible del producto: ");
                int cant = int.Parse(Console.ReadLine());
                producto.Tipo = tipo;
                producto.Precio = prec;
                producto.Cantidad = cant;
                Console.WriteLine("Producto actualizado exitosamente");
                
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
            Inventario.GuardarDatos();

        }

        public static void MostrarProductos()
        {
            foreach (Producto p in products)
            {
                Console.WriteLine(p.ToString());
            }

        }

        public static void CalcularTotal()
        {
            double ac = 0;
            foreach (Producto p in products)
            {
                ac += p.Precio * p.Cantidad;
                
            }
            Console.WriteLine($"El precio total de los productos en inventario es de {ac}");

        }

        public static void CargarDatos()
        {
            if (File.Exists(ArchivoProductos))
            {
                var lineas = File.ReadAllLines(ArchivoProductos);
                foreach (var linea in lineas)
                {

                    var datos = linea.Split(" - ");
                    string nombre = datos[0];
                    TipoProducto tipo = (TipoProducto)Enum.Parse(typeof(TipoProducto), datos[1]);
                    double precio = double.Parse(datos[2]);
                    int cant = int.Parse(datos[3]);
                    Producto prod = new(nombre, tipo, precio, cant);
                    products.Add(prod);
                }
            }

        }

        public static void GuardarDato(Producto prod)
        {
            using StreamWriter streamWriter = new StreamWriter(ArchivoProductos);
            streamWriter.WriteLine(prod);
        }

        public static void GuardarDatos()
        {
            using StreamWriter streamWriter = new StreamWriter(ArchivoProductos);
            foreach (Producto prod in products)
            {
                streamWriter.WriteLine(prod);
            }

        }
    }
}
