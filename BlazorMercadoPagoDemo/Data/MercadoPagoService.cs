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
                UnitPrice = 3000
            },
        };
        preferenceRequest.PaymentMethods = new PreferencePaymentMethodsRequest()
        {
            Installments = 1
        };
        /*
        preferenceRequest.BackUrls = new PreferenceBackUrlsRequest()
        {
            Success = $"https://example.com/success",
            Failure = $"https://example.com/failure",
            Pending = $"https://example.com/pending"
        };
        preferenceRequest.AutoReturn = "approved";
        preferenceRequest.NotificationUrl = $"https://example.com/api/notifications";
        */
        preferenceRequest.Expires = true;
        preferenceRequest.ExpirationDateTo = DateTime.Now.AddDays(1);
        preferenceRequest.StatementDescriptor = "Company Name";
        var preferenceClient = new PreferenceClient();
        var preference = await preferenceClient.CreateAsync(preferenceRequest);
        return preference.InitPoint;
    }
}
