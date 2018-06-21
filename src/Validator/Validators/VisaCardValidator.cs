using System;

namespace Validator.Validators
{
    public class VisaCardValidator : IValidator
    {
        public CardType GetCardType()
        {
            return CardType.VisaCard;
        }

        public bool Match(Card card)
        {
            return card.Number.StartsWith("4");
        }

        public bool Validate(Card card)
        {
            return DateTime.IsLeapYear(card.Year) &&  NumberHelper.checkLuhn(card.Number) && DateHelper.CheckIfLessThanToday(card.Year, card.Month);
        }
    }
}