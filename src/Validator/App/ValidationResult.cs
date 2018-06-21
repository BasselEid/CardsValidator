namespace Validator
{
    public class ValidationResponse
    {
        public ValidationResult Result { get; set; }
        public CardType CardType { get; set; }

        public string ResultString => Result.ToString();
        public string CardTypeString => CardType.ToString();
    }

    public enum ValidationResult
    {
        Valid,
        Invalid,
        DoesNotExist
    }

    public enum CardType
    {
        Unknown,
        VisaCard,
        MasterCard,
        Amex,
        JCB,
    }
}