using MathExpert;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class CuentaBancoNUnitTests
    {
        private CuentaBanco cuenta;


        [SetUp]
        public void SetUp()
        {
            //cuentaBanco = new CuentaBanco(new LogRegistro());
        }

        //[Test]
        //public void Deposito_Agregar100_ObtenerTrue()
        //{
        //    var resultado = cuentaBanco.Deposito(100);
        //    Assert.IsTrue(resultado);
        //    Assert.That(cuentaBanco.ObtenerBalance, Is.EqualTo(100));    
        //}

        [Test]
        public void Deposito_agregar100_ObtenerTrue()
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.Mensaje(""));

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);


            var resultado = cuentaBanco.Deposito(100);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBanco.ObtenerBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_RetiroConBalance200_ObtenerTrue(double balance, double retiro)
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.LogBaseDatos(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x > 0))).Returns(true);

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);
            cuentaBanco.Deposito(balance);
            var resultado = cuentaBanco.Retiro(retiro);
            Assert.IsTrue(resultado);   
        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_RetiroConBalance200_ObtenerFalse(double balance, double retiro)
        {
            var logMock = new Mock<ILogRegistro>();
            logMock.Setup(x => x.LogBaseDatos(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x > 0))).Returns(true);
            logMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<double>(x => x < 0))).Returns(false);

            CuentaBanco cuentaBanco = new CuentaBanco(logMock.Object);
            cuentaBanco.Deposito(balance);
            var resultado = cuentaBanco.Retiro(retiro);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void Prueba_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogRegistro>();
            string mensajeSalida = "Hola";
            logMock.Setup(x => x.MensajeRetornaString(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MensajeRetornaString("Hola"), Is.EqualTo(mensajeSalida));
        }
    }
}
