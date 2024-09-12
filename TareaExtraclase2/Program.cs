using System;

namespace TareaExtraclase2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear dos listas para pruebas generales
            ListaDoble lista1 = new ListaDoble();
            ListaDoble lista2 = new ListaDoble();

            // Prueba de InsertInOrder
            Console.WriteLine("----- Prueba InsertInOrder -----");
            lista1.InsertInOrder(10);
            lista1.InsertInOrder(5);
            lista1.InsertInOrder(15);
            MostrarLista(lista1);

            // Prueba de DeleteFirst
            Console.WriteLine("\n----- Prueba DeleteFirst -----");
            int valorEliminado = lista1.DeleteFirst();
            Console.WriteLine($"Valor eliminado (primero): {valorEliminado}");
            MostrarLista(lista1);

            // Prueba de DeleteLast
            Console.WriteLine("\n----- Prueba DeleteLast -----");
            valorEliminado = lista1.DeleteLast();
            Console.WriteLine($"Valor eliminado (último): {valorEliminado}");
            MostrarLista(lista1);

            // Prueba de DeleteValue
            Console.WriteLine("\n----- Prueba DeleteValue -----");
            lista1.InsertInOrder(20);
            lista1.InsertInOrder(30);
            bool valorEliminadoBool = lista1.DeleteValue(20);
            Console.WriteLine($"¿Valor eliminado (20)?: {valorEliminadoBool}");
            MostrarLista(lista1);

            // ----- Sección de pruebas identificadas -----

            // Prueba de MergeSorted en orden ascendente
            Console.WriteLine("\n----- Prueba MergeSorted Ascendente -----");
            lista1.InsertInOrder(1);
            lista1.InsertInOrder(0);
            lista1.InsertInOrder(5);

            lista2.InsertInOrder(2);
            lista2.InsertInOrder(90);
            lista2.InsertInOrder(6);

            ListaDoble listaFusionada = new ListaDoble();
            listaFusionada.MergeSorted(lista1, lista2, SortDirection.Ascending);
            MostrarLista(listaFusionada);

            // Prueba de MergeSorted en orden descendente
            Console.WriteLine("\n----- Prueba MergeSorted Descendente -----");
            ListaDoble listaFusionadaDesc = new ListaDoble();
            listaFusionadaDesc.MergeSorted(lista1, lista2, SortDirection.Descending);
            MostrarLista(listaFusionadaDesc);

            // Prueba de Invert
            Console.WriteLine("\n----- Prueba Invert -----");
            listaFusionada.Invert();
            MostrarLista(listaFusionada);

            // Prueba de GetMiddle
            Console.WriteLine("\n----- Prueba GetMiddle -----");
            int valorMedio = listaFusionada.GetMiddle();
            Console.WriteLine($"El valor medio de la lista es: {valorMedio}");
        }

        static void MostrarLista(ListaDoble lista)
        {
            var nodo = lista.cabeza;
            Console.Write("Lista: ");
            while (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                nodo = nodo.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
