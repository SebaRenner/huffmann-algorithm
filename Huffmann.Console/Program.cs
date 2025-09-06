using Huffmann.Core.Decoder;
using Huffmann.Core.Encoder;

Console.WriteLine("Enter a text you'd like to be compressed using the huffmann algorithm");
var input = string.Empty;

while (input?.Length < 2)
{
    input = Console.ReadLine();

    if (input.Length < 2)
    {
        Console.WriteLine("The text needs to be at least two characters long for the huffmann algorithm to work");
    }
}

var encoder = new HuffmannEncoder();
var encodedText = encoder.Encode(input);

var inputLength = input.Length * 8;
var encodedTextLength = encodedText.EncodedText.Length;
var compressionRate = Math.Round(100 - (double)encodedTextLength / inputLength * 100, 2);

var decoder = new HuffmannDecoder();
var decodedText = decoder.Decode(encodedText.EncodedText, encodedText.SubstitutionTable);

Console.WriteLine();
Console.WriteLine($"Original Text: {inputLength} Bit");
Console.WriteLine($"Huffman Coded: {encodedTextLength} Bit");
Console.WriteLine($"Compression Rate: {compressionRate}%");
Console.WriteLine("--------------------------------------");
Console.WriteLine("The huffmann encoded text:");
Console.WriteLine(encodedText.EncodedText);
Console.WriteLine();
Console.WriteLine("Decoded text:");
Console.WriteLine(decodedText);
