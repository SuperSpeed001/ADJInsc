using System;

namespace ADJInsc.Models.ViewModels
{
    public class ApiException: Exception
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }
}
