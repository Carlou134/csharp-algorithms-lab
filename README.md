# csharp-algorithms-lab

Data structures and algorithms practice in C#, with exercises and performance measurements.

Each lesson follows my [SSR developer roadmap](https://github.com/Carlou134/ssr-developer-roadmap) notes: first I reason about which structure fits the problem, then I measure it to confirm the theory.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run

```bash
dotnet run --project AlgorithmsLab
```

`Program.cs` only calls the exercise to run, for example `Exercise02.Run()`.

## Structure

```
AlgorithmsLab/
├── Program.cs
└── Lesson01_WhyDataStructures/
    ├── Exercise01.cs
    ├── Exercise02.cs
    └── Models.cs
```

One folder per lesson, one file per exercise.

## Lessons

### 01 · Why data structures

**Exercise 1.** Pick the right .NET collection by its dominant operation:

| Scenario | Collection | Why |
|---|---|---|
| Undo button | `Stack<T>` | LIFO: the last action is the first one reverted |
| Username already taken | `HashSet<string>` | O(1) existence check, no associated value |
| Email send queue | `Queue<T>` | FIFO: first in, first sent |
| Cart by user Id | `Dictionary<Guid, Cart>` | O(1) lookup by key with an associated value |

**Exercise 2.** Replace a `List.First` lookup inside a loop (O(n·m)) with a `Dictionary` built once (O(n+m)).

| Products × Items | List + First | Dictionary |
|---|---|---|
| 5,000 × 20,000 | 537 ms | 3 ms |
| 10,000 × 40,000 | 2,087 ms | 6 ms |

Doubling both inputs made the slow version ~4× slower and the fast one 2× slower, exactly as O(n·m) vs O(n+m) predicts.
