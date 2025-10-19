namespace Huffman.Console;

using System;

public class ArgumentReader
{
    public string? Text { get; private set; }

    public string? Command { get; private set; }

    public string? FilePath { get; private set; }

    public void ReadArguments(string[] args) 
    {
        switch (args.Length)
        {
            case 0:
                Console.WriteLine("Please enter text you'd like to have encoded.");
                Text = ReadInputFromConsole();
                break;
            case 1:
                Text = args[0];
                break;
            case 2:
                Command = args[0];
                FilePath = args[1];
                break;
            default:
                throw new ArgumentException("Too many arguments provided.");
        }
    }

    private string ReadInputFromConsole()
    {
        var input = string.Empty;
        while (input?.Length < 2)
        {
            input = Console.ReadLine();
            if (input?.Length < 2)
            {
                Console.WriteLine("The text needs to be at least two characters long for the Huffman algorithm to work");
            }
        }
        return input;
    }
}
