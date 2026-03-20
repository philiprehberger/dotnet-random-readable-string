# Changelog

## 0.1.5

- Expand README with custom word count and separator examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4

- Add Development section to README
- Add GenerateDocumentationFile and RepositoryType to .csproj

## 0.1.1 (2026-03-10)

- Fix README path in csproj so README displays on nuget.org

## 0.1.0 (2026-03-10)

- Initial release
- `ReadableRandom.Generate` — generate human-readable random strings like "swift-river-42"
- Built-in word lists: 50 adjectives, 50 nouns
- Configurable word count and separator
- Thread-safe via lock on shared `Random` instance
