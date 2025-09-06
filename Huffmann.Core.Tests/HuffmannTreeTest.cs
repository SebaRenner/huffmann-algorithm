using Huffmann.Core.Huffmann;

namespace Huffmann.Core.Tests;

public class HuffmannTreeTest
{
    [Fact]
    public void Test_CreateHuffmannCode_1Char()
    {
        // Arrange
        var testee = new HuffmannTree();
        var dict = new Dictionary<char, int>
        {
            { 'a', 2 },
        };

        // Act
        var act = () => testee.CreateHuffmannCode(dict);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Test_CreateHuffmannCode_2Chars()
    {
        // Arrange
        var testee = new HuffmannTree();
        var dict = new Dictionary<char, int>
        {
            { 'a', 2 },
            { 'b', 1 },
        };

        // Act
        var result = testee.CreateHuffmannCode(dict);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Keys.Count);
        Assert.Equal("1", result['a']);
        Assert.Equal("0", result['b']);
    }


    [Fact]
    public void Test_CreateHuffmannCode_3Chars()
    {
        // Arrange
        var testee = new HuffmannTree();
        var dict = new Dictionary<char, int>
        {
            { 'a', 2 },
            { 'b', 1 },
            { 'c', 5 },
        };

        // Act
        var result = testee.CreateHuffmannCode(dict);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Keys.Count);
        Assert.Equal("1", result['c']);
        Assert.Equal("00", result['b']);
        Assert.Equal("01", result['a']);
    }
}
