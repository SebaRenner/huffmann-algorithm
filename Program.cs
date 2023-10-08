// See https://aka.ms/new-console-template for more information
using Huffmann;

Console.WriteLine("Enter a text you'd like to be compressed using the huffmann algorithm");
var input = string.Empty;

while(input?.Length == 0)
{
    input = Console.ReadLine();
}

var encoder = new Encoder();
var result = encoder.Encode(input);

var inputLength = input.Length * 8;
var resultLength = result.Length;
var compressionRate = Math.Round(100 - (double)resultLength / inputLength * 100, 2);

Console.WriteLine("");
Console.WriteLine($"Original Text: {inputLength} Bit");
Console.WriteLine($"Huffman Coded: {resultLength} Bit");
Console.WriteLine($"Compression Rate: {compressionRate}%");
Console.WriteLine("--------------------------------------");
Console.WriteLine("The huffmann encoded text:");
Console.WriteLine(result);