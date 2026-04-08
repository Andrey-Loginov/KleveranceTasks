using System.Text;

namespace first;

internal static class StringCompressor
{
    public static string Compress(this string inp)
    {
        if (string.IsNullOrEmpty(inp))
            return inp;
        StringBuilder compressed = new StringBuilder();
        int count = 1;
        for (int i = 1; i < inp.Length; i++)
        {
            if (inp[i] == inp[i - 1])
            {
                count++;
            }
            else
            {
                compressed.Append(inp[i - 1]);
                if (count > 1)
                    compressed.Append(count);
                count = 1;
            }
        }
        compressed.Append(inp[inp.Length - 1]);
        if (count > 1)
            compressed.Append(count);
        return compressed.ToString();
    }

    public static string DeCompress(this string inp)
    {
        if (string.IsNullOrEmpty(inp))
            return inp;
        StringBuilder decompressed = new StringBuilder();
        for (int i = 0; i < inp.Length; i++)
        {
            char currentChar = inp[i];
            int count = 1;
            if (i + 1 < inp.Length && char.IsDigit(inp[i + 1]))
            {
                int j = i + 1;
                while (j < inp.Length && char.IsDigit(inp[j]))
                {
                    j++;
                }
                count = int.Parse(inp.Substring(i + 1, j - i - 1));
                i = j - 1;
            }
            decompressed.Append(new string(currentChar, count));
        }
        return decompressed.ToString();
    }
}