using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeTime.Models;
using Newtonsoft.Json;
using Serilog;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using EmployeeTime.Configuration;
using System.Linq;

namespace EmployeeTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, IActionFilter
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<Config> _config;
        private bool _IdQueryFound;

        public EmployeesController(IHttpClientFactory clientFactory, IOptions<Config> config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get(int? externalCode)
        {
            if (!_IdQueryFound)
                return BadRequest(new Error("UserId query not found", "404"));
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                client.BaseAddress = new System.Uri(_config.Value.ApiUrl);
                client.DefaultRequestHeaders.Add("APIKey", _config.Value.ApiKey);
                string uri = client.BaseAddress + $"({externalCode})";
                uri += Request.QueryString;
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    RootObject JSONWrapper = JsonConvert.DeserializeObject<RootObject>(responseString);
                    return Ok(JSONWrapper.TimeSheetWrapper);
                }
            }
            return BadRequest(new Error("Something went wrong"));
        }


        [Route("GetById")]
        public IActionResult Get(int id)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                client.BaseAddress = new System.Uri(_config.Value.ApiUrl);
                client.DefaultRequestHeaders.Add("APIKey", _config.Value.ApiKey);
                string uri = client.BaseAddress + $"?$filter= userId eq {Request.Query["id"]}";
                var response = client.GetAsync(uri).Result;
                string responseString = response.Content.ReadAsStringAsync().Result;
                RootObject JSONWrapper = JsonConvert.DeserializeObject<RootObject>(responseString);
                return Ok(JSONWrapper.TimeSheetWrapper);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string[] Pairs = Request.QueryString.Value.Split("&");
            _IdQueryFound = false;
            for (int i = 0; i < Pairs.Length; i++)
            {
                if (Pairs[i].Contains("$filter=userId%20eq"))
                {
                    _IdQueryFound = true;
                    break;
                }
            }
        }
    }
}
