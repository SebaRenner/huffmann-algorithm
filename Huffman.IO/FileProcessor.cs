namespace Huffman.IO;

public static class FileProcessor
{
    public static byte[] ReadBytesFromFile(string filePath)
    {
        return File.ReadAllBytes(filePath);
    }
}
