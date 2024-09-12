using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TareaExtraclase2
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();

        void MergeSorted(IList listA, IList listB, SortDirection direction);
    }


    public enum SortDirection

    {
        Ascending, Descending
    }

    public class ListaDoble : IList
    {
        public class Nodo
        {
            public int Valor;
            public Nodo Siguiente;
            public Nodo Anterior;

            public Nodo(int valor)
            {
                Valor = valor;
                Siguiente = null;
                Anterior = null;



            }


        }
        public Nodo cabeza;
        public Nodo cola;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
        }
        


        public int DeleteFirst()
        {
            if (cabeza == null)
                throw new InvalidOperationException("LA LISTA ESTA VACIA");
            int valor = cabeza.Valor;
            cabeza = cabeza.Siguiente;

            if (cabeza != null)
            {
                cabeza.Anterior = null;

            }
            else
                cola = null;
            return valor; 
        }

        public int DeleteLast()
        {
            if (cola == null)

                throw new InvalidCastException("lista vacia");

            int valor = cola.Valor;
            cola = cola.Anterior;

            if (cola != null)
                cola.Siguiente = null;
            else
                cabeza = null;
            return valor;   

        }
        public bool DeleteValue (int value)
        {
            Nodo actual = cabeza;

            while (actual != null && actual.Valor != value)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
                return false;

            if (actual.Anterior != null)
                actual.Anterior.Siguiente = actual.Siguiente;
            else
                cabeza = actual.Siguiente;

            if (actual.Siguiente != null)
                actual.Siguiente.Anterior = actual.Anterior;
            else
                cola = actual.Anterior;
            return true;
        }


        //Problema 1 

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            Nodo currentA = ((ListaDoble)listA).cabeza;
            Nodo currentB = ((ListaDoble)listB).cabeza;

            // Limpiar la lista actual
            cabeza = null;
            cola = null;

            // Paso 1: Fusionar las dos listas en una sola
            while (currentA != null)
            {
                InsertarNodo(new Nodo(currentA.Valor));
                currentA = currentA.Siguiente;
            }

            while (currentB != null)
            {
                InsertarNodo(new Nodo(currentB.Valor));
                currentB = currentB.Siguiente;
            }

            // Paso 2: Ordenar la lista fusionada
            OrdenarLista(direction);
        }

        private void OrdenarLista(SortDirection direction)
        {
            // Convertimos la lista enlazada en una lista común para facilitar la ordenación
            List<int> valores = new List<int>();
            Nodo actual = cabeza;

            // Extraer los valores de la lista enlazada
            while (actual != null)
            {
                valores.Add(actual.Valor);
                actual = actual.Siguiente;
            }

            // Ordenar los valores según la dirección especificada
            if (direction == SortDirection.Ascending)
            {
                valores.Sort(); // Ascendente (menor a mayor)
            }
            else
            {
                valores.Sort();
                valores.Reverse(); // Descendente (mayor a menor)
            }

            // Reconstruir la lista enlazada con los valores ordenados
            cabeza = null;
            cola = null;

            foreach (int valor in valores)
            {
                InsertarNodo(new Nodo(valor));
            }
        }





        private void InsertarNodo(Nodo nuevoNodo)
        {
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
        }

        //PROBLEMA 2 
        public void Invert()
        {
            Nodo actual = cabeza;
            Nodo temp = null;

            // Intercambiar los punteros siguiente y anterior en cada nodo
            while (actual != null)
            {
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;

                // Moverse hacia el siguiente nodo, que ahora es el anterior
                actual = actual.Anterior;
            }

            // Al final del ciclo, temp apuntará a la nueva cabeza
            if (temp != null)
            {
                cabeza = temp.Anterior;  // temp.Anterior apunta al último nodo procesado, que es la nueva cabeza
            }
        }



        //PROBLEMA 3
        public void InsertInOrder(int value)
        {
            Nodo nuevoNodo = new Nodo(value);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
                return;
            }
            if (value < cabeza.Valor)
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
                return;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Valor < value)
            {
                actual = actual.Siguiente;
            }

            nuevoNodo.Siguiente = actual.Siguiente;
            if (actual.Siguiente != null)
            {
                actual.Siguiente.Anterior = nuevoNodo;

            }
            else
            {
                cola = nuevoNodo;

            }
            actual.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = actual;

        }
        //PROBLEMA 3
        public int GetMiddle()
        {
            if (cabeza == null)
                throw new InvalidOperationException("lista vacia");
            Nodo lento = cabeza;
            Nodo rapido = cabeza;

            while (rapido != null && rapido.Siguiente != null)
            {
                rapido = rapido.Siguiente.Siguiente;
                lento = lento.Siguiente;
            }
            return lento.Valor;

        }



    }

}

