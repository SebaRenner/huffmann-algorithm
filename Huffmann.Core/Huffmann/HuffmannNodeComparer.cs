namespace Huffmann.Core.Huffmann;

public class HuffmannNodeComparer : IComparer<HuffmannNode>
{
    public int Compare(HuffmannNode? x, HuffmannNode? y)
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
