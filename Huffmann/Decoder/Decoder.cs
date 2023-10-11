namespace Huffmann.Huffmann.Decoder;

public class Decoder
{
    public string HuffmannDecode(string code, Dictionary<char, string> substitutionTable)
    {
        var encodedText = string.Empty;

        while (code.Length > 0)
        {
            var pointer = 0;
            var found = false;
            var partialCode = string.Empty;

            while (!found)
            {
                partialCode += code[pointer];

                if (substitutionTable.Values.Contains(partialCode))
                {
                    encodedText += substitutionTable.First(x => x.Value == partialCode).Key;
                    found = true;
                } else
                {
                    pointer++;
                }

                if (pointer == code.Length) break;
            }

            code = code.Substring(pointer+1);
        }

        return encodedText;
    }
}
