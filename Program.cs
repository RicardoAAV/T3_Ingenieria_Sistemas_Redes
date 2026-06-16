using System;

class Program
{
    static void Main(string[] args)
    {
        // ricardo aqui va create y read
    }

    // Esto es el update es para cambiar de libro - precio -codigo y cantidad 
    static void CambiarLibro(string[] codigos, string[] libros, double[] precios, int[] cantidades, int total)
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
        Console.WriteLine($"Libro encontrado:);
    }
}