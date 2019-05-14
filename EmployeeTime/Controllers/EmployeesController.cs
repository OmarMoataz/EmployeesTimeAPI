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
        public string Get([FromHeader] string APIKey, string search, string filter, string orderby, int? top, int? skip, bool? count, int? id)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                client.DefaultRequestHeaders.Add("APIKey", APIKey);
                string uri = client.BaseAddress + $"/EmployeeTime({id})";
                uri += Request.QueryString;

                var response = client.GetAsync(uri).Result;
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
