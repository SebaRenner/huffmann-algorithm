namespace Huffman.Core.Huffman;

public record HuffmanCode(string EncodedText, Dictionary<char, string> SubstitutionTable);
