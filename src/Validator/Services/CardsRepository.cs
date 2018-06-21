using Microsoft.EntityFrameworkCore;
using Validator.Data;

namespace Validator
{
    public class CardsRepository
    {
        private readonly ApplicationDbContext db;

        public CardsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Exists(string number)
        {
            var card = this.db.Cards.FromSql("SP_CardExists @p0", new[] { number });

            return card != null;
        }
    }
}