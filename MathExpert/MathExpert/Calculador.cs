namespace MathExpert
{
    public class Calculador
    {
        public List<int> ListaRango = new ();

        public int SumarNumeros(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public double SumarNumerosDouble(double numero1, double numero2)
        {
            return numero1 + numero2;   
        }

        public bool IsImpar(int numero)
        {
            return numero % 2 != 0;
        }

        public List<int> ObtenerRangoImpares(int inicio, int final)
        {
            ListaRango.Clear();

            for (int i = inicio; i <= final; i++)
            {
                if(i % 2 != 0)
                {
                    ListaRango.Add(i);
                }
            }

            return ListaRango;
        }
    }
}