using Huffmann.Huffmann.Encoder;

namespace Huffmann.Tests;

public class EncoderTest
{
    [Fact]
    public void Test_Encoder()
    {
        // Arrange
        var encoder = new Encoder();
        var input = "MISSISSIPPI";
        var expectedCode = "100110011001110110111";
        var expectedSubstitutionTable = new Dictionary<char, string>
        {
            { 'S', "0" },
            { 'M', "100" },
            { 'P', "101" },
            { 'I', "11" },
        };

        // Act
        var code = encoder.HuffmannEncode(input);

        // Assert
        Assert.NotNull(code.EncodedText);
        Assert.Equal(expectedCode, code.EncodedText);
        Assert.True(expectedSubstitutionTable.SequenceEqual(code.SubstitutionTable));
    }
}