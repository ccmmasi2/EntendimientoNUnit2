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
    public class LogRegistroNUnitTests
    {
        [Test]
        public void Prueba_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogRegistro>();
            string mensajeSalida = "hola";
            logMock.Setup(x => x.MensajeRetornaString(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MensajeRetornaString("Hola"), Is.EqualTo(mensajeSalida));
        }
    }
}
