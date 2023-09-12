using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertMSTest
{
    [TestClass]
    public class CalculadorMSTests
    {
        [TestMethod]
        public void SumarNumeros_IngresarDosNumeros_ObtenerSuma()
        {
            //Arrenge
            Calculador calculador = new Calculador();

            //Act
            int resultado = calculador.SumarNumeros(5, 6);

            //Assert
            Assert.AreEqual(11, resultado);
        }
    }
}
