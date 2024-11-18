using System.Linq;
using conversorMonedas.Data;
using conversorMonedas.Entities;
using conversorMonedas.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SubscriptionService : ISubscriptionService
{
    private readonly ConversorContext _context;

    public SubscriptionService(ConversorContext context)
    {
        _context = context;
    }

    public bool CanUserConvert(int userId)
    {
        var user = _context.Users
            .Include(u => u.Subscription)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null || user.Subscription == null)
            return false;

        // Contar las conversiones de hoy para el usuario
        var conversionCountToday = _context.Conversions
            .Count(c => c.UserId == userId && c.Timestamp.Date == DateTime.Today);

        // Verificar si supera el límite diario
        return user.Subscription.ConversionLimit == -1 || conversionCountToday < user.Subscription.ConversionLimit;
    }

    public Subscription GetUserSubscription(int userId)
    {
        return _context.Subscriptions.FirstOrDefault(s => s.UserId == userId);
    }

    public void UpdateSubscription(int userId, Subscription newSubscription)
    {
        var user = _context.Users.Include(u => u.Subscription).FirstOrDefault(u => u.Id == userId);

        if (user?.Subscription != null)
        {
            user.Subscription.Type = newSubscription.Type;
            user.Subscription.ConversionLimit = newSubscription.ConversionLimit;
            user.Subscription.ExpirationDate = newSubscription.ExpirationDate;

            _context.SaveChanges();
        }
    }
}