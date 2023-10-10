namespace Huffmann.Huffmann.Huffmann;

public class HuffmannTree
{
    public Dictionary<char, string> CreateHuffmanCode(Dictionary<char, int> charFrequencyMap)
    {
        var nodes = CreateNodes(charFrequencyMap);
        var tree = CreateTree(nodes);
        return CreateHuffmannCode(tree);
    }

    private IEnumerable<HuffmannNode> CreateNodes(Dictionary<char, int> charFrequencyMap)
    {
        return charFrequencyMap.Keys.Select(c => new HuffmannNode
        {
            CharSequenz = c.ToString(),
            Frequency = charFrequencyMap[c]
        });
    }

    private IEnumerable<HuffmannNode> CreateTree(IEnumerable<HuffmannNode> nodes)
    {
        var sorted = new SortedSet<HuffmannNode>(nodes);
        var tree = new List<HuffmannNode>();

        while (sorted.Count > 1)
        {
            var leftNode = sorted.MinBy(node => node.Frequency);
            sorted.Remove(leftNode);

            var rightNode = sorted.MinBy(node => node.Frequency);
            sorted.Remove(rightNode);

            var parent = new HuffmannNode
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

    private Dictionary<char, string> CreateHuffmannCode(IEnumerable<HuffmannNode> tree)
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

    private bool HasChildNode(HuffmannNode node)
    {
        return node.LeftChild != null || node.RightChild != null;
    }

    private bool HasCharInChild(HuffmannNode node, char target)
    {
        return HasCharInLeftChildNode(node, target) || HasCharInRightChildNode(node, target);
    }

    private bool HasCharInLeftChildNode(HuffmannNode node, char target)
    {
        if (node.LeftChild == null) return false;
        return node.LeftChild.CharSequenz.Contains(target);
    }

    private bool HasCharInRightChildNode(HuffmannNode node, char target)
    {
        if (node.RightChild == null) return false;
        return node.RightChild.CharSequenz.Contains(target);
    }
}
