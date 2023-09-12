using MathExpert;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class CalculadorNUnitTests
    {
        [Test]
        public void SumarNumeros_IngresarDosNumeros_ObtenerSuma()
        {
            //Arrange
            Calculador calculador = new Calculador();

            //Act
            int resultado = calculador.SumarNumeros(5, 6);

            //Asset
            Assert.AreEqual(11, resultado);
        }

        [Test]
        public void IsImpar_IngresarNumeroPar_ObtenerFalse()
        {
            //Arrange
            Calculador calculador = new Calculador();

            //Act
            bool isImpar = calculador.IsImpar(12);

            //Assert
            Assert.IsFalse(isImpar);
            Assert.That(isImpar, Is.EqualTo(false));
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsImpar_IngresarNumeroImpar_ObtenerTrue(int numero)
        {
            Calculador calculador = new Calculador();

            bool isImpar = calculador.IsImpar(numero);

            Assert.IsTrue(isImpar);
            Assert.That(isImpar, Is.EqualTo(true));
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsImpar_IngresarNumero_ObtenerTrueOrFalse(int numero)
        {
            Calculador calculador = new Calculador();

            bool isImpar = calculador.IsImpar(numero);
            return isImpar;
        }

        [Test]
        [TestCase(5.2, 10.2)]//15.4
        [TestCase(5.4, 10.4)]//15.8
        [TestCase(5.6, 10.6)]//16.2
        public void SumarNumerosDouble_IngresarDosNumeros_ObtenerSuma(double numero1, double numero2)
        {
            Calculador calculador = new Calculador();

            double resultado = calculador.SumarNumerosDouble(numero1, numero2);

            Assert.AreEqual(15.4, resultado, 1);
        }

        [Test]
        public void ObtenerRangoImpares_IngresarInicioFinal_ObtenerListaImpares()
        {
            Calculador calculador = new Calculador();

            List<int> listaEsperadaImpares = new() { 3, 5, 7 };
            List<int> resultado = calculador.ObtenerRangoImpares(3, 8);

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.EquivalentTo(listaEsperadaImpares));//si la lista resultado es igual a la lista esperada
                Assert.AreEqual(listaEsperadaImpares, resultado);//si la lista resultado es igual a la lista esperada
                Assert.Contains(7, resultado);//si la lista contiene el numero 7
                Assert.That(resultado, Does.Contain(7));//si la lista contiene el numero 7
                Assert.That(resultado, Is.Not.Empty);//si la lista no está vacía
                Assert.That(resultado.Count, Is.EqualTo(3));//si la cantidad de elementos de la lista es 3
                Assert.That(resultado, Has.No.Member(6));//si el numero 6 no hace parte de la lista
                Assert.That(resultado, Is.Ordered);//si la lista está ordenada esta ordenada de manera ascendente
                Assert.That(resultado, !Is.Ordered.Descending);//si la lista está ordenada de manera ascendente
                Assert.That(resultado, Is.Unique);//si no se repite ningun elemento de la lista
            });
        }
    }
}
