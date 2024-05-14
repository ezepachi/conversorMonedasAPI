using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;

namespace ConversorDeMonedasBack.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ConversorContext  _context;

        public SubscriptionService(ConversorContext context)
        {
            _context = context;
        }

        public List<Subscriptions> GetAllSubscriptions()
        {
            // Lógica para recuperar todas las suscripciones desde la base de datos

            return _context.Subscriptions.Where(s => s.Id != 10).ToList();
        }

        public Subscriptions? GetSubscriptionById(int IdSuscription)
        {
            // Lógica para recuperar una suscripción por su ID desde la base de datos
            return _context.Subscriptions.FirstOrDefault(s => s.Id == IdSuscription);
        }

        public int GetSubscriptionAmountOfConversions(int subscriptionId)
        {
            // Lógica para recuperar la cantidad máxima de conversiones permitidas para una suscripción desde la base de datos
        }

        List<Subscriptions> ISubscriptionService.GetAllSubscriptions()
        {
            throw new NotImplementedException();
        }

        Subscriptions? ISubscriptionService.GetSubscriptionById(int IdSuscription)
        {
            throw new NotImplementedException();
        }
    }
}
