
// Services/PageService.cs
using whoknows_c_sharp.Models;
using whoknows_c_sharp.Services;
using whoknows_c_sharp.Repositories;
namespace whoknows_c_sharp.Services;

public class PageService : IPageService
{
    private readonly IRepository<Page> _pageRepository;

    public PageService(IRepository<Page> pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<IEnumerable<Page>> SearchPagesAsync(string query)
    {
        var pages = await _pageRepository.GetAllAsync();
        return pages.Where(p => 
            p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            p.Content.Contains(query, StringComparison.OrdinalIgnoreCase)
        );
    }

    public async Task<Page?> GetPageByTitleAsync(string title)
    {
        return await _pageRepository.GetByIdAsync(title);
    }

    public async Task<IEnumerable<Page>> GetPagesByLanguageAsync(string language)
    {
        var pages = await _pageRepository.GetAllAsync();
        return pages.Where(p => p.Language.Equals(language, StringComparison.OrdinalIgnoreCase));
    }
}