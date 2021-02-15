using CoinTree.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoinTree.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoinTreeController : ControllerBase
    {
        private const string btcCoin = "BTC";
        private const string ethCoin = "ETH";
        private const string xrpCoin = "XRP";
        private const string cointreeAPI = "cointree";
        private const string cointreeAPIURl = "https://trade.cointree.com/api/prices/aud/";

        private readonly IHttpClientFactory clientFactory;

        private List<string> preferredCoins = new List<string> { btcCoin, ethCoin, xrpCoin };

        public CoinTreeController(IHttpClientFactory _clientFactory)
        {            
            clientFactory = _clientFactory;
        }

        [HttpGet]
        public IActionResult  Get()
        {
            return Ok(preferredCoins);
        }

        [Route("[action]/{coin}")]
        [HttpGet]
        public IActionResult GetCoinDetails(string coin)
        {
            try
            {
                var client = clientFactory.CreateClient(cointreeAPI);
                var response = client.GetAsync(string.Concat(cointreeAPIURl, coin)).Result;
                response.EnsureSuccessStatusCode();
                var responseStream = response.Content.ReadAsStreamAsync().Result;

                return Ok(
                    JsonSerializer.DeserializeAsync
                <CoinDetails>(responseStream).Result
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
