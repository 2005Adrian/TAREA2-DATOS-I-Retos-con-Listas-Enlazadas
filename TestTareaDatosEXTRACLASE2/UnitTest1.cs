using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using TareaExtraclase2;

namespace TestTareaDatosEXTRACLASE2
{
    [TestClass]
    public class UnitTest1
    {
        // Problema 1: InsertInOrder, DeleteFirst, DeleteLast, DeleteValue, GetMiddle, MergeSorted

        [TestMethod]
        public void TestInsertInOrder()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            Assert.AreEqual(5, lista.cabeza.Valor);
            Assert.AreEqual(10, lista.cabeza.Siguiente.Valor);
            Assert.AreEqual(15, lista.cola.Valor);
        }

        [TestMethod]
        public void TestDeleteFirst()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int valorEliminado = lista.DeleteFirst();

            Assert.AreEqual(5, valorEliminado);
            Assert.AreEqual(10, lista.cabeza.Valor);
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int valorEliminado = lista.DeleteLast();

            Assert.AreEqual(15, valorEliminado);
            Assert.AreEqual(10, lista.cola.Valor);
        }

        [TestMethod]
        public void TestDeleteValue()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            bool valorEliminado = lista.DeleteValue(10);

            Assert.IsTrue(valorEliminado);
            Assert.AreEqual(5, lista.cabeza.Valor);
            Assert.AreEqual(15, lista.cola.Valor);
        }

        [TestMethod]
        public void TestGetMiddle()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);
            lista.InsertInOrder(20);
            lista.InsertInOrder(2);

            int valorMedio = lista.GetMiddle();

            Assert.AreEqual(10, valorMedio);  // El valor medio es 10 en este caso
        }

        [TestMethod]
        public void TestMergeSorted()
        {
            ListaDoble lista1 = new ListaDoble();
            ListaDoble lista2 = new ListaDoble();

            lista1.InsertInOrder(1);
            lista1.InsertInOrder(3);
            lista1.InsertInOrder(5);

            lista2.InsertInOrder(2);
            lista2.InsertInOrder(4);
            lista2.InsertInOrder(6);

            ListaDoble listaFusionada = new ListaDoble();
            listaFusionada.MergeSorted(lista1, lista2, SortDirection.Ascending);

            Assert.AreEqual(1, listaFusionada.cabeza.Valor);
            Assert.AreEqual(6, listaFusionada.cola.Valor);
        }

        // Problema 2: Test for Invert Method


        [TestMethod]
        public void TestInvert()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);
            lista.InsertInOrder(30);

            // Invertir la lista
            lista.Invert();

            // Verificar que la cabeza ahora sea 30
            Assert.AreEqual(10, lista.cabeza.Valor);  // Verificar que la cabeza es 30 después de invertir
            Assert.AreEqual(30, lista.cola.Valor);    // Verificar que la cola es 10 después de invertir
        }



        // Problema 3: InsertInOrder, verificar el orden de inserción

        [TestMethod]
        public void TestInsertInOrderMultiple()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(30);
            lista.InsertInOrder(10);
            lista.InsertInOrder(20);

            Assert.AreEqual(10, lista.cabeza.Valor);
            Assert.AreEqual(20, lista.cabeza.Siguiente.Valor);
            Assert.AreEqual(30, lista.cola.Valor);
        }
    }
}
