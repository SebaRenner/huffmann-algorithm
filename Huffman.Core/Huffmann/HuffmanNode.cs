namespace Huffman.Core.Huffman;

public class Huffmanode : IComparable<Huffmanode>
{
    public required string CharSequenz { get; set; }

    public int Frequency { get; set; }

    public Huffmanode? LeftChild { get; set; }

    public Huffmanode? RightChild { get; set; }

    public int CompareTo(Huffmanode? other)
    {
        return CharSequenz.CompareTo(other?.CharSequenz);
    }
}
