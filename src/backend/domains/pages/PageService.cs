using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using whoknows_c_sharp.domains.pages;

namespace whoknows_c_sharp.domains.pages
{
    public class PageService : IPageService
    {
        private readonly IRepository<Page> _repo;

        public PageService(IRepository<Page> repo) 
        {
            _repo = repo;
        }

        /*
                Task<IEnumerable<Page>> SearchPagesAsync(string query);
                Task<Page?> GetPageByTitleAsync(string title);
                Task<IEnumerable<Page>> GetPagesByLanguageAsync(string language);
        */

        


        // SearchPages    
        public async Task<IEnumerable<Page>> SearchPages(string query)
        {
            var pages = await _repo.GetAllAsync();
            return pages.Where(p => 
                p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                p.Content.Contains(query, StringComparison.OrdinalIgnoreCase)
            );
        }

        // Let's implement the other operations mentioned in the comments
        public async Task<IEnumerable<Page>> GetRecentPages(int count = 10)
        {
            var pages = await _repo.GetAllAsync();
            return pages.OrderByDescending(p => p.LastUpdated).Take(count);
        }

        public async Task<Page?> GetPageById<TId>(TId id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Page>> GetAllPages()
        {
            return await _repo.GetAllAsync();
        }

        public async Task CreatePage(Page page)
        {
            ValidatePage(page);
            await _repo.AddAsync(page);
        }

        public async Task UpdatePage(Page page)
        {
            ValidatePage(page);
            await _repo.UpdateAsync(page);
        }

        public async Task DeletePage(Page page)
        {
            await _repo.DeleteAsync(page);
        }

        private void ValidatePage(Page page)
        {
            if (string.IsNullOrWhiteSpace(page.Title))
                throw new ArgumentException("Title cannot be empty");
            
            if (string.IsNullOrWhiteSpace(page.Content))
                throw new ArgumentException("Content cannot be empty");
            
            if (string.IsNullOrWhiteSpace(page.Url))
                throw new ArgumentException("URL cannot be empty");
            
            if (!new[] { "en", "da" }.Contains(page.Language))
                throw new ArgumentException("Language must be either 'en' or 'da'");
        }
    }
}