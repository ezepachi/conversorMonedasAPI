using conversorMonedas.Entities;
using conversorMonedas.Models.Dtos;
using conversorMonedas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace conversorMonedas.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet]
    public IActionResult GetAllCurrencies()
    {
        var currencies = _currencyService.GetAllCurrencies();
        return Ok(currencies);
    }


    [HttpPost]
    public IActionResult PostCurrency([FromBody] Currency currency)
    {
        if (currency == null || string.IsNullOrEmpty(currency.Code))
        {
            return BadRequest("Invalid currency data.");
        }

        var result = _currencyService.AddCurrency(currency);

        if (result)
        {
            return Ok("Currency added successfully.");
        }
        else
        {
            return StatusCode(500, "An error occurred while adding the currency.");
        }
    }

    [HttpPut("{id}")]
    public IActionResult PutCurrency(int id, [FromBody] Currency currency)
    {
        if (currency == null || id != currency.Id)  
        {
            return BadRequest("Invalid currency data.");
        }

        var result = _currencyService.UpdateCurrency(id, currency);  

        if (result)
        {
            return Ok("Currency updated successfully.");
        }
        else
        {
            return NotFound("Currency not found.");
        }
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeleteCurrency(int id)
    {
        var result = _currencyService.DeleteCurrency(id);

        if (result)
        {
            return Ok("Currency deleted successfully.");
        }
        else
        {
            return NotFound("Currency not found.");
        }
    }

     
}