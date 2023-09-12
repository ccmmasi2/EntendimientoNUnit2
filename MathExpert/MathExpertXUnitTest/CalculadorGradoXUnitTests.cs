using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CalculadorGradoXUnitTests
    {
        private CalculadorGrado calculadorGrado;

        public CalculadorGradoXUnitTests()
        {
            calculadorGrado = new CalculadorGrado();
        }

        [Fact]
        public void ObtenerGrado_IngresarPuntaje95Asistencia90_ObtenerGradoA()
        {
            calculadorGrado.Puntaje = 95;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("A", resultado);
        }

        [Fact]
        public void ObtenerGrado_IngresarPuntaje85Asistencia90_ObtenerGradoB()
        {
            calculadorGrado.Puntaje = 85;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("B", resultado);
        }

        [Fact]
        public void ObtenerGrado_ingresarPuntaje65Asistencia90_ObtenerGradoC()
        {
            calculadorGrado.Puntaje = 65;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("C", resultado);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void ObtenerGrado_IngresarValoresReprobar_ObtenerGradoF(int puntaje, int asistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = asistencia;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.Equal("F", resultado);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void ObtenerGrado_ValoresMultiples_ObtenerGrado(int puntaje, int asistencia, string expectedResult)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = asistencia;

            var resultado = calculadorGrado.ObtenerGrado();
            Assert.Equal(expectedResult, resultado);    
        }
    }
}
