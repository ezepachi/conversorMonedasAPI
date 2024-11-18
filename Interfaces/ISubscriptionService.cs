using conversorMonedas.Entities;

namespace conversorMonedas.Services.Interfaces;

public interface ISubscriptionService
{

    bool CanUserConvert(int userId);
    Subscription GetUserSubscription(int userId);
    void UpdateSubscription(int userId, Subscription newSubscription);

}