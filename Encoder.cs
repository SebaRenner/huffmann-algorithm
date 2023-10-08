namespace Huffmann;

public class Encoder
{
    public string Encode(string text)
    {
        var dict = CountCharacters(text);
        var huffmannTable = new HuffmannTree().CreateHuffmanCode(dict);

        var encodedText = string.Empty;
        var chars = text.ToCharArray();

        foreach (var c in chars)
        {
            encodedText += huffmannTable[c];
        }

        return encodedText;
    }

    private Dictionary<char, int> CountCharacters(string text)
    {
        return text
             .GroupBy(c => c)
             .ToDictionary(group => group.Key, group => group.Count());
    }

}
