using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Lista que almacenará los títulos de las revistas
        static List<string> catalogo = new List<string>()
        {
            "National Geographic",
            "Time",
            "Forbes",
            "Scientific American",
            "Nature",
            "The Economist",
            "Vogue",
            "Sports Illustrated",
            "PC Gamer",
            "Reader's Digest"
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("==== CATÁLOGO DE REVISTAS ====");
                Console.WriteLine("1. Buscar título (Iterativa)");
                Console.WriteLine("2. Buscar título (Recursiva)");
                Console.WriteLine("3. Mostrar catálogo completo");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        BuscarIterativa();
                        break;
                    case 2:
                        BuscarRecursiva();
                        break;
                    case 3:
                        MostrarCatalogo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente nuevamente.");
                        break;
                }
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 0);
        }

        // ==== MÉTODOS ====

        // Método de búsqueda iterativa
        static void BuscarIterativa()
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = false;
            foreach (string revista in catalogo)
            {
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
                Console.WriteLine("✅ Encontrado");
            else
                Console.WriteLine("❌ No encontrado");
        }

        // Método de búsqueda recursiva
        static void BuscarRecursiva()
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = BuscarRecursivaHelper(titulo, 0);

            if (encontrado)
                Console.WriteLine("✅ Encontrado");
            else
                Console.WriteLine("❌ No encontrado");
        }

        // Función recursiva auxiliar
        static bool BuscarRecursivaHelper(string titulo, int indice)
        {
            if (indice >= catalogo.Count)
                return false;

            if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            return BuscarRecursivaHelper(titulo, indice + 1);
        }

        // Mostrar catálogo completo
        static void MostrarCatalogo()
        {
            Console.WriteLine("=== CATÁLOGO COMPLETO ===");
            foreach (var revista in catalogo)
            {
                Console.WriteLine("- " + revista);
            }
        }
    }
}
