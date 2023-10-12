using Huffmann.Huffmann.Huffmann;

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

    public string HuffmannDecode(string code, IEnumerable<HuffmannNode> huffmannTree)
    {
        var encodedText = string.Empty;

        while (code.Length > 0)
        {
            var currentNode = huffmannTree.MaxBy(node => node.CharSequenz.Length);

            while(code.Length > 0)
            {
                var currentBit = code.First();
                currentNode = currentBit == '1' ? currentNode.RightChild : currentNode.LeftChild;

                code = code.Substring(1);
                if (code.Length == 0) break;

                var nextBit = code.First();
                if ((nextBit == '1' && currentNode.RightChild == null) || (nextBit == '0' && currentNode.LeftChild == null))
                {
                    break;
                }
            }

            encodedText += currentNode.CharSequenz;

        }

        return encodedText;
    }
}
