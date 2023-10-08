namespace Huffmann;

public class HuffmannTree
{
    public HuffmannTree(Dictionary<char, int> charFrequencyMap)
    {
        var nodes = CreateNodes(charFrequencyMap);
        var tree = CreateTree(nodes);
        var table = CreateHuffmannTable(tree);

        foreach (var node in table)
        {
            Console.WriteLine(node.Key + ": " + node.Value);
        }
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

        //foreach (var node in tree)
        //{
        //    Console.WriteLine($"{node.CharSequenz}: {node.Frequency}");
        //}

        return tree;
    }

    private Dictionary<char, string> CreateHuffmannTable(IEnumerable<HuffmannNode> tree)
    {
        var table = new Dictionary<char, string>();
        if (tree.Count() == 0) return table;

        var root = tree.MaxBy(node => node.CharSequenz.Length);
        var chars = root!.CharSequenz.ToCharArray();

        foreach (var c in chars)
        {
            var currentNode = root;
            var code = "";
            while ((currentNode.LeftChild != null || currentNode.RightChild != null) && (currentNode.LeftChild.CharSequenz.Contains(c) || currentNode.RightChild.CharSequenz.Contains(c)))
            {
                if (currentNode.RightChild.CharSequenz.Contains(c))
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
}
