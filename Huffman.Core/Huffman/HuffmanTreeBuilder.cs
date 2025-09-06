namespace Huffman.Core.Huffman;

public static class HuffmanTreeBuilder
{
    public static IEnumerable<HuffmanNode> CreateTree(IEnumerable<HuffmanNode> nodes)
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
}
