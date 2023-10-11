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
        var expected = "100110011001110110111";

        // Act
        var code = encoder.HuffmannEncode(input);

        // Assert
        Assert.NotNull(code.EncodedText);
        Assert.Equal(expected, code.EncodedText);
    }
}