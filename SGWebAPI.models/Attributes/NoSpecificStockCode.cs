using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Models.Attributes
{
    public class NoSpecificStockCode : ValidationAttribute
    {
        private string _stockCode { get; set; }

        public NoSpecificStockCode(string stockCode)
        {
            _stockCode = stockCode;
        }

        public override bool IsValid(object? value)
        {
            return !(value?.ToString() == _stockCode);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} should not be {_stockCode}";
        }
    }
}
