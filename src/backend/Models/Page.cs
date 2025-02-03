
// Models/Page.cs
namespace whoknows_c_sharp.Models;

public class Page
{
    public string Title { get; set; }  // PK
    public string Url { get; set; }
    public string Language { get; set; } = "en";  // Default value
    public DateTime LastUpdated { get; set; }
    public string Content { get; set; }
}

/*

CREATE TABLE IF NOT EXISTS pages (
    title TEXT PRIMARY KEY UNIQUE,
    url TEXT NOT NULL UNIQUE,
    language TEXT NOT NULL CHECK(language IN ('en', 'da')) DEFAULT 'en', -- How you define ENUM type in SQLite
    last_updated TIMESTAMP,
    content TEXT NOT NULL
);
whoknows_c_sharp>

*/