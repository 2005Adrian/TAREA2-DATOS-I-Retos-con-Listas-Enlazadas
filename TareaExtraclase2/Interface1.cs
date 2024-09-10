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
            Nodo nuevoNodo = null;

            // Limpiar la lista actual
            cabeza = null;
            cola = null;

            while (currentA != null && currentB != null)
            {
                if ((direction == SortDirection.Ascending && currentA.Valor <= currentB.Valor) ||
                    (direction == SortDirection.Descending && currentA.Valor >= currentB.Valor))
                {
                    nuevoNodo = new Nodo(currentA.Valor);
                    currentA = currentA.Siguiente;
                }
                else
                {
                    nuevoNodo = new Nodo(currentB.Valor);
                    currentB = currentB.Siguiente;
                }

                InsertarNodo(nuevoNodo);
            }

            // Agregar los elementos restantes de listA, si hay
            while (currentA != null)
            {
                nuevoNodo = new Nodo(currentA.Valor);
                InsertarNodo(nuevoNodo);
                currentA = currentA.Siguiente;
            }

            // Agregar los elementos restantes de listB, si hay
            while (currentB != null)
            {
                nuevoNodo = new Nodo(currentB.Valor);
                InsertarNodo(nuevoNodo);
                currentB = currentB.Siguiente;
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

            while (actual != null)
            {
                // Intercambiar los punteros Siguiente y Anterior
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;

                actual = actual.Anterior; // Moverse hacia el siguiente nodo, que ahora es el anterior
            }

            // Al final del ciclo, temp es la nueva cabeza
            if (temp != null)
            {
                cabeza = temp.Anterior; // temp.Anterior apunta al nuevo primer nodo
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

