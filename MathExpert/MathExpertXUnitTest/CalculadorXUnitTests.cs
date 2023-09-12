using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CalculadorXUnitTests
    {
        [Fact]
        public void SumarNumeros_IngresarDosNumeros_ObtenerSuma()
        {
            //Arrange
            Calculador calculador = new Calculador();

            //Act
            int resultado = calculador.SumarNumeros(5, 6);

            //Asset
            Assert.Equal(11, resultado);
        }

        [Fact]
        public void IsImpar_IngresarNumeroPar_ObtenerFalse()
        {
            //Arrange
            Calculador calculador = new Calculador();

            //Act
            bool isImpar = calculador.IsImpar(12);

            //Assert
            Assert.False(isImpar);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsImpar_IngresarNumeroImpar_ObtenerTrue(int numero)
        {
            Calculador calculador = new Calculador();

            bool isImpar = calculador.IsImpar(numero);

            Assert.True(isImpar);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsImpar_IngresarNumero_ObtenerTrueOrFalse(int numero, bool expectedResult)
        {
            Calculador calculador = new Calculador();

            var resultado = calculador.IsImpar(numero);

            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(5.2, 10.6)]//15.8
        [InlineData(5.4, 10.4)]//15.8
        [InlineData(5.6, 10.6)]//16.2
        public void SumarNumerosDouble_IngresarDosNumeros_ObtenerSuma(double numero1, double numero2)
        {
            Calculador calculador = new Calculador();

            double resultado = calculador.SumarNumerosDouble(numero1, numero2);

            Assert.Equal(15.8, resultado, 0);
        }

        [Fact]
        public void ObtenerRangoImpares_IngresarInicioFinal_ObtenerListaImpares()
        {
            Calculador calculador = new Calculador();

            List<int> listaEsperadaImpares = new() { 3, 5, 7 };
            List<int> resultado = calculador.ObtenerRangoImpares(3, 8);

            Assert.Multiple(() =>
            {
                Assert.Equal(listaEsperadaImpares, resultado);//si la lista resultado es igual a la lista esperada
                Assert.Contains(7, resultado);//si la lista contiene el numero 7
                Assert.NotEmpty(resultado);// Assert.That(resultado, Is.Not.Empty);//si la lista no está vacía
                Assert.Equal(3, resultado.Count);//Assert.That(resultado.Count, Is.EqualTo(3));//si la cantidad de elementos de la lista es 3
                Assert.DoesNotContain(6, resultado);//Assert.That(resultado, Has.No.Member(6));//si el numero 6 no hace parte de la lista
                Assert.Equal(resultado.OrderBy(x => x), resultado);//Assert.That(resultado, Is.Ordered);//si la lista está ordenada esta ordenada de manera ascendente
            });
        }
    }
}
