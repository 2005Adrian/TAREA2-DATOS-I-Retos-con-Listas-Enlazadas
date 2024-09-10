using System;
using System.Collections.Generic;

namespace TareaExtraclase2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test para el Problema 1: InsertInOrder
            Console.WriteLine("Probando InsertInOrder...");
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(20);
            lista.InsertInOrder(15);
            ImprimirLista(lista, "Lista después de InsertInOrder:");

            // Test para el Problema 2: Invert
            Console.WriteLine("\nProbando Invert...");
            lista.Invert();
            ImprimirLista(lista, "Lista después de Invertir:");

            // Test para el Problema 3: MergeSorted
            Console.WriteLine("\nProbando MergeSorted...");
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(1);
            listaA.InsertInOrder(4);
            listaA.InsertInOrder(6);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(2);
            listaB.InsertInOrder(3);
            listaB.InsertInOrder(5);

            ListaDoble listaMerged = new ListaDoble();
            listaMerged.MergeSorted(listaA, listaB, SortDirection.Ascending);
            ImprimirLista(listaMerged, "Lista después de MergeSorted (Ascendente):");

            // Prueba con MergeSorted en orden descendente
            ListaDoble listaMergedDesc = new ListaDoble();
            listaMergedDesc.MergeSorted(listaA, listaB, SortDirection.Descending);
            ImprimirLista(listaMergedDesc, "Lista después de MergeSorted (Descendente):");

            Console.ReadLine();
        }

        // Método para imprimir la lista
        static void ImprimirLista(ListaDoble lista, string titulo)
        {
            Console.WriteLine(titulo);
            ListaDoble.Nodo actual = lista.cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
