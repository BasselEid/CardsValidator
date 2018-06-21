namespace Validator.Validators
{
    public class AmexCardValidator : IValidator
    {
        public CardType GetCardType()
        {
            return CardType.Amex;
        }

        public bool Match(Card card)
        {
            return card.Number.StartsWith("3") && card.Number.Length == 15;
        }

        public bool Validate(Card card)
        {
            return true;
        }
    }
}