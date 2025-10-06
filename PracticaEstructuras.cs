
using System;
using System.Collections.Generic;

namespace PracticaEstructuras
{
    // ------------------------------
    // Clase Nodo Árbol Binario
    // ------------------------------
    class NodoArbol
    {
        public string Valor;
        public NodoArbol Izquierdo;
        public NodoArbol Derecho;

        public NodoArbol(string valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    class ArbolBinario
    {
        public NodoArbol Raiz;

        public ArbolBinario(string valor)
        {
            Raiz = new NodoArbol(valor);
        }

        // Recorrido en Preorden
        public void Preorden(NodoArbol nodo)
        {
            if (nodo == null) return;
            Console.Write(nodo.Valor + " ");
            Preorden(nodo.Izquierdo);
            Preorden(nodo.Derecho);
        }

        // Recorrido en Inorden
        public void Inorden(NodoArbol nodo)
        {
            if (nodo == null) return;
            Inorden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            Inorden(nodo.Derecho);
        }

        // Recorrido en Postorden
        public void Postorden(NodoArbol nodo)
        {
            if (nodo == null) return;
            Postorden(nodo.Izquierdo);
            Postorden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // ------------------------------
    // Clase Grafo No Dirigido
    // ------------------------------
    class Grafo
    {
        private Dictionary<string, List<string>> adj;

        public Grafo()
        {
            adj = new Dictionary<string, List<string>>();
        }

        // Agregar nodo
        public void AgregarVertice(string v)
        {
            if (!adj.ContainsKey(v))
                adj[v] = new List<string>();
        }

        // Agregar arista no dirigida
        public void AgregarArista(string v1, string v2)
        {
            AgregarVertice(v1);
            AgregarVertice(v2);
            adj[v1].Add(v2);
            adj[v2].Add(v1);
        }

        // Mostrar grafo
        public void MostrarGrafo()
        {
            foreach (var nodo in adj)
            {
                Console.Write(nodo.Key + " -> ");
                Console.WriteLine(string.Join(", ", nodo.Value));
            }
        }
    }

    // ------------------------------
    // Programa Principal
    // ------------------------------
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Árbol Binario ===");
            ArbolBinario arbol = new ArbolBinario("Raíz");
            arbol.Raiz.Izquierdo = new NodoArbol("A");
            arbol.Raiz.Derecho = new NodoArbol("B");
            arbol.Raiz.Izquierdo.Izquierdo = new NodoArbol("C");
            arbol.Raiz.Izquierdo.Derecho = new NodoArbol("D");
            arbol.Raiz.Derecho.Izquierdo = new NodoArbol("E");
            arbol.Raiz.Derecho.Derecho = new NodoArbol("F");

            Console.WriteLine("Recorrido Preorden:");
            arbol.Preorden(arbol.Raiz);
            Console.WriteLine("\nRecorrido Inorden:");
            arbol.Inorden(arbol.Raiz);
            Console.WriteLine("\nRecorrido Postorden:");
            arbol.Postorden(arbol.Raiz);

            Console.WriteLine("\n\n=== Grafo No Dirigido ===");
            Grafo g = new Grafo();
            g.AgregarArista("A", "B");
            g.AgregarArista("A", "C");
            g.AgregarArista("B", "D");
            g.AgregarArista("C", "E");
            g.AgregarArista("C", "F");
            g.MostrarGrafo();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
