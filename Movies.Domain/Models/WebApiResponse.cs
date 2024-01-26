using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Models
{
    public class WebApiResponse
    {
        public string StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
