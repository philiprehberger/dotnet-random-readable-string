namespace Philiprehberger.RandomReadableString;

public static class ReadableRandom
{
    private static readonly string[] Adjectives =
    [
        "swift", "bold", "calm", "dark", "eager", "fair", "glad", "high",
        "idle", "just", "keen", "lazy", "mild", "neat", "odd", "pale",
        "quick", "rare", "safe", "tall", "vast", "warm", "wild", "young",
        "zany", "amber", "brave", "clear", "dusty", "early", "fresh", "green",
        "happy", "inner", "jolly", "light", "magic", "noble", "open", "proud",
        "quiet", "royal", "sharp", "tidy", "ultra", "vivid", "witty", "sunny",
        "misty", "icy"
    ];

    private static readonly string[] Nouns =
    [
        "falcon", "river", "eagle", "storm", "flame", "frost", "grove", "haven",
        "isle", "jade", "kite", "lake", "moon", "north", "ocean", "peak",
        "quest", "ridge", "shore", "tide", "brook", "cloud", "delta", "field",
        "ember", "fjord", "glade", "hedge", "inlet", "jetty", "knoll", "larch",
        "marsh", "nexus", "orbit", "petal", "quartz", "realm", "slope", "tower",
        "umbra", "valley", "wave", "xerox", "yacht", "zenith", "arrow", "blaze",
        "cedar", "drift"
    ];

    private static readonly Random Rng = new();
    private static readonly object Lock = new();

    public static string Generate(int wordCount = 3, string separator = "-")
    {
        if (wordCount < 1)
            throw new ArgumentOutOfRangeException(nameof(wordCount), "Word count must be at least 1.");

        lock (Lock)
        {
            var parts = new List<string>(wordCount + 1);

            for (var i = 0; i < wordCount - 1; i++)
            {
                // Alternate between adjectives and nouns, starting with an adjective
                parts.Add(i % 2 == 0
                    ? Adjectives[Rng.Next(Adjectives.Length)]
                    : Nouns[Rng.Next(Nouns.Length)]);
            }

            // Last word is always a noun
            parts.Add(Nouns[Rng.Next(Nouns.Length)]);

            // Append a random 2-digit number
            parts.Add(Rng.Next(10, 100).ToString());

            return string.Join(separator, parts);
        }
    }
}
