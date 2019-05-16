using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTime.Models
{
    public class Error
    {
        public Error(string _message, string _code = "unknown")
        {
            message = _message;
            code = _code;
        }
        public string message;
        public string code;
    }
}
