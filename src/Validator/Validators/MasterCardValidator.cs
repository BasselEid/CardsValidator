using System;

namespace Validator.Validators
{
    public class MasterCardValidator : IValidator
    {
        public CardType GetCardType()
        {
            return CardType.MasterCard;
        }

        public bool Match(Card card)
        {
            return card.Number.StartsWith("5");
        }

        public bool Validate(Card card)
        {
            return NumberHelper.IsPrime(card.Year);
        }
    }
}