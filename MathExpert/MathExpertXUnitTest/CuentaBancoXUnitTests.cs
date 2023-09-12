using MathExpert;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class CuentaBancoXUnitTests
    {
        private CuentaBanco cuenta;

        [Fact]
        public void Deposito_agregar100_ObtenerTrue()
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.Mensaje(""));

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);

            var resultado = cuentaBanco.Deposito(100);
            Assert.True(resultado);
            Assert.Equal(100, cuentaBanco.ObtenerBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Retiro_RetiroConBalance200_ObtenerTrue(double balance, double retiro)
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.LogBaseDatos(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x > 0))).Returns(true);

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);
            cuentaBanco.Deposito(balance);
            var resultado = cuentaBanco.Retiro(retiro);
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(200, 300)]
        public void Retiro_RetiroConBalance200_ObtenerFalse(double balance, double retiro)
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.LogBaseDatos(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x > 0))).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x < 0))).Returns(false);

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);
            cuentaBanco.Deposito(balance);
            var resultado = cuentaBanco.Retiro(retiro);
            Assert.False(resultado);
        }

        [Fact]
        public void Prueba_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogRegistro>();
            string mensajeSalida = "hola";
            logMock.Setup(x => x.MensajeRetornaString(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.Equal(mensajeSalida, logMock.Object.MensajeRetornaString("Hola"));
        }
    }
}
