using Huffmann.Encoder;

Console.WriteLine("Enter a text you'd like to be compressed using the huffmann algorithm");
var input = string.Empty;

while(input?.Length < 2)
{
    input = Console.ReadLine();

    if (input.Length < 2)
    {
        Console.WriteLine("The text needs to be at least two characters long for the huffmann algorithm to work");
    }
}

var encoder = new Encoder();
var result = encoder.HuffmannEncode(input);

var inputLength = input.Length * 8;
var resultLength = result.Length;
var compressionRate = Math.Round(100 - (double)resultLength / inputLength * 100, 2);

Console.WriteLine();
Console.WriteLine($"Original Text: {inputLength} Bit");
Console.WriteLine($"Huffman Coded: {resultLength} Bit");
Console.WriteLine($"Compression Rate: {compressionRate}%");
Console.WriteLine("--------------------------------------");
Console.WriteLine("The huffmann encoded text:");
Console.WriteLine(result);