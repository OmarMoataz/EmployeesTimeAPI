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

namespace EmployeeTime.Controllers
{
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
        public string Get([FromHeader] string APIKey, string search, string filter, string orderby, int? top, int? skip, int? count, int? id = null)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                client.DefaultRequestHeaders.Add("APIKey", APIKey);
                StringBuilder buildUri = new StringBuilder(client.BaseAddress + $"/EmployeeTime({id})");
                string uri = client.BaseAddress + $"/EmployeeTime({id})";
                var response = client.GetAsync(client.BaseAddress + $"/EmployeeTime({id})").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Log.Information("User tried to access API without valid token");
                    return "You need a valid API token to access Timesheet data.";
                }
            }
            return "Something went wrong.";
        }
    }
}
