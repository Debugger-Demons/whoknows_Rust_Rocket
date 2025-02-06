
using Microsoft.EntityFrameworkCore;
using whoknows_c_sharp.db;
using whoknows_c_sharp.domains.pages;
using whoknows_c_sharp.domains.users;


var builder = WebApplication.CreateBuilder(args);

// --------- Controllers implemented ---------
    // Add services to the container.
builder.Services.AddControllers();

// --------- Database implemented ---------
    // Configure SQLite
builder.Services.AddDbContext<WhoKnowsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// --------- Repositories ---------
    // Register repositories0
builder.Services.AddScoped<IRepository<Page>, PageRepository>();
    // Add more repositories as needed

// --------- Services ---------
// Register services
builder.Services.AddScoped<IPageService, PageService>();
// Add more services as needed

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --------- Build and Run ---------

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();