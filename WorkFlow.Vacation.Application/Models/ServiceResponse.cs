using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Vacation.Application.Models
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public static ServiceResponse<T> Ok(T data, string message = "")
        {
            return new ServiceResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = 200,
                Data = data
            };
        }

        public static ServiceResponse<T> Error(string message, int statusCode = 400)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
                Data = default
            };
        }
    }

}
