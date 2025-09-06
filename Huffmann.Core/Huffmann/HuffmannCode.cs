namespace Huffmann.Core.Huffmann;

public record HuffmannCode(string EncodedText, Dictionary<char, string> SubstitutionTable);
