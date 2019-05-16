using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeTime.Models;
using Newtonsoft.Json;
using Serilog;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeTime.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, IActionFilter
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string[] _validParameters;
        private bool _IdQueryFound;

        public EmployeesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _validParameters = new string[] { "search", "filter", "orderby", "top", "skip", "count" };
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get(int? externalCode)
        {
            if (!_IdQueryFound)
                return BadRequest(new Error("UserId query not found", "404"));
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                string uri = client.BaseAddress + $"/EmployeeTime({externalCode})";
                uri += Request.QueryString;
                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    RootObject JSONWrapper = JsonConvert.DeserializeObject <RootObject>(responseString);
                    return Ok(JSONWrapper.TimeSheetWrapper);
                }
            }
            return BadRequest(new Error("Something went wrong"));
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
