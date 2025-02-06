# OpenAPI Documentation

## Implementation with Utoipa

### Setup
```rust
use utoipa::OpenApi;
use utoipa_swagger_ui::SwaggerUi;

#[derive(OpenApi)]
#[openapi(
    paths(
        health::health_check,
        search::search,
        // add other routes
    ),
    components(
        schemas(SearchQuery, SearchResult)
    ),
    tags(
        (name = "health", description = "Health check endpoints"),
        (name = "search", description = "Search functionality")
    )
)]
struct ApiDoc;
```

### Route Documentation
```rust
/// Search endpoint
#[utoipa::path(
    get,
    path = "/search",
    params(
        ("q" = String, Query, description = "Search query"),
        ("limit" = Option<i32>, Query, description = "Max results")
    ),
    responses(
        (status = 200, description = "Search results", body = Vec<SearchResult>),
        (status = 400, description = "Invalid query"),
        (status = 500, description = "Server error")
    )
)]
async fn search(query: web::Query<SearchQuery>) -> impl Responder {
    // implementation
}
```

## Schemas

### Model Documentation
```rust
#[derive(Serialize, Deserialize, ToSchema)]
struct SearchResult {
    /// Unique identifier
    #[schema(example = "123")]
    id: i32,
    /// Search result title
    #[schema(example = "Rust Programming")]
    title: String,
    /// Result relevance score
    #[schema(example = 0.95)]
    score: f32,
}
```

## Integration

### Rocket Setup
```rust
#[launch]
fn rocket() -> _ {
    rocket::build()
        .mount("/", routes![search, health_check])
        .mount("/swagger", SwaggerUi::new("/swagger/openapi.json")
            .url("/api-docs/openapi.json", ApiDoc::openapi()))
}
```

## Documentation Standards

### Endpoint Documentation
- Clear description of functionality
- All parameters documented
- Response codes and formats
- Authentication requirements
- Rate limiting details

### Schema Documentation
- Field descriptions
- Validation rules
- Example values
- Required vs optional fields

### Security
- Document authentication methods
- Scope requirements
- Rate limits
- CORS policies

## Testing
- Validate OpenAPI spec correctness
- Test example requests/responses
- Verify documentation accuracy
- Check schema validation

## Tooling
- Swagger UI for visualization
- OpenAPI spec validation
- Documentation generation
- Client SDK generation
