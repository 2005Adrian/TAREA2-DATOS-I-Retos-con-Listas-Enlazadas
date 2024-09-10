using Microsoft.VisualStudio.TestTools.UnitTesting;
using TareaExtraclase2;  // Asegúrate de que este es el espacio de nombres correcto

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

            int eliminado = lista.DeleteFirst();
            Assert.AreEqual(5, eliminado);
            Assert.AreEqual(10, lista.cabeza.Valor);
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int eliminado = lista.DeleteLast();
            Assert.AreEqual(15, eliminado);
            Assert.AreEqual(10, lista.cola.Valor);
        }

        [TestMethod]
        public void TestDeleteValue()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            bool eliminado = lista.DeleteValue(10);
            Assert.IsTrue(eliminado);
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

            int middle = lista.GetMiddle();
            Assert.AreEqual(10, middle);
        }

        [TestMethod]
        public void TestMergeSortedAscending()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(5);
            listaA.InsertInOrder(15);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(20);
            listaB.InsertInOrder(3);
            listaB.InsertInOrder(7);

            ListaDoble listaMerge = new ListaDoble();
            listaMerge.MergeSorted(listaA, listaB, SortDirection.Ascending);

            Assert.AreEqual(3, listaMerge.cabeza.Valor);
            Assert.AreEqual(20, listaMerge.cola.Valor);
        }

        [TestMethod]
        public void TestMergeSortedDescending()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(5);
            listaA.InsertInOrder(15);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(20);
            listaB.InsertInOrder(3);
            listaB.InsertInOrder(7);

            ListaDoble listaMerge = new ListaDoble();
            listaMerge.MergeSorted(listaA, listaB, SortDirection.Descending);

            Assert.AreEqual(20, listaMerge.cabeza.Valor);
            Assert.AreEqual(3, listaMerge.cola.Valor);
        }

        // Problema 2: Invertir la lista
        [TestMethod]
        public void TestInvertList()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            lista.Invert();

            Assert.AreEqual(15, lista.cabeza.Valor);
            Assert.AreEqual(5, lista.cabeza.Siguiente.Valor);
            Assert.AreEqual(10, lista.cola.Valor);
        }
    }
}
