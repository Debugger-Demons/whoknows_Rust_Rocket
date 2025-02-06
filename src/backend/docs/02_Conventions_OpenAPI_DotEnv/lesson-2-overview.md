---
tags: 
super-link:
---
```table-of-contents
title: 
style: nestedList # TOC style (nestedList|nestedOrderedList|inlineFirstLevel)
minLevel: 0 # Include headings from the specified level
maxLevel: 3 # Include headings up to the specified level
includeLinks: true # Make headings clickable
debugInConsole: false # Print debug info in Obsidian console
```
---

# DevOps Lesson 2 Overview

## 1. Course Status & Updates

- Group formation required for exam eligibility
- Python 2 to Python 3 refactoring progress
- Dependency tracking tools introduction:
  - debtree for Debian packages
  - pipdeptree for Python dependencies
- Review of commit activity patterns

## 2. Development Principles

### Weekly DevOps Principle
Focus on transparency, visibility, and knowledge sharing

### Implementation Methods
- Comprehensive version control with meaningful commit messages
- Detailed release notes
- Public issues and pull requests
- Thorough documentation
- Status dashboards
- Breaking down information silos

## 3. Technical Standards & Practices

### File/Folder Conventions
Never push:
- IDE preferences (.idea, .vscode)
- OS-specific files (.DS_Store, Thumbs.db)
- Build artifacts (__pycache__, node_modules)

### Tools
- .gitignore.io for generating .gitignore files
- Global .gitignore for system-specific exclusions

## 4. API Documentation

- OpenAPI/Swagger specification overview
- Bidirectional workflow:
  - Generate documentation from API code
  - Generate API code from documentation
  - Hybrid approach for simultaneous development

## 5. Architecture Concepts

### Monorepo vs Multi-repo
- Trade-offs between centralized and distributed code management
- Impact on team collaboration and CI/CD

### Architectural Patterns
```
Monolithic Applications:
- Single application deployment
- Internal communication within program

Microservices:
- Multiple small, focused services
- Network-based communication between services
```

## 6. Environment Management

### Tools and Practices
- Dotenv implementation across languages
- Virtual environment best practices
- Configuration management in:
  - Development environments
  - GitHub Actions
  - Docker Compose

## 7. Security Practices

### Configuration Management
- Template files (.env.example)
- Secret management in CI/CD pipelines
- Secure environment variable handling

### Best Practices
- Never commit sensitive data
- Use environment-specific configurations
- Implement proper secret management