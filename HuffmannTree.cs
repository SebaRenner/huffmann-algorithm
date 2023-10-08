namespace Huffmann;

public class HuffmannTree
{  
    public HuffmannTree(Dictionary<char, int> charFrequencyMap) 
    {
        var nodes = CreateNodes(charFrequencyMap);
        CreateTree(nodes);
    }

    private IEnumerable<HuffmannNode> CreateNodes(Dictionary<char, int> charFrequencyMap)
    {
        return charFrequencyMap.Keys.Select(c => new HuffmannNode
        {
            CharSequenz = c.ToString(),
            Frequency = charFrequencyMap[c]
        });
    }

    private void CreateTree(IEnumerable<HuffmannNode> nodes)
    {
        var sorted = new SortedSet<HuffmannNode>(nodes);
        var tree = new List<HuffmannNode>();

        while (sorted.Count > 1) 
        {
            var leftNode = sorted.Min();
            sorted.Remove(leftNode!);

            var rightNode = sorted.Min();
            sorted.Remove(rightNode!);

            var parent = new HuffmannNode
            {
                CharSequenz = $"{leftNode!.CharSequenz}{rightNode!.CharSequenz}",
                Frequency = leftNode.Frequency + rightNode.Frequency,
                LeftChild = leftNode,
                RightChild = rightNode
            };

            sorted.Add(parent);
            tree.Add(leftNode);
            tree.Add(rightNode);
        }

        tree.Add(sorted.First());

        foreach (var node in tree)
        {
            Console.WriteLine($"{node.CharSequenz}: {node.Frequency}");
        }
    }
}
