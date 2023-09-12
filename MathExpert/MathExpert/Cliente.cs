using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class Cliente
    {
        public string Saludo {  get; set; }
        public int TotalCompras { get; set; }

        public string SaludoCliente(string nombre, string apellido)
        {
            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Parametro nombre está vacío");
            }

            Saludo = $"Hola, {nombre} {apellido}";
            return Saludo;
        }

        public ClienteTipo DetalleCliente()
        {
            if(TotalCompras < 100)
            {
                return new ClienteBasico();
            }
            return new ClientePlatino();
        }
    }
}
