using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.NetUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : Controller
    {

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum (string firstNumber, string secondNumber)
        {
            if( IsNumeric(firstNumber) && IsNumeric(secondNumber) )
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return new OkObjectResult(sum.ToString());

            }
            return new BadRequestObjectResult("invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if( decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string valorNumerico)
        {
            double number;
            bool isNumber = double.TryParse(valorNumerico, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
