// Validaciones finales del proyecto
// Revisión general del sistema de biblioteca
// Proyecto: Sistema de Librería - CRUD completo
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

        // Bucle que mantiene el menú activo hasta que el usuario digite 5
        while (opcion != 5)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE LIBRERÍA ===");
            Console.WriteLine("1. Registrar Libro (Create)");
            Console.WriteLine("2. Mostrar Libros (Read)");
            Console.WriteLine("3. Cambiar Libro (Update)");
            Console.WriteLine("4. Eliminar Libro (Delete)");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            // Detecta que no sea presionado otro número que no esté en las opciones
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("--- REGISTRAR NUEVO LIBRO ---");

                    // Valida que no haya más de 100 libros
                    if (total < maximo)
                    {
                        Console.Write("Ingrese código: ");
                        string nuevoCod = Console.ReadLine() ?? "";

                        Console.Write("Ingrese nombre del libro: ");
                        string nuevoNombre = Console.ReadLine() ?? "";

                        Console.Write("Ingrese precio: ");
                        if (!double.TryParse(Console.ReadLine(), out double nuevoPrecioReg) || nuevoPrecioReg < 0)
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número mayor o igual a 0.");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Ingrese cantidad: ");
                        if (!int.TryParse(Console.ReadLine(), out int nuevaCantReg) || nuevaCantReg < 0)
                        {
                            Console.WriteLine("Cantidad inválida. Debe ser un número mayor o igual a 0.");
                            Console.ReadKey();
                            break;
                        }

                        if (nuevoCod == "" || nuevoNombre == "")
                        {
                            Console.WriteLine("El código y nombre no pueden estar vacíos.");
                        }
                        else
                        {
                            codigos[total] = nuevoCod;
                            libros[total] = nuevoNombre;
                            precios[total] = nuevoPrecioReg;
                            cantidad[total] = nuevaCantReg;
                            total++;
                            Console.WriteLine("\n¡Libro registrado con éxito!");
                        }
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
                            Console.WriteLine($"  Código:   {codigos[i]}");
                            Console.WriteLine($"  Nombre:   {libros[i]}");
                            Console.WriteLine($"  Precio:   s/. {precios[i]:F2}");
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

                case 4:
                    Console.Clear();
                    total = EliminarLibro(codigos, libros, precios, cantidad, total);
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema. ¡Adiós!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para actualizar los datos de un libro existente
    static void CambiarLibro(string[] codigos, string[] libros, double[] precios, int[] cantidad, int total)
    {
        int posicion = -1;

        Console.WriteLine("--- CAMBIAR LIBRO ---");
        Console.Write("Ingrese el código del libro a cambiar: ");
        string codigoBuscado = Console.ReadLine() ?? "";

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
            Console.WriteLine("Libro encontrado:");
            Console.WriteLine("  Nombre:   " + libros[posicion]);
            Console.WriteLine("  Precio:   " + precios[posicion]);
            Console.WriteLine("  Cantidad: " + cantidad[posicion]);

            Console.Write("Nuevo código: ");
            string nuevoCodigo = Console.ReadLine() ?? "";

            Console.Write("Nuevo nombre del libro: ");
            string nuevoLibro = Console.ReadLine() ?? "";

            Console.Write("Nuevo precio: ");
            if (!double.TryParse(Console.ReadLine(), out double nuevoPrecio))
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            Console.Write("Nueva cantidad: ");
            if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad))
            {
                Console.WriteLine("Cantidad inválida.");
                return;
            }

            if (nuevoCodigo == "")
                Console.WriteLine("El código no puede estar vacío.");
            else if (nuevoLibro == "")
                Console.WriteLine("El nombre no puede estar vacío.");
            else if (nuevoPrecio < 0)
                Console.WriteLine("El precio no puede ser menor a 0.");
            else if (nuevaCantidad < 0)
                Console.WriteLine("La cantidad no puede ser menor a 0.");
            else
            {
                codigos[posicion] = nuevoCodigo;
                libros[posicion] = nuevoLibro;
                precios[posicion] = nuevoPrecio;
                cantidad[posicion] = nuevaCantidad;
                Console.WriteLine("Libro modificado exitosamente.");
            }
        }
    }

    // Método para eliminar un libro del inventario por código
    static int EliminarLibro(string[] codigos, string[] libros, double[] precios, int[] cantidad, int total)
    {
        int posicion = -1;

        Console.WriteLine("--- ELIMINAR LIBRO ---");
        Console.Write("Ingrese el código del libro a eliminar: ");
        string codigoBuscado = Console.ReadLine() ?? "";

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
            Console.WriteLine($"Libro a eliminar: {libros[posicion]} (Código: {codigos[posicion]})");
            Console.Write("¿Está seguro que desea eliminar este libro? (s/n): ");
            string confirmacion = Console.ReadLine() ?? "n";

            if (confirmacion.ToLower() == "s")
            {
                // Desplaza todos los elementos hacia la izquierda para llenar el hueco
                for (int i = posicion; i < total - 1; i++)
                {
                    codigos[i] = codigos[i + 1];
                    libros[i] = libros[i + 1];
                    precios[i] = precios[i + 1];
                    cantidad[i] = cantidad[i + 1];
                }

                // Limpia el último espacio y reduce el contador
                codigos[total - 1] = "";
                libros[total - 1] = "";
                precios[total - 1] = 0;
                cantidad[total - 1] = 0;
                total--;

                Console.WriteLine("Libro eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }

        return total;
    }
}
