using MathExpert;
using NUnit.Framework;
using System.Security.Cryptography;

namespace MathExpertNUnitTest
{
    [TestFixture]
    public class ClienteNUnitTests
    {
        private Cliente cliente;

        [SetUp]
        public void SetUp()
        {
            cliente = new Cliente();
        }

        [Test]
        public void SaludoCliente_IngresarNombreApellido_ObtenerSaludoNombreCompleto()
        {
            string saludo = cliente.SaludoCliente("Carlos", "Piedra");

            Assert.AreEqual(saludo, "Hola, Carlos Piedra");
            Assert.That(saludo, Is.EqualTo("Hola, Carlos Piedra"));
            Assert.That(saludo, Does.Contain(","));//Contiene
            Assert.That(saludo, Does.StartWith("Hola,"));//Empieza con
            Assert.That(saludo, Does.EndWith("Piedra"));//Termina con
            Assert.That(saludo, Does.Match("Hola, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void SaludoCliente_NoPasarElNombre_LanzarException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.SaludoCliente("", "Piedra"));
            Assert.AreEqual("Parametro nombre está vacío", exceptionDetalle.Message);

            Assert.That(() => cliente.SaludoCliente("", "Piedra"),
                            Throws.ArgumentException.With.Message.EqualTo("Parametro nombre está vacío"));
        }

        [Test]
        public void DetalleCliente_TotalComprasMenoresA100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 10;
            var resultado = cliente.DetalleCliente();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void DetalleCliente_TotalComprasMayoresA100_ObtenerClientePlatino()
        {
            cliente.TotalCompras = 110;
            var resultado = cliente.DetalleCliente();
            Assert.That(resultado, Is.TypeOf<ClientePlatino>());
        }
    }
}
