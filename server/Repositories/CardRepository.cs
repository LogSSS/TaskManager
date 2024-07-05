using Todo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Todo.Repositories
{
    public class CardRepository : ICardRepository
    {

        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            return card;
        }

        public async Task<Card> CreateCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateCard(int id, Card card)
        {
            var existingCard = await _context.Cards.FindAsync(id);
            if (existingCard == null)
                return null;

            existingCard.Name = card.Name;

            _context.Cards.Update(existingCard);
            await _context.SaveChangesAsync();

            return existingCard;
        }

        public async Task<Card> MoveCard(int id, Card card)
        {
            var existingCard = await _context.Cards.FindAsync(id);
            if (existingCard == null)
                return null;

            existingCard.ListId = card.ListId;

            _context.Cards.Update(existingCard);
            await _context.SaveChangesAsync();

            return existingCard;
        }

        public async Task DeleteCard(int id)
        {
            var task = await _context.Cards.FindAsync(id);
            if (task == null)
                return;

            _context.Cards.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}