namespace Huffman.Console;

using System;

public class ArgumentReader
{
    public string? Text { get; private set; }

    public ValidCommand? Command { get; private set; }

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
                Command = ParseCommand(args[0]);
                FilePath = args[1];  // should also be checked if file exists I guess
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

    private ValidCommand ParseCommand(string arg0) 
    {
        var command = arg0.ToLower();
        if (command != "encode" && command != "decode")
        {
            throw new ArgumentException("Invalid command provided. Use 'encode' or 'decode'.");
        }

        if (command == "encode")
        {
            return ValidCommand.Encode;
        }
        else 
        {
            return ValidCommand.Decode;
        }
    }
}
