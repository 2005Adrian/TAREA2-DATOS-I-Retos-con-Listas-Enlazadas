using System.ComponentModel;
using TareaExtraclase2;

class Program
{
    static void Main(string[] args)
    {
        // Crear listas de prueba
        ListaDoble lista1 = new ListaDoble();
        ListaDoble lista2 = new ListaDoble();

        // Insertar elementos en la primera lista
        lista1.InsertInOrder(1);
        lista1.InsertInOrder(3);
        lista1.InsertInOrder(5);

        // Insertar elementos en la segunda lista
        lista2.InsertInOrder(2);
        lista2.InsertInOrder(4);
        lista2.InsertInOrder(6);

        // Fusionar listas de forma ascendente
        ListaDoble listaFusionada = new ListaDoble();
        listaFusionada.MergeSorted(lista1, lista2, SortDirection.Ascending);

        // Mostrar la lista fusionada
        Console.WriteLine("Lista fusionada (ascendente):");
        var nodoActual = listaFusionada.cabeza;
        while (nodoActual != null)
        {
            Console.Write(nodoActual.Valor + " ");
            nodoActual = nodoActual.Siguiente;
        }

        Console.WriteLine("\nMedio de la lista fusionada: " + listaFusionada.GetMiddle());

        // Invertir la lista
        Console.WriteLine("Invirtiendo la lista...");
        listaFusionada.Invert();
        nodoActual = listaFusionada.cabeza;
        Console.WriteLine("Lista invertida:");
        while (nodoActual != null)
        {
            Console.Write(nodoActual.Valor + " ");
            nodoActual = nodoActual.Siguiente;
        }

        Console.ReadKey();
    }
}