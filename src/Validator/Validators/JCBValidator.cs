namespace Validator.Validators
{
    public class JCBCardValidator : IValidator
    {
        public CardType GetCardType()
        {
            return CardType.JCB;
        }

        public bool Match(Card card)
        {
            return card.Number.StartsWith("3") && card.Number.Length == 16;
        }

        public bool Validate(Card card)
        {
            return  NumberHelper.checkLuhn(card.Number) && DateHelper.CheckIfLessThanToday(card.Year, card.Month);
        }
    }
}