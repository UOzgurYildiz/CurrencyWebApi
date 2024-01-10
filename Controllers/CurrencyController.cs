using CurrencyApplication.ApplicationConfig;
using CurrencyApplication.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetExchange(string fromCurrency)
    {
        string body="";
        var client = new HttpClient();
        var request = new HttpRequestMessage
            
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{Config.BaseURL}/latest?from={fromCurrency}"),
            Headers =
            {
                { "X-RapidAPI-Key", $"{Config.APIKEY}" },
                { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            body = await response.Content.ReadAsStringAsync();
        }

        return Ok(body);
    }
    
    [HttpGet("fromto")]
    public async Task<IActionResult> GetExchangeRates([FromQuery] CurrencyRequestModel currencyRequestModel)
    {
        string body = "";
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{Config.BaseURL}/convert?from={currencyRequestModel.FromCurrency}&to={currencyRequestModel.ToCurrency}&amount={currencyRequestModel.Amount}"),
            Headers =
            {
                { "X-RapidAPI-Key", "43ec4d652dmshf128ad18dc0d7c3p144ab6jsn219d44a5a794" },
                { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }

        return Ok(body);
    }

    //Desteklenen currency tipleri için

    [HttpGet("symbols")]
    public async Task<IActionResult> GetSymbols()
    {
        string body = "";
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
	        Method = HttpMethod.Get,
	        RequestUri = new Uri($"{Config.BaseURL}/symbols"),
	        Headers =
                {
                    { "X-RapidAPI-Key", "43ec4d652dmshf128ad18dc0d7c3p144ab6jsn219d44a5a794" },
                    { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
                },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }
        return Ok(body);
    }


}