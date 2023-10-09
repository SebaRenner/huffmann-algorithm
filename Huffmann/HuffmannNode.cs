namespace Huffmann.Huffmann;

public class HuffmannNode : IComparable<HuffmannNode>
{
    public required string CharSequenz { get; set; }

    public int Frequency { get; set; }

    public HuffmannNode? LeftChild { get; set; }

    public HuffmannNode? RightChild { get; set; }

    public int CompareTo(HuffmannNode? other)
    {
        return CharSequenz.CompareTo(other?.CharSequenz);
    }
}
