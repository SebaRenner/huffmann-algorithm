using Huffman.Core.Huffman;

namespace Huffman.Core.Tests;

public class HuffmanTreeBuilderTest
{
    [Fact]
    public void Test_CreateTree()
    {
        // Arrange
        var dict = new Dictionary<char, int>
        {
            { 'a', 3 },
            { 'b', 2 },
            { 'c', 1 },
        };

        var nodes = dict.Keys.Select(c => new HuffmanNode
        {
            CharSequenz = c.ToString(),
            Frequency = dict[c]
        });

        var expected = new[]
        {
            ("c", 1),
            ("b", 2),
            ("a", 3),
            ("cb", 3),
            ("acb", 6)
        };

        // Act
        var tree = HuffmanTreeBuilder.CreateTree(nodes);

        // Assert
        Assert.Equal(5, tree.Count());
        Assert.Equal(expected, tree.Select(n => (n.CharSequenz, n.Frequency)));
    }
}
