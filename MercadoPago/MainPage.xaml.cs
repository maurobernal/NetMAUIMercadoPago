using System.Security.Policy;
using MercadoPago;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Config;

namespace MercadoPago;



public partial class MainPage : ContentPage
{
    public string URLMP;
    
	int count = 0;

	public MainPage()
	{
		

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        MercadoPagoConfig.AccessToken = "TEST-3155291963624938-052717-d1b268830ca264eefd7cdfeb65a5535b-116392764";

        PreferenceItemRequest item = new()
        {
            Title = "Producto 123",
            Quantity = 1,
            CurrencyId = "ARS",
            UnitPrice = Convert.ToDecimal(1000.25),
            PictureUrl = "",
            Id = "123123".ToString(),


        };
        

        var list_Items = new List<PreferenceItemRequest>();
        list_Items.Add(item);


        var payer = new PreferencePayerRequest()
        {
            Address = new AddressRequest()
            {
                StreetName = "Calle 123",
                StreetNumber = "123",
                ZipCode = "5501"
            },
            Email = "info@maurobernal.com.ar",
            Name = "Mauro Bernal"
        };

        var backUrls = new PreferenceBackUrlsRequest()
        {
            Failure = "",
            Pending = "",
            Success = "",

        };

        var preferenceRequest = new PreferenceRequest
        {
            NotificationUrl = "https://",
            BackUrls = backUrls,
            Payer = payer,
            Expires = true,
            ExpirationDateFrom = DateTime.Now,
            ExpirationDateTo = DateTime.Now.AddMinutes(10),
            Items = list_Items,
        };

       

        var client = new PreferenceClient();
        var preference =  client.CreateAsync(preferenceRequest).Result;

        URLMP = preference.InitPoint;
        
    }
}


