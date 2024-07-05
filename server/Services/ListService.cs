using Todo.Models;
using Todo.Repositories;

namespace Todo.Services
{
    public class ListService
    {
        private readonly IListRepository _listRepository;

        public ListService(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<CardList>> GetAllAsync()
        {
            return await _listRepository.GetAllAsync();
        }

        public async Task<CardList> CreateCardList(CardList cardList)
        {
            return await _listRepository.CreateCardList(cardList);
        }

    }
}