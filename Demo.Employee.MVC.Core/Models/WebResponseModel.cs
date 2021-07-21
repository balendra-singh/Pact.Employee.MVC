using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Employee.MVC.Core.Models
{
    public class WebResponseModel<T>
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string MessageType
        {
            get
            {
                if (IsSuccess)
                    return "success";

                return "danger";
            }
        }
        public T ResponseData { get; set; }
    }
}
