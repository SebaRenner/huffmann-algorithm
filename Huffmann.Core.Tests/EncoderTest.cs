using Huffmann.Core.Encoder;

namespace Huffmann.Core.Tests;

public class EncoderTest
{
    [Fact]
    public void Test_Encoder()
    {
        // Arrange
        var encoder = new HuffmannEncoder();
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
        var code = encoder.Encode(input);

        // Assert
        Assert.NotNull(code.EncodedText);
        Assert.Equal(expectedCode, code.EncodedText);
        Assert.True(expectedSubstitutionTable.SequenceEqual(code.SubstitutionTable));
    }
}