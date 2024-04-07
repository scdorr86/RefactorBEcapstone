using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RefactorBEcapstone
{
    public class ApiResponse<T>
    {
        public static ApiResponse<T> SuccessResponse(T data, string message) => new ApiResponse<T>(data, message);
        public static ApiResponse<T> BadRequest(string errorMessage) => new ApiResponse<T>(errorMessage);
        public static ApiResponse<T> Unknown(string errorMessage) => new ApiResponse<T>(errorMessage);
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        internal ApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
            Success = true;
        }

        private ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
    public class ApiSearchResponse<T> : ApiResponse<T>
    {
        public int TotalCount { get; set; }
        public ApiSearchResponse(T data, int count, string message) : base(data, message)
        {
            TotalCount = count;
        }
    }
}

