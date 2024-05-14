using conversorMonedas.Entities;

namespace conversorMonedas.Services.Interfaces
{
    public interface ISubscriptionService
    {
        List<Subscriptions> GetAllSubscriptions();
        Subscriptions? GetSubscriptionById(int IdSuscription);

        int GetSubscriptionAmountOfConversions(int IdSuscription);
    }
}
