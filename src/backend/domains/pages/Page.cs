
// src/backend/domain/pages/Page.cs
namespace whoknows_c_sharp.domains.pages;

public class Page
{
    public required string Title { get; set; }  // PK
    public required string Url { get; set; }
    public required string Language { get; set; } = "en";  // Default value
    public DateTime LastUpdated { get; set; }
    public required string Content { get; set; }
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