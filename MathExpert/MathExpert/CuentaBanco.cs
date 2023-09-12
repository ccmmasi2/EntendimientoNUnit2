using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class CuentaBanco
    {
        public double Balance { get; set; }
        private readonly ILogRegistro _logRegistro;

        public CuentaBanco(ILogRegistro logRegistro)
        {
            _logRegistro = logRegistro;
            Balance = 0.0;
        }

        public bool Deposito(double monto)
        {
            Balance += monto;
            _logRegistro.Mensaje("Deposito Realizado");
            return true;
        }

        public bool Retiro(double monto)
        {
            if (monto <= Balance)
            {
                _logRegistro.LogBaseDatos($"Monto de Retiro: {monto.ToString()}");
                Balance -= monto;
                return _logRegistro.LogBalanceDespuesRetiro(Balance);
            }
            return _logRegistro.LogBalanceDespuesRetiro(Balance - monto);
        }

        public double ObtenerBalance()
        {
            return Balance;
        }
    }
}
