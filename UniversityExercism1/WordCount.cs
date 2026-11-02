using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var counts = new Dictionary<string, int>();

        foreach (Match match in Regex.Matches(phrase.ToLowerInvariant(), @"[a-z0-9]+(?:'[a-z0-9]+)*"))
        {
            string word = match.Value;
            counts.TryGetValue(word, out int count);
            counts[word] = count + 1;
        }

        return counts;
    }
}
