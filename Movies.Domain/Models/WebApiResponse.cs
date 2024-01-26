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

    public class APiResponseCode
    {
        public const string RecordNotFound = "404";
        public const string BadRequest = "400";
        public const string InternalServerError = "500";
        public const string Successful = "00";
        public const string Failed = "01";
        public const string DuplicateRecord = "26";
        public const string StatusOk = "200";
        public const string Created = "201";
        public const string InsufficientFund = "51";
        public const string DuplicateTransaction = "94";
        public const string BeneficiaryMismatch = "202";
        public const string InvalidTransaction = "12";
    }
}
