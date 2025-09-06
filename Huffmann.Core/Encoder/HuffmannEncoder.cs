using Huffmann.Core.Huffmann;

namespace Huffmann.Core.Encoder;

public static class HuffmannEncoder
{
    public static HuffmannCode Encode(string text)
    {
        var dict = CountCharacters(text);
        var huffmannTable = new HuffmannTree().CreateHuffmannCode(dict);

        var encodedText = string.Empty;
        var chars = text.ToCharArray();

        foreach (var c in chars)
        {
            encodedText += huffmannTable[c];
        }

        return new (encodedText, huffmannTable);
    }

    private static Dictionary<char, int> CountCharacters(string text)
    {
        return text
             .GroupBy(c => c)
             .ToDictionary(group => group.Key, group => group.Count());
    }
}
