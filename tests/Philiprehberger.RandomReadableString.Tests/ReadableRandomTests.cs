using Xunit;
namespace Philiprehberger.RandomReadableString.Tests;

public class ReadableRandomTests
{
    [Fact]
    public void Generate_DefaultParams_ReturnsThreePartsAndNumber()
    {
        var result = ReadableRandom.Generate();
        var parts = result.Split('-');

        // wordCount=3 produces 3 words + 1 number = 4 parts
        Assert.Equal(4, parts.Length);
        Assert.True(int.TryParse(parts[^1], out var num));
        Assert.InRange(num, 10, 99);
    }

    [Fact]
    public void Generate_WordCountOne_ReturnsSingleWordAndNumber()
    {
        var result = ReadableRandom.Generate(wordCount: 1);
        var parts = result.Split('-');

        Assert.Equal(2, parts.Length);
    }

    [Fact]
    public void Generate_CustomSeparator_UsesSeparator()
    {
        var result = ReadableRandom.Generate(separator: "_");

        Assert.Contains("_", result);
        Assert.DoesNotContain("-", result);
    }

    [Fact]
    public void Generate_WordCountZero_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            ReadableRandom.Generate(wordCount: 0));
    }

    [Fact]
    public void Generate_NegativeWordCount_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            ReadableRandom.Generate(wordCount: -1));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    public void Generate_VariousWordCounts_ReturnsCorrectPartCount(int wordCount)
    {
        var result = ReadableRandom.Generate(wordCount: wordCount);
        var parts = result.Split('-');

        // wordCount words + 1 numeric suffix
        Assert.Equal(wordCount + 1, parts.Length);
    }

    [Fact]
    public void Generate_MultipleInvocations_ProducesDifferentResults()
    {
        var results = Enumerable.Range(0, 20)
            .Select(_ => ReadableRandom.Generate())
            .ToHashSet();

        // With 50 adjectives, 50 nouns, and 90 numbers, collisions across 20 calls are extremely unlikely
        Assert.True(results.Count > 1);
    }

    [Fact]
    public void Generate_EndsWithTwoDigitNumber()
    {
        var result = ReadableRandom.Generate();
        var lastPart = result.Split('-')[^1];

        Assert.Equal(2, lastPart.Length);
        Assert.True(int.TryParse(lastPart, out _));
    }
}
