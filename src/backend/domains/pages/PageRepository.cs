// backend/domains/pages/PageRepository.cs
using Microsoft.EntityFrameworkCore;

using whoknows_c_sharp.db;
using whoknows_c_sharp.domains.pages;

namespace whoknows_c_sharp.domains.pages
{
    public class PageRepository : IRepository<Page>
    {
        private readonly WhoKnowsContext _context;

        public PageRepository(WhoKnowsContext context)
        {
            _context = context;
        }

        public async Task<Page?> GetByIdAsync<TId>(TId id) => 
            await _context.Pages.FindAsync(id);

        public async Task<IEnumerable<Page>> GetAllAsync() =>
            await _context.Pages.ToListAsync();

        public async Task AddAsync(Page entity)
        {
            await _context.Pages.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Page entity)
        {
            _context.Pages.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Page entity)
        {
            _context.Pages.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}