using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Add additional information to the returning result, like success or exception errors. The front-end can interact with this using HTTP interceptors. Helpful in try-catch blocks when you catch an exception
namespace C__RPG_Backend.models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}