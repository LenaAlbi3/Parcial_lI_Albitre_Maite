using Parcial2_Albitre_Maite.Models;

class Program
{
    static void Main(string[] args)
    {
        Inventario.CargarDatos();
        int opc;

        do
        {

            Console.WriteLine($"Menu\n" +
            $"1. Agregar Producto\n" +
            $"2. Mostrar Productos\n" +
            $"3. Actualizar Producto Existente\n" +
            $"4. Eliminar Producto\n" +
            $"5. Calcular total de productos en inventario\n" +
            $"6. Guardar y Salir");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Inventario.AgregarProducto();
                    break;
                case 2:
                    Inventario.MostrarProductos();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el nombre del Producto a modificar: ");
                    string nom = Console.ReadLine();
                    Inventario.ModificarProducto(nom);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el nombre del Producto a eliminar: ");
                    nom = Console.ReadLine();
                    Inventario.EliminarProducto(nom);
                    break;
                case 5:
                    Inventario.CalcularTotal();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opc != 6);

    }
}


