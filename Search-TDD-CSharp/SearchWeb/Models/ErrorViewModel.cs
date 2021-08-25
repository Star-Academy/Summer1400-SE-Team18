using System;

namespace SearchWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool IsRequiredIdNullOrEmpty => !string.IsNullOrEmpty(RequestId);
    }
}