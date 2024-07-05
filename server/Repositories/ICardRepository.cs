using Todo.Models;

namespace Todo.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card> GetCardById(int id);
        Task<Card> CreateCard(Card card);
        Task<Card> UpdateCard(int id, Card card);
        Task<Card> MoveCard(int id, Card card);
        Task DeleteCard(int id);
    }
}