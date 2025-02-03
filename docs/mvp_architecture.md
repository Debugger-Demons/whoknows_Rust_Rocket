# WhoKnows C# Architecture Documentation

## Overview
This document explains how our C# application is structured and how the different parts work together.

## Basic Structure
Our application follows a Domain Driven Design 

```
    [db]
      [schema.sql]
      [whoknows.db]
      [WhoKnowsContext.db]

    [domains]
      [pages] 
        [Controllers] → [Services] → [Repositories] → Database
            ↓             ↓             ↓
          [page]        [page]        [page]
      [users]
        [Controllers] → [Services] → [Repositories] → Database
            ↓             ↓             ↓
          [user]        [user]        [user]

    [Program.cs]

```

## Components Explained

### 1. Models
Models are simple C# classes that represent our data:

- **Page.cs**: Represents a wiki page
  - Title (primary key)
  - URL
  - Language (en/da)
  - LastUpdated
  - Content

- **User.cs**: Represents a user
  - Id (primary key)
  - Username
  - Email
  - Password

### 2. Database Connection (WhoKnowsContext)
- Handles SQLite database connection 
- Defines how models map to database tables
- Uses Entity Framework Core
- Configuration lives in `appsettings.json`

### 3. Repositories
Handle basic CRUD operations

Example operations:
```csharp
  await _repository.GetByIdAsync(id);
  await _repository.AddAsync(entity);
```

### 4. Services
- Contain business logic
- Use repositories to access data
- Handle operations like:
  - Search pages
  - Filter by language
  - User authentication 

### 5. Controllers (To Be Implemented)
- Handle HTTP requests
- Use services to process requests
- Return HTTP responses

## Key Components & Design Patterns

### Core Components
- **Models**: Domain entities (Page, User)
- **DbContext**: EF Core database interface
- **MVC** Controllers, Services and Repositories

### Design Patterns Used
- **Repository Pattern**: Abstracts data access
- **Dependency Injection**: Manages dependencies
- **Service Layer**: Encapsulates business logic
- **Unit of Work** (via DbContext): Manages transactions

## Code Examples

### Service Layer Example
```csharp
// In PageService
public async Task<IEnumerable<Page>> SearchPagesAsync(string query)
{
    var pages = await _pageRepository.GetAllAsync();
    return pages.Where(p => 
        p.Title.Contains(query) || 
        p.Content.Contains(query)
    );
}
```

## Getting Started
1. Models are in `/Models`
2. Database context is in `/Data`
3. Repositories are in `/Repositories`
4. Services are in `/Services`
5. Controllers will be in `/Controllers`

## Next Steps
1. Implement controllers
2. Add authentication
3. Add search functionality
4. Add page management features