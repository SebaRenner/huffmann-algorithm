namespace Huffman.Core.Huffman;

public class HuffmanNode : IComparable<HuffmanNode>
{
    public required string CharSequenz { get; set; }

    public int Frequency { get; set; }

    public HuffmanNode? LeftChild { get; set; }

    public HuffmanNode? RightChild { get; set; }

    public int CompareTo(HuffmanNode? other)
    {
        return CharSequenz.CompareTo(other?.CharSequenz);
    }
}
