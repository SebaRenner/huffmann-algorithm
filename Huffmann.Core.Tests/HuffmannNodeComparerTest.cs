using Huffmann.Core.Huffmann;

namespace Huffmann.Core.Tests;

public class HuffmannNodeComparerTest
{
    [Fact]
    public void Test_Comparer_Smaller()
    {
        // Arrange
        var comparer = new HuffmannNodeComparer();
        var nodeA = new HuffmannNode
        {
            CharSequenz = "A",
            Frequency = 1,
        };
        var nodeB = new HuffmannNode
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
        var comparer = new HuffmannNodeComparer();
        var nodeA = new HuffmannNode
        {
            CharSequenz = "A",
            Frequency = 3,
        };
        var nodeB = new HuffmannNode
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
        var comparer = new HuffmannNodeComparer();
        var nodeA = new HuffmannNode
        {
            CharSequenz = "A",
            Frequency = 2,
        };
        var nodeB = new HuffmannNode
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
        var comparer = new HuffmannNodeComparer();
        var nodeB = new HuffmannNode
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
        var comparer = new HuffmannNodeComparer();
        var nodeA = new HuffmannNode
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
        var comparer = new HuffmannNodeComparer();

        // Act
        var result = comparer.Compare(null, null);

        // Assert
        Assert.True(result == 0);
    }
}
