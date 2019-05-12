using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeTime.Models;
using Newtonsoft.Json;

namespace EmployeeTime.Controllers
{
    [Route("api/[controller]")]
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
        //[Route("{top:int:min(1)}/{skip:int:min(1)}/{count:int:min(1)}")]
        public string Get(string search, string filter, string orderby, int? top, int? skip, int? count)
        {
            using (var client = _clientFactory.CreateClient("SapBusinessHub"))
            {
                var response = client.GetAsync(client.BaseAddress + "/EmployeeTime").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
            }
            return "Error";
        }
    }
}
