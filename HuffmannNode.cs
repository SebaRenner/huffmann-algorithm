namespace Huffmann;

public class HuffmannNode
{
    public required string CharSequenz { get; set; } 

    public int Frequency { get; set; }
    
    public HuffmannNode? LeftChild { get; set; }

    public HuffmannNode? RightChild { get; set; }
}
