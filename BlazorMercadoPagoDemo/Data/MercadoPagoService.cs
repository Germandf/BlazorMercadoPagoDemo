using MercadoPago.Client.Preference;

namespace BlazorMercadoPagoDemo.Data;

public interface IMercadoPagoService
{
    Task<string> GenerateMercadoPagoLink();
}

public class MercadoPagoService : IMercadoPagoService
{
    public async Task<string> GenerateMercadoPagoLink()
    {
        var preferenceRequest = new PreferenceRequest();
        preferenceRequest.Items = new List<PreferenceItemRequest>
        {
            new PreferenceItemRequest
            {
                Id = "1234",
                Title = "Invoice",
                Quantity = 1,
                CurrencyId = "ARS",
                UnitPrice = 500
            },
        };
        preferenceRequest.BackUrls = new PreferenceBackUrlsRequest()
        {
            Success = $"localhost:7218/?status=success",
            Failure = $"localhost:7218/?status=failure",
            Pending = $"localhost:7218/?status=pending"
        };
        preferenceRequest.PaymentMethods = new PreferencePaymentMethodsRequest()
        {
            Installments = 1
        };
        preferenceRequest.AutoReturn = "approved";
        preferenceRequest.NotificationUrl = $"localhost:7218/api/notifications";
        preferenceRequest.Expires = true;
        preferenceRequest.ExpirationDateTo = DateTime.Now.AddDays(1);

        var preferenceClient = new PreferenceClient();
        var preference = await preferenceClient.CreateAsync(preferenceRequest);
        return preference.InitPoint;
    }
}
