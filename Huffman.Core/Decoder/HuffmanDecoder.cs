using Huffman.Core.Huffman;

namespace Huffman.Core.Decoder;

public static class HuffmanDecoder
{
    public static string Decode(string code, Dictionary<char, string> substitutionTable)
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

                if (substitutionTable.ContainsValue(partialCode))
                {
                    encodedText += substitutionTable.First(x => x.Value == partialCode).Key;
                    found = true;
                } else
                {
                    pointer++;
                }

                if (pointer == code.Length) break;
            }

            code = code.Substring(pointer + 1);
        }

        return encodedText;
    }

    public static string Decode(string code, IEnumerable<HuffmanNode> HuffmanTree)
    {
        var encodedText = string.Empty;

        while (code.Length > 0)
        {
            var currentNode = HuffmanTree.MaxBy(node => node.CharSequenz.Length);

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
