namespace Huffman.Core.Huffman;

public static class HuffmanCodeGenerator
{
    public static Dictionary<char, string> CreateCode(Dictionary<char, int> charFrequencyMap)
    {
        if (charFrequencyMap.Keys.Count < 2) throw new ArgumentException();

        var nodes = CreateNodes(charFrequencyMap);
        var tree = HuffmanTreeBuilder.CreateTree(nodes);

        return CreateHuffmanCode(tree);
    }

    private static IEnumerable<HuffmanNode> CreateNodes(Dictionary<char, int> charFrequencyMap)
    {
        return charFrequencyMap.Keys.Select(c => new HuffmanNode
        {
            CharSequenz = c.ToString(),
            Frequency = charFrequencyMap[c]
        });
    }

    private static Dictionary<char, string> CreateHuffmanCode(IEnumerable<HuffmanNode> tree)
    {
        var table = new Dictionary<char, string>();
        if (!tree.Any()) return table;

        var root = tree.MaxBy(node => node.CharSequenz.Length);
        var chars = root.CharSequenz.ToCharArray();

        foreach (var c in chars)
        {
            var currentNode = root;
            var code = "";
            while (HasChildNode(currentNode) && HasCharInChild(currentNode, c))
            {
                if (HasCharInRightChildNode(currentNode, c))
                {
                    code += "1";
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    code += "0";
                    currentNode = currentNode.LeftChild;
                }
            }

            table.Add(c, code);
        }

        return table;
    }

    private static bool HasChildNode(HuffmanNode node)
    {
        return node.LeftChild != null || node.RightChild != null;
    }

    private static bool HasCharInChild(HuffmanNode node, char target)
    {
        return HasCharInLeftChildNode(node, target) || HasCharInRightChildNode(node, target);
    }

    private static bool HasCharInLeftChildNode(HuffmanNode node, char target)
    {
        if (node.LeftChild == null) return false;
        return node.LeftChild.CharSequenz.Contains(target);
    }

    private static bool HasCharInRightChildNode(HuffmanNode node, char target)
    {
        if (node.RightChild == null) return false;
        return node.RightChild.CharSequenz.Contains(target);
    }
}
