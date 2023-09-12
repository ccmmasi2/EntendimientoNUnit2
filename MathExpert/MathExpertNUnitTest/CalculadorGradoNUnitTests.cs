using MathExpert;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class CalculadorGradoNUnitTests
    {
        private CalculadorGrado calculadorGrado;

        [SetUp]
        public void SetUp()
        {
            calculadorGrado = new CalculadorGrado();
        }

        [Test]
        public void ObtenerGrado_IngresarPuntaje95Asistencia90_ObtenerGradoA()
        {
            calculadorGrado.Puntaje = 95;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("A"));
        }

        [Test]
        public void ObtenerGrado_IngresarPuntaje85Asistencia90_ObtenerGradoB()
        {
            calculadorGrado.Puntaje = 85;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("B"));
        }

        [Test]
        public void ObtenerGrado_ingresarPuntaje65Asistencia90_ObtenerGradoC()
        {
            calculadorGrado.Puntaje = 65;
            calculadorGrado.PorcentajeAsistencia = 90;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("C"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void ObtenerGrado_IngresarValoresReprobar_ObtenerGradoF(int puntaje, int asistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = asistencia;

            string resultado = calculadorGrado.ObtenerGrado();

            Assert.That(resultado, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string ObtenerGrado_ValoresMultiples_ObtenerGrado(int puntaje, int asistencia)
        {
            calculadorGrado.Puntaje = puntaje;
            calculadorGrado.PorcentajeAsistencia = asistencia;

            return calculadorGrado.ObtenerGrado();
        }
    }
}
