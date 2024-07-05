using Todo.Models;
using Todo.Repositories;

namespace Todo.Services
{
    public class CardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            return await _cardRepository.GetCardById(id);
        }

        public async Task<Card> CreateCard(Card card)
        {
            return await _cardRepository.CreateCard(card);
        }

        public async Task<Card> UpdateCard(int id, Card card)
        {
            return await _cardRepository.UpdateCard(id, card);
        }

        public async Task<Card> MoveCard(int id, Card card)
        {
            return await _cardRepository.MoveCard(id, card);
        }

        public async Task DeleteCard(int id)
        {
            await _cardRepository.DeleteCard(id);
        }

    }
}
