using Huffmann.Huffmann.Decoder;

namespace Huffmann.Tests;

public class DecoderTest
{
    [Fact]
    public void Test_Decoder()
    {
        // Arrange
        var decoder = new Decoder();
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
        var result = decoder.HuffmannDecode(encodedText, substitutionTable);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
}
