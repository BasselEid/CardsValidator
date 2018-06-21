namespace Validator
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public CardType Type { get; set; }

        public Card()
        {

        }

        public Card(string number, int year, int month, CardType type = CardType.Unknown)
        {
            this.Number = number;
            this.Month = month;
            this.Year = year;
            this.Type = type;
        }

        public Card(string number, string date, CardType type = CardType.Unknown)
        {
            this.Number = number;
            this.Year = int.Parse(date.Substring(2));
            this.Month = int.Parse(date.Substring(0, 2));
            this.Type = type;
        }

    }
}