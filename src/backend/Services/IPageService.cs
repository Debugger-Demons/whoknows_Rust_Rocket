
// Services/IPageService.cs

using whoknows_c_sharp.Models;

namespace whoknows_c_sharp.Services;

public interface IPageService
{
    Task<IEnumerable<Page>> SearchPagesAsync(string query);
    Task<Page?> GetPageByTitleAsync(string title);
    Task<IEnumerable<Page>> GetPagesByLanguageAsync(string language);
    // Add more business logic methods as needed
}
