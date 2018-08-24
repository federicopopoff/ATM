using System;

namespace ATM.Web.Models
{
    public class ErrorViewModel
    {
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string RequestId { get; set; }
    }
}