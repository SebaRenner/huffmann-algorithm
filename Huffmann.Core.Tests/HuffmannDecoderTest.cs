using Huffmann.Core.Decoder;
using Huffmann.Core.Huffmann;

namespace Huffmann.Core.Tests;

public class HuffmannDecoderTest
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
        var result = HuffmannDecoder.Decode(encodedText, substitutionTable);

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
        var result = HuffmannDecoder.Decode(encodedText, tree);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    private IEnumerable<HuffmannNode> CreateTestTree()
    {
        var m = new HuffmannNode
        {
            CharSequenz = "M",
            Frequency = 1
        };
        var p = new HuffmannNode
        {
            CharSequenz = "P",
            Frequency = 2
        };
        var mp = new HuffmannNode
        {
            CharSequenz = "MP",
            Frequency = 3,
            LeftChild = m,
            RightChild = p
        };
        var i = new HuffmannNode
        {
            CharSequenz = "I",
            Frequency = 4
        };
        var s = new HuffmannNode
        {
            CharSequenz = "S",
            Frequency = 4
        };
        var mpi = new HuffmannNode
        {
            CharSequenz = "MPI",
            Frequency = 6,
            LeftChild = mp,
            RightChild = i,
        };
        var smpi = new HuffmannNode
        {
            CharSequenz = "SMPI",
            Frequency = 10,
            LeftChild = s,
            RightChild = mpi
        };

        return new List<HuffmannNode> { m, p, mp, i, s, mpi, smpi };
    }
}
