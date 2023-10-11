namespace Huffmann.Huffmann;

public record HuffmannCode(string EncodedText, Dictionary<char, string> SubstitutionTable);
