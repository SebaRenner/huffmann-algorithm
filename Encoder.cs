namespace Huffmann;

public class Encoder
{
    public Encoder() { }

    public string Encode(string text)
    {
        var dict = CountCharacters(text);
        CreateHuffmannTree(dict);

        return text;
    }

    private Dictionary<char, int> CountCharacters(string text)
    {
        return text
             .GroupBy(c => c)
             .ToDictionary(group => group.Key, group => group.Count());
    }

    private void CreateHuffmannTree(Dictionary<char, int> charFrequencyMap)
    {
        
    }
}
