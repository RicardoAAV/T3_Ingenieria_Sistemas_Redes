using System;

class Program
{
    static void Main(string[] args)
    {
                // 1. Configuración de arreglos paralelos (Capacidad máxima de 100 libros)
        int maximo = 100;
        string[] codigos = new string[maximo];
        string[] libros = new string[maximo];
        double[] precios = new double[maximo];
        int[] cantidad = new int[maximo];
        
        // Contador que llevará el registro de cuántos libros reales se han creado
        int total = 0; 
        int opcion = 0;

        // Bucle que mantiene el menú activo hasta que el usuario digite 4
        while (opcion != 4)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE LIBRERÍA ===");
            Console.WriteLine("1. Registrar Libro (Create)");
            Console.WriteLine("2. Mostrar Libros (Read)");
            Console.WriteLine("3. Cambiar Libro (Update - Ricardo)");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            // detecta que no sea precionado otro numero que no este en las opciones
            if (!int.TryParse(Console.ReadLine(), out opcion)) 
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    ("--- REGISTRAR NUEVO LIBRO ---");
                    
                    // Valida que no hay mas de 100 libros 
                    if (total < maximo)
                    {
                        Console.Write("Ingrese código: ");
                        codigos[total] = Console.ReadLine();

                        Console.Write("Ingrese nombre del libro: ");
                        libros[total] = Console.ReadLine();

                        Console.Write("Ingrese precio: ");
                        precios[total] = double.Parse(Console.ReadLine());

                        Console.Write("Ingrese cantidad: ");
                        cantidad[total] = int.Parse(Console.ReadLine());

                        // Suma 1 al contador
                        total++;
                        System.Console.WriteLine("\n¡Libro registrado con éxito!"); 
                    }
                    else
                    {
                    Console.WriteLine("Error: El inventario está lleno.");
                    }
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE LIBROS REGISTRADOS ---");
                    if (total == 0)
                    {
                        Console.WriteLine("No hay libros registrados en el sistema.");
                    }
                    else
                    {
                        for (int i = 0; i < total; i++)
                        {
                            Console.WriteLine($"Libro {i + 1}:");
                            Console.WriteLine($"  Código: {codigos[i]}");
                            Console.WriteLine($"  Nombre: {libros[i]}");
                            Console.WriteLine($"  Precio: s/. {precios[i]}");
                            Console.WriteLine($"  Cantidad: {cantidad[i]}");
                            Console.WriteLine("-----------------------------------");
                        }
                    }
                    
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    CambiarLibro(codigos, libros, precios, cantidad, total);
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;   
                    // este aparado conecta el apartado de update 👌

                case 4:
                    Console.WriteLine("Saliendo del sistema. ¡Adiós!");
                    break;
                    default:
                    Console.WriteLine();
                    ("Opción no válida. Intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
        }
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
    