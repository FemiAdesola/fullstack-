using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.common
{
    public class Response<T>
    {
        public T Data { get; set; } = default!;
        public bool Succeeded { get; set; } = default!;
        public string[] Errors { get; set; } = default!;
        public string Message { get; set; } = default!;

        // public Response(TModel item)
        // {

        // }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null!;
            Data = data;
        }
    }
}