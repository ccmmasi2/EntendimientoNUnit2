using MathExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathExpertXUnitTest
{
    public class ClienteXUnitTests
    {
        private Cliente cliente;

        public ClienteXUnitTests()
        {
            cliente = new Cliente();
        }

        [Fact]
        public void SaludoCliente_IngresarNombreApellido_ObtenerSaludoNombreCompleto()
        {
            string saludo = cliente.SaludoCliente("Carlos", "Piedra");

            Assert.Equal("Hola, Carlos Piedra", saludo);
            Assert.Contains(",", saludo);//Assert.That(saludo, Does.Contain(","));//Contiene
            Assert.StartsWith("Hola", saludo);//Assert.That(saludo, Does.StartWith("Hola,"));//Empieza con
            Assert.EndsWith("Piedra", saludo);//Assert.That(saludo, Does.EndWith("Piedra"));//Termina con
            Assert.Matches("Hola, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", saludo);//Assert.That(saludo, Does.Match());
        }

        [Fact]
        public void SaludoCliente_NoPasarElNombre_LanzarException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.SaludoCliente("", "Piedra"));
            Assert.Equal("Parametro nombre está vacío", exceptionDetalle.Message);
        }

        [Fact]
        public void DetalleCliente_TotalComprasMenoresA100_ObtenerClienteBasico()
        {
            cliente.TotalCompras = 10;
            var resultado = cliente.DetalleCliente();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void DetalleCliente_TotalComprasMayoresA100_ObtenerClientePlatino()
        {
            cliente.TotalCompras = 110;
            var resultado = cliente.DetalleCliente();
            Assert.IsType<ClientePlatino>(resultado);
        }
    }
}
