using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeTime.Models;
using Newtonsoft.Json;
using Serilog;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace EmployeeTime.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string[] _validParameters;

        public EmployeesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _validParameters = new string[] { "id", "search", "filter", "orderby", "top", "skip", "count" };
        }

        // GET: api/Employee
        [HttpGet]
        public string Get(int? externalCode)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                string uri = client.BaseAddress + $"/EmployeeTime({externalCode})";
                uri += Request.QueryString;

                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return JsonConvert.SerializeObject((JsonConvert.DeserializeObject<IEnumerable<Result>>(responseString)));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Log.Error("User tried to access API without valid token.");
                    return JsonConvert.SerializeObject("You need a valid API token to access Timesheet data.");
                }
            }
            return JsonConvert.SerializeObject("Something went wrong.");
        }
    }
}
