namespace conversorMonedas.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando una moneda no es encontrada.
    /// </summary>
    public class CurrencyNotFoundException : Exception
    {
        public CurrencyNotFoundException(string message) : base(message)
        {
        }
    }
}