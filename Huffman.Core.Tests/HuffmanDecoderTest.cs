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

    private IEnumerable<Huffmanode> CreateTestTree()
    {
        var m = new Huffmanode
        {
            CharSequenz = "M",
            Frequency = 1
        };
        var p = new Huffmanode
        {
            CharSequenz = "P",
            Frequency = 2
        };
        var mp = new Huffmanode
        {
            CharSequenz = "MP",
            Frequency = 3,
            LeftChild = m,
            RightChild = p
        };
        var i = new Huffmanode
        {
            CharSequenz = "I",
            Frequency = 4
        };
        var s = new Huffmanode
        {
            CharSequenz = "S",
            Frequency = 4
        };
        var mpi = new Huffmanode
        {
            CharSequenz = "MPI",
            Frequency = 6,
            LeftChild = mp,
            RightChild = i,
        };
        var smpi = new Huffmanode
        {
            CharSequenz = "SMPI",
            Frequency = 10,
            LeftChild = s,
            RightChild = mpi
        };

        return new List<Huffmanode> { m, p, mp, i, s, mpi, smpi };
    }
}
