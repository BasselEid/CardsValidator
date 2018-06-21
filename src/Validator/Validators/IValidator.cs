namespace Validator.Validators
{
    public interface IValidator
    {
        bool Match(Card card);
        bool Validate(Card card);
        CardType GetCardType();
    }
}