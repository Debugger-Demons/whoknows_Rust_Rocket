// Services/IPageService.cs
using whoknows_c_sharp.domains.pages;

namespace whoknows_c_sharp.domains.pages;

public interface IPageService
{
    Task<IEnumerable<Page>> SearchPages(string query);
        
    // Add more business logic methods as needed
}
