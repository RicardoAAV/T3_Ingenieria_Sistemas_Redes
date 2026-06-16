using System;

class Program
{
    static void Main(string[] args)
    {
        // ricardo aqui va create y read
    }

    // Esto es el update es para cambiar de libro - precio -codigo y cantidad 
    static void CambiarLibro(string[] codigos, string[] libros, double[] precios, int[] cantidad, int total)
    {
        string codigoBuscado;
        int posicion = -1;

        Console.WriteLine("CAMBIAR LIBRO");
        Console.Write("Ingrese el código del libro a cambiar: ");
        codigoBuscado = Console.ReadLine();

        for (int i = 0; i < total; i++)
        {
            if (codigos[i] == codigoBuscado)
            {
                posicion = i;
                break;
            }
        }
        if (posicion == -1)
        {
            Console.WriteLine("Código de libro no encontrado.");
        }
       else
{
    Console.WriteLine("Libro encontrado");
    Console.WriteLine("Libro actual: " + libros[posicion]);
    Console.WriteLine("Precio actual: " + precios[posicion]);
            Console.WriteLine("Cantidad actual: " + cantidad[posicion]);

            Console.Write("Nuevo codigo: ");
            string nuevoCodigo = Console.ReadLine();

            Console.Write("Nuevo libro: ");
            string nuevoLibro = Console.ReadLine();

            Console.Write("Nuevo precio: ");
            double nuevoPrecio = double.Parse(Console.ReadLine());

            Console.Write("Nueva cantidad: ");
            int nuevaCantidad = int.Parse(Console.ReadLine());

            if (nuevoCodigo == "")
            {
                Console.WriteLine("El codigo esta vacio");
            }
            else if (nuevoLibro == "")
            {
                Console.WriteLine("El libro esta vacio");
            }
            else if (nuevoPrecio < 0)
            {
                Console.WriteLine("El precio no puede ser menos de 0");
            }
            else if (nuevaCantidad < 0)
            {
                Console.WriteLine("La cantidad no puede ser menos de 0");
            }
            else
            {
                codigos[posicion] = nuevoCodigo;
                libros[posicion] = nuevoLibro;
                precios[posicion] = nuevoPrecio;
                cantidad[posicion] = nuevaCantidad;

                Console.WriteLine("Se cambio el libro");
            }
        }
    }
}
    