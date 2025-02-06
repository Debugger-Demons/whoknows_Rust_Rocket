# Project Conventions

## Git Standards

### Commit Messages
Format: `<past_tense_verb> + <action>`

Examples:
- `Added user authentication routes`
- `Implemented OpenAPI documentation`
- `Fixed database connection timeout`
- `Refactored search algorithm`

### Branch Strategy
- main: production releases
- develop: integration branch
- feature/*: new features
- fix/*: bug fixes

## Rust Code Style

### Naming
- modules: snake_case
- types/traits: PascalCase
- functions/variables: snake_case
- constants: SCREAMING_SNAKE_CASE
- statics: SCREAMING_SNAKE_CASE

### File Structure
```
src/
├── main.rs           # application entry
├── lib.rs           # library entry
├── models/          # database models
├── routes/          # API endpoints
├── services/        # business logic
└── utils/           # shared utilities
```

### Code Formatting
- Use `rustfmt` with default settings
- Max line length: 100 characters
- Use explicit types for public interfaces

## Documentation

### Code Comments
- Document public interfaces with /// comments
- Include examples in doc comments
- Explain complex algorithms
- Mark TODOs with: `// TODO(username): description`

### README Requirements
- Project overview
- Setup instructions
- API documentation link
- Development workflow
- Testing strategy

## Testing
- Unit tests alongside code
- Integration tests in tests/
- Document test coverage expectations

## Tools Configuration
- .gitignore: use gitignore.io rust template
- rustfmt.toml: default settings
- clippy: use default lints

## Environment
- Use .env for local development
- .env.example in version control
- Document all environment variables
