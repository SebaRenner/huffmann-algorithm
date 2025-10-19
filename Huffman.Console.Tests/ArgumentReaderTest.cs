namespace Huffman.Console.Tests;

using System;

public class ArgumentReaderTest
{
    [Fact]
    public void Test_ReadArguments_0args()
    {
        // Arrange
        var args = Array.Empty<string>();
        var reader = new ArgumentReader();

        // Simulate user input
        var simulatedInput = "Hello";
        Console.SetIn(new StringReader(simulatedInput));

        // Act
        reader.ReadArguments(args);

        // Assert
        Assert.Equal(simulatedInput, reader.Text);
        Assert.Null(reader.Command);
        Assert.Null(reader.FilePath);
    }

    [Fact]
    public void Test_ReadArguments_1args()
    {
        // Arrange
        string[] args = ["MISSISSIPI"];
        var reader = new ArgumentReader();

        // Act
        reader.ReadArguments(args);

        // Assert
        Assert.Equal("MISSISSIPI", reader.Text);
        Assert.Null(reader.Command);
        Assert.Null(reader.FilePath);
    }

    [Fact]
    public void Test_ReadArguments_2args_Valid()
    {
        // Arrange
        var filePath = "input.txt";
        string[] args = ["EnCoDe", filePath];
        var reader = new ArgumentReader();

        // Act
        reader.ReadArguments(args);

        // Assert
        Assert.Null(reader.Text);
        Assert.Equal(ValidCommand.Encode, reader.Command);
        Assert.Equal(filePath, reader.FilePath);
    }

    [Fact]
    public void Test_ReadArguments_2args_Invalid()
    {
        // Arrange
        string[] args = ["MISSISSIPI", "input.txt"];
        var reader = new ArgumentReader();

        // Act
        var act = () => reader.ReadArguments(args);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Test_ReadArguments_3args()
    {
        // Arrange
        string[] args = ["EnCoDe", "input.txt", "output.bin"];
        var reader = new ArgumentReader();

        // Act
        var act = () => reader.ReadArguments(args);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }
}
