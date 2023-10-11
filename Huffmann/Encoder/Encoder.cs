using Huffmann.Huffmann.Huffmann;

namespace Huffmann.Huffmann.Encoder;

public class Encoder
{
    public HuffmannCode HuffmannEncode(string text)
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

    private Dictionary<char, int> CountCharacters(string text)
    {
        return text
             .GroupBy(c => c)
             .ToDictionary(group => group.Key, group => group.Count());
    }

}
