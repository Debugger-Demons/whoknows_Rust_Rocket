# ASP.NET Core Implementation Details

## Dependency Injection
Unlike Spring's annotation-based DI, ASP.NET Core uses a built-in DI container configured in Program.cs:

```csharp
// Registration
builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IRepository<Page>, PageRepository>();

// Usage in controllers
public class PagesController : ControllerBase
{
    private readonly IPageService _pageService;
    
    // Constructor injection
    public PagesController(IPageService pageService)
    {
        _pageService = pageService;
    }
}
```

### Service Lifetimes
```csharp
// Transient: New instance for every request
builder.Services.AddTransient<IMyService, MyService>();

// Scoped: Same instance within a request
builder.Services.AddScoped<IMyService, MyService>();

// Singleton: Same instance for app lifetime
builder.Services.AddSingleton<IMyService, MyService>();
```

## HTTP Request Pipeline
ASP.NET Core uses middleware components configured in Program.cs:

```csharp
var app = builder.Build();

// Order matters!
app.UseRouting();           // URL routing
app.UseAuthentication();    // Auth before authorization
app.UseAuthorization();     // Access control
app.UseEndpoints();         // Endpoint execution
```

## Controller Implementation
Unlike Spring's @RestController, ASP.NET uses attributes:

```csharp
[ApiController]
[Route("api/[controller]")]
public class PagesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Page>>> Get()
    {
        return Ok(await _pageService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Page>> Get(string id)
    {
        var page = await _pageService.GetByIdAsync(id);
        if (page == null) return NotFound();
        return Ok(page);
    }
}
```

## Entity Framework Core vs Python SQLite
EF Core provides a strongly-typed, LINQ-based query interface:

```csharp
// EF Core LINQ query
var pages = await _context.Pages
    .Where(p => p.Language == "en")
    .OrderBy(p => p.Title)
    .Take(10)
    .ToListAsync();

// Equivalent Python SQLite
cursor.execute("""
    SELECT * FROM pages 
    WHERE language = ? 
    ORDER BY title 
    LIMIT 10
""", ('en',))
```

## Async/Await Pattern
ASP.NET Core is designed for async operations by default:

```csharp
// Async controller action
public async Task<ActionResult<Page>> GetPageAsync(string id)
{
    try 
    {
        var page = await _pageService.GetByIdAsync(id);
        return Ok(page);
    }
    catch (NotFoundException)
    {
        return NotFound();
    }
}
```

## Configuration Management
Instead of Python's config files or Spring's application.properties, ASP.NET uses a JSON-based configuration system with strong typing:

```csharp
// appsettings.json
{
    "Database": {
        "ConnectionString": "Data Source=whoknows.db"
    }
}

// Strongly-typed settings class
public class DatabaseSettings
{
    public string ConnectionString { get; set; }
}

// Registration
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));

// Usage via DI
public class MyService
{
    private readonly DatabaseSettings _settings;

    public MyService(IOptions<DatabaseSettings> settings)
    {
        _settings = settings.Value;
    }
}
```

## Error Handling
Global exception handling via middleware:

```csharp
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;

        var result = JsonSerializer.Serialize(new {
            Error = exception?.Message
        });

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    });
});
```