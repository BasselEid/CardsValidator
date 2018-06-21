using System.Collections.Generic;
using Validator.Validators;

namespace Validator.Services
{
    public class CardValidator
    {

        public CardValidator(CardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }


        public List<IValidator> Validators = new List<IValidator>
        {
            new MasterCardValidator(),
            new VisaCardValidator(),
            new AmexCardValidator(),
            new JCBCardValidator(),
        };
        private readonly CardsRepository cardsRepository;

        public ValidationResponse Validate(Card card)
        {
            foreach (var validator in Validators)
            {
                if (validator.Match(card))
                {
                    var result = validator.Validate(card) ? ValidationResult.Valid : ValidationResult.Invalid;

                    // TODO: check the db here
                    var exist = this.cardsRepository.Exists(card.Number);

                    if (!exist)
                    {
                        result = ValidationResult.DoesNotExist;
                    }

                    return new ValidationResponse
                    {
                        Result = result,
                        CardType = validator.GetCardType(),
                    };

                }
            }


            return new ValidationResponse
            {
                Result = ValidationResult.Invalid,
                CardType = CardType.Unknown
            };
        }



    }
}