using System.Text;

namespace BtkApiProject.Application.Extensions;

public static class VariableExtension
{
    public static string? Cryption(this string value)
    {
        string changeValue = value;
        for (int i = 0; i < 2; i++)
        {
            byte[] data = Encoding.UTF8.GetBytes(changeValue);
            string? val = Convert.ToBase64String(data);
            string val1 = val.Substring(0, 20);
            string val2 = val.Substring(20, val.Length - 20);
            changeValue = $"{val2}{val1}";
        }

        return changeValue;
    }

    public static string? DeCryption(this string value)
    {
        string changeValue = value;
        for (int i = 0; i < 2; i++)
        {
            string val1 = changeValue.Substring(0, changeValue.Length - 20);
            string val2 = changeValue.Substring(changeValue.Length - 20, 20);
            byte[] data = Convert.FromBase64String($"{val2}{val1}");
            string val = Encoding.UTF8.GetString(data);
            changeValue = val;
        }

        return changeValue;
    }
}