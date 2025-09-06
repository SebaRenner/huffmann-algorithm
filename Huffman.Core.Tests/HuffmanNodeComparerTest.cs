using Huffman.Core.Huffman;

namespace Huffman.Core.Tests;

public class HuffmanodeComparerTest
{
    [Fact]
    public void Test_Comparer_Smaller()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();
        var nodeA = new HuffmanNode
        {
            CharSequenz = "A",
            Frequency = 1,
        };
        var nodeB = new HuffmanNode
        {
            CharSequenz = "B",
            Frequency = 2,
        };

        // Act
        var result = comparer.Compare(nodeA, nodeB);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void Test_Comparer_Bigger()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();
        var nodeA = new HuffmanNode
        {
            CharSequenz = "A",
            Frequency = 3,
        };
        var nodeB = new HuffmanNode
        {
            CharSequenz = "B",
            Frequency = 2,
        };

        // Act
        var result = comparer.Compare(nodeA, nodeB);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void Test_Comparer_Equal()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();
        var nodeA = new HuffmanNode
        {
            CharSequenz = "A",
            Frequency = 2,
        };
        var nodeB = new HuffmanNode
        {
            CharSequenz = "B",
            Frequency = 2,
        };

        // Act
        var result = comparer.Compare(nodeA, nodeB);

        // Assert
        Assert.True(result == 0);
    }

    [Fact]
    public void Test_Comparer_Null_A()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();
        var nodeB = new HuffmanNode
        {
            CharSequenz = "B",
            Frequency = 2,
        };

        // Act
        var result = comparer.Compare(null, nodeB);

        // Assert
        Assert.True(result < 0);
    }

    [Fact]
    public void Test_Comparer_Null_B()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();
        var nodeA = new HuffmanNode
        {
            CharSequenz = "A",
            Frequency = 2,
        };

        // Act
        var result = comparer.Compare(nodeA, null);

        // Assert
        Assert.True(result > 0);
    }

    [Fact]
    public void Test_Comparer_Null_Both()
    {
        // Arrange
        var comparer = new HuffmanNodeComparer();

        // Act
        var result = comparer.Compare(null, null);

        // Assert
        Assert.True(result == 0);
    }
}
