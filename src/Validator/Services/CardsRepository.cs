using System;
using System.Linq;
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
            var card = this.db.Cards.FromSql("SP_CardsExists @p0", new[] { number });

                    // Console.WriteLine(card.FirstOrDefaultAsync());
            return card.FirstOrDefault() != null;
        }
    }
}