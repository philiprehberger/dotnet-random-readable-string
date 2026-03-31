# Philiprehberger.RandomReadableString

[![CI](https://github.com/philiprehberger/dotnet-random-readable-string/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-random-readable-string/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.RandomReadableString.svg)](https://www.nuget.org/packages/Philiprehberger.RandomReadableString)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-random-readable-string)](https://github.com/philiprehberger/dotnet-random-readable-string/commits/main)

Generate human-readable random strings like `"swift-river-42"` — great for slugs, identifiers, and placeholders.

## Installation

```bash
dotnet add package Philiprehberger.RandomReadableString
```

## Usage

```csharp
using Philiprehberger.RandomReadableString;

// Default: 3 words, "-" separator
ReadableRandom.Generate();          // "swift-river-42"
ReadableRandom.Generate();          // "bold-eagle-17"
ReadableRandom.Generate();          // "calm-tide-83"

// Custom word count
ReadableRandom.Generate(wordCount: 2); // "happy-shore-56"
ReadableRandom.Generate(wordCount: 4); // "sunny-magic-lake-31"

// Custom separator
ReadableRandom.Generate(separator: "_"); // "quick_frost_74"
ReadableRandom.Generate(separator: " "); // "pale ocean 19"
```

### Custom Word Count

```csharp
using Philiprehberger.RandomReadableString;

ReadableRandom.Generate(2);  // "sunny-falcon"
ReadableRandom.Generate(4);  // "bright-red-swift-mountain"
```

### Custom Separator

```csharp
using Philiprehberger.RandomReadableString;

ReadableRandom.Generate(3, "_");  // "cool_river_42"
ReadableRandom.Generate(3, " "); // "happy cloud 17"
```

## API

### `ReadableRandom`

| Method | Description |
|--------|-------------|
| `Generate(int wordCount = 3, string separator = "-")` | Return a random readable string made of `wordCount` words plus a trailing 2-digit number, joined by `separator` |

**Notes:**
- The last token is always a random 2-digit number (10–99).
- Words are drawn from a built-in list of 50 adjectives and 50 nouns.
- Thread-safe.

## Development

```bash
dotnet build src/Philiprehberger.RandomReadableString.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-random-readable-string)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-random-readable-string/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-random-readable-string/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
