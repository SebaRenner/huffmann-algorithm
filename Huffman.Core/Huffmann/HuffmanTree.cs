namespace Huffman.Core.Huffman;

// TODO: Class doens't follow SRP. Refactor it. 
// Also why not static? 
public class HuffmanTree
{
    public Dictionary<char, string> CreateHuffmanCode(Dictionary<char, int> charFrequencyMap)
    {
        if (charFrequencyMap.Keys.Count < 2) throw new ArgumentException();

        var nodes = CreateNodes(charFrequencyMap);
        var tree = CreateTree(nodes);
        return CreateHuffmanCode(tree);
    }

    private IEnumerable<HuffmanNode> CreateNodes(Dictionary<char, int> charFrequencyMap)
    {
        return charFrequencyMap.Keys.Select(c => new HuffmanNode
        {
            CharSequenz = c.ToString(),
            Frequency = charFrequencyMap[c]
        });
    }

    private IEnumerable<HuffmanNode> CreateTree(IEnumerable<HuffmanNode> nodes)
    {
        var sorted = new SortedSet<HuffmanNode>(nodes);
        var tree = new List<HuffmanNode>();

        while (sorted.Count > 1)
        {
            var leftNode = sorted.MinBy(node => node.Frequency);
            sorted.Remove(leftNode);

            var rightNode = sorted.MinBy(node => node.Frequency);
            sorted.Remove(rightNode);

            var parent = new HuffmanNode
            {
                CharSequenz = $"{leftNode.CharSequenz}{rightNode.CharSequenz}",
                Frequency = leftNode.Frequency + rightNode.Frequency,
                LeftChild = leftNode,
                RightChild = rightNode
            };

            sorted.Add(parent);
            tree.Add(leftNode);
            tree.Add(rightNode);
        }

        tree.Add(sorted.First());

        return tree;
    }

    private Dictionary<char, string> CreateHuffmanCode(IEnumerable<HuffmanNode> tree)
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

    private bool HasChildNode(HuffmanNode node)
    {
        return node.LeftChild != null || node.RightChild != null;
    }

    private bool HasCharInChild(HuffmanNode node, char target)
    {
        return HasCharInLeftChildNode(node, target) || HasCharInRightChildNode(node, target);
    }

    private bool HasCharInLeftChildNode(HuffmanNode node, char target)
    {
        if (node.LeftChild == null) return false;
        return node.LeftChild.CharSequenz.Contains(target);
    }

    private bool HasCharInRightChildNode(HuffmanNode node, char target)
    {
        if (node.RightChild == null) return false;
        return node.RightChild.CharSequenz.Contains(target);
    }
}
