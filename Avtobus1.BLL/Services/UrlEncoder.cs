namespace Avtobus1.BLL.Services;
public class UrlEncoder
{
    private const int       length  = 6;
    private const string    chars   = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private static Random   random  = new();
    public static string Encode()
    {
        return GenerateRandomString(length);
    }

    private static string GenerateRandomString(int length)
    {
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }
        return new string(result);
    }
}
