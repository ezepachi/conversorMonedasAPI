namespace conversorMonedas.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando el límite de conversiones por día está completo.
    /// </summary>
    public class ConversionLimitReachedException : Exception
    {
        public ConversionLimitReachedException(string message) : base(message)
        {
        }
    }
}