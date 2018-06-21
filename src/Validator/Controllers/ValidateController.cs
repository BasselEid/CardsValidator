using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validator.Services;

namespace Validator
{
    public class ValidateController : Controller
    {
        private readonly CardValidator validator;

        public ValidateController(CardValidator validator)
        {
            this.validator = validator;
        }

        public ActionResult CreditCard(string number, string date)
        {
            var response = this.validator.Validate(new Card(number, date));
            var responseObj = new {Result = response.ResultString, CardType = response.CardTypeString};
            if (response.Result == ValidationResult.DoesNotExist)
            {
                return NotFound(responseObj);
            }
            else if (response.Result == ValidationResult.Invalid)
            {
                return BadRequest(responseObj);
            }

            return Ok(responseObj);
        }

    }
}