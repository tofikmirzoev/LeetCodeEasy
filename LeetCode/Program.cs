using System.Text;

string ToHex(int num) {

    if (num == 0)
        return "0";
        
    var sb = new StringBuilder();
        
    const string hexChars = "0123456789abcdef";

    char[] bitsRepresentation = convertToBits(num);
    for (int i = bitsRepresentation.Length; i > 0; i -= 4)
    {
        int start = Math.Max(i - 4, 0);
        int toInt = bitsToInt(bitsRepresentation[start..i]);
            
        sb.Insert(0, hexChars[toInt]);
    }

    while (sb.Length > 1 && sb[0] == '0')
        sb.Remove(0, 1);
        
    return sb.ToString();
}

char[] convertToBits(int num)
{
    var bits = new char[32];
    for (int i = 31; i >= 0; i--)
    {
        bits[31 - i] = ((num >> i) & 1) == 1 ? '1' : '0';
    }
        
    return bits;
}

int bitsToInt(char[] bits)
{
    int toInt = 0;

    for (int i = bits.Length -1; i >= 0; i--)
    {
        if (bits[i] == '1')
        {
            toInt += (1 << (bits.Length - 1 - i));
        }
    }

    return toInt;
}