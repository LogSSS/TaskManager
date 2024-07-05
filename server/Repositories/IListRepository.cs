using Todo.Models;

namespace Todo.Repositories
{
    public interface IListRepository
    {
        Task<IEnumerable<CardList>> GetAllAsync();
        Task<CardList> CreateCardList(CardList cardList);
    }
}