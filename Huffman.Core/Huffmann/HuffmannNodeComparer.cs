namespace Huffman.Core.Huffman;

public class HuffmanNodeComparer : IComparer<HuffmanNode>
{
    public int Compare(HuffmanNode? x, HuffmanNode? y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;

        return x.Frequency.CompareTo(y.Frequency);
    }
}
