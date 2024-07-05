using Todo.Models;
using Microsoft.EntityFrameworkCore;

namespace Todo.Repositories
{
    public class ListRepository : IListRepository
    {

        private readonly AppDbContext _context;

        public ListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CardList>> GetAllAsync()
        {
            return await _context.CardLists.ToListAsync();
        }

        public async Task<CardList> CreateCardList(CardList cardList)
        {
            _context.CardLists.Add(cardList);
            await _context.SaveChangesAsync();
            return cardList;
        }
    }
}