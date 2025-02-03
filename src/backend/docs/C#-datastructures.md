# Data Structures Reference Guide

## Basic Data Types

- `int`, `long` - Integers
- `float`, `double`, `decimal` - Floating point numbers
- `bool` - Boolean values
- `char` - Single characters
- `string` - Text
- `DateTime` - Date and time values

## Collections

### 1. List<T> (Most Common)
Modern, flexible array that can grow or shrink in size.
```csharp
List<string> names = new List<string>();
names.Add("Alice");
names.RemoveAt(0);
```

### 2. Arrays
Fixed-size collection of elements.
```csharp
string[] names = new string[10];
names[0] = "Alice";
```

### 3. Dictionary<TKey, TValue>
Collection of key-value pairs.
```csharp
Dictionary<string, int> scores = new Dictionary<string, int>();
scores["Alice"] = 95;
int aliceScore = scores["Alice"];
```

### 4. HashSet<T>
Collection of unique elements.
```csharp
HashSet<string> uniqueNames = new HashSet<string>();
uniqueNames.Add("Alice");  // Added
uniqueNames.Add("Alice");  // Ignored (duplicate)
```

### 5. Queue<T>
First-in-first-out (FIFO) collection.
```csharp
Queue<string> waitingList = new Queue<string>();
waitingList.Enqueue("Alice");  // Add to end
string next = waitingList.Dequeue();  // Remove from front
```

### 6. Stack<T>
Last-in-first-out (LIFO) collection.
```csharp
Stack<string> undoStack = new Stack<string>();
undoStack.Push("Action1");  // Add to top
string lastAction = undoStack.Pop();  // Remove from top
```

## Common Operations

### LINQ Methods
LINQ provides powerful query capabilities:
```csharp
var list = new List<int> { 1, 2, 3, 4, 5 };

// Filtering
var evenNumbers = list.Where(x => x % 2 == 0);

// Transforming
var doubled = list.Select(x => x * 2);

// Ordering
var ordered = list.OrderBy(x => x);

// Finding Elements
var first = list.First();
var firstOrDefault = list.FirstOrDefault();
```

### Best Practices
1. Use `List<T>` instead of legacy ArrayList
2. Return `IEnumerable<T>` for read-only operations
3. Use LINQ for filtering and transforming collections
4. Consider using `var` for local variables with obvious types
5. Use proper type constraints when working with generics

## Example Usage in Page Service

```csharp
public async Task<IEnumerable<Page>> SearchPages(string searchTerm)
{
    var allPages = await _repository.GetAllAsync();
    return allPages.Where(page => 
        page.Title.Contains(searchTerm) || 
        page.Content.Contains(searchTerm)
    );
}
```
