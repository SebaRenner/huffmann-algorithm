namespace Huffman.Core.Huffman;

public class HuffmanNodeComparer : IComparer<Huffmanode>
{
    public int Compare(Huffmanode? x, Huffmanode? y)
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
