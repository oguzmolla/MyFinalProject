using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /* set özelliğini koymarayak dışarda set edilmesini önledik
         * ama constractur içinde set edilebilir 
         */
        // 2 tane ctor u biri message vermek istemezse diye yaptık
        public Result(bool success, string message = null):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
