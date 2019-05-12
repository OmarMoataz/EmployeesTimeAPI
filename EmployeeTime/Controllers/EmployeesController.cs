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

namespace EmployeeTime.Controllers
{
    [Route("api/[controller]/{search?}/{filter?}/{orderby?}/{top?}/{skip?}/{count?}")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public EmployeesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: api/Employee
        [HttpGet]
        public string Get(string search, string filter, string orderby, int? top, int? skip, int? count, [FromHeader] string APIKey)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                //client.DefaultRequestHeaders.Add("APIKey", APIKey);
                var response = client.GetAsync(client.BaseAddress + "/EmployeeTime").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Log.Error("User tried to access API without valid token");
                    return "You need a valid API token to access Timesheet data.";
                }
            }
            return "Something went wrong.";
        }
    }
}
