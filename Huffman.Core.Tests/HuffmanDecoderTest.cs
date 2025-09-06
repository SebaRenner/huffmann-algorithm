using Huffman.Core.Decoder;
using Huffman.Core.Huffman;

namespace Huffman.Core.Tests;

public class HuffmanDecoderTest
{
    [Fact]
    public void Test_Decode_FromTable()
    {
        // Arrange
        var encodedText = "100110011001110110111";
        var substitutionTable = new Dictionary<char, string>
        {
            { 'M', "100" },
            { 'I', "11" },
            { 'S', "0" },
            { 'P', "101" },
        };

        var expected = "MISSISSIPPI";

        // Act
        var result = HuffmanDecoder.Decode(encodedText, substitutionTable);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_Decode_FromTree()
    {
        // Arrange
        var encodedText = "100110011001110110111";
        var tree = CreateTestTree();

        var expected = "MISSISSIPPI";

        // Act
        var result = HuffmanDecoder.Decode(encodedText, tree);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    private IEnumerable<HuffmanNode> CreateTestTree()
    {
        var m = new HuffmanNode
        {
            CharSequenz = "M",
            Frequency = 1
        };
        var p = new HuffmanNode
        {
            CharSequenz = "P",
            Frequency = 2
        };
        var mp = new HuffmanNode
        {
            CharSequenz = "MP",
            Frequency = 3,
            LeftChild = m,
            RightChild = p
        };
        var i = new HuffmanNode
        {
            CharSequenz = "I",
            Frequency = 4
        };
        var s = new HuffmanNode
        {
            CharSequenz = "S",
            Frequency = 4
        };
        var mpi = new HuffmanNode
        {
            CharSequenz = "MPI",
            Frequency = 6,
            LeftChild = mp,
            RightChild = i,
        };
        var smpi = new HuffmanNode
        {
            CharSequenz = "SMPI",
            Frequency = 10,
            LeftChild = s,
            RightChild = mpi
        };

        return new List<HuffmanNode> { m, p, mp, i, s, mpi, smpi };
    }
}
