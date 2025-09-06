using Huffman.Core.Huffman;

namespace Huffman.Core.Encoder;

public static class HuffmanEncoder
{
    public static HuffmanCode Encode(string text)
    {
        var dict = CountCharacters(text);
        var HuffmanTable = HuffmanCodeGenerator.CreateCode(dict);

        var encodedText = string.Empty;
        var chars = text.ToCharArray();

        foreach (var c in chars)
        {
            encodedText += HuffmanTable[c];
        }

        return new (encodedText, HuffmanTable);
    }

    private static Dictionary<char, int> CountCharacters(string text)
    {
        return text
             .GroupBy(c => c)
             .ToDictionary(group => group.Key, group => group.Count());
    }
}
