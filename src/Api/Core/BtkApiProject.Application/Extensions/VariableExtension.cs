using BtkApiProject.Common.Tools;
using System.Text;

namespace BtkApiProject.Application.Extensions;

public static class VariableExtension
{
    /// <summary>
    /// Encrypts the entered textual value.
    /// </summary>
    /// <param name="value">The expression to be converted must be at least 3 characters.</param>
    /// <param name="mixer">The value entered must be the same as the value in the DeCryption method. The larger the value entered, the better the mixer will be, but the processing time may be longer and the output will be longer.</param>
    /// <param name="section">The value entered must be the same as the value in the DeCryption method.</param>
    /// <returns></returns>
    public static string? Cryption(this string value, int mixer = 2, int section = 2)
    {
        if (value.Length < 3)
            throw new ArgumentException(ErrorMessages.CryptionValueError);

        if (section < 2)
            section = 2;
        else if (section > value.Length)
            section = value.Length - 2;

        if (mixer < 2)
            mixer = 2;

        string changeValue = value;
        for (int i = 0; i < mixer; i++)
        {
            byte[] data = Encoding.UTF8.GetBytes(changeValue);
            string? val = Convert.ToBase64String(data);
            string val1 = val[..section];
            string val2 = val[section..];
            changeValue = $"{val2}{val1}";
        }

        return changeValue;
    }

    /// <summary>
    /// It is used to decrypt values encrypted with the Cryption method.
    /// </summary>
    /// <param name="value">The expression to be converted must be at least 3 characters.</param>
    /// <param name="mixer">The value entered must be the same as the value in the Cryption method.</param>
    /// <param name="section">The value entered must be the same as the value in the Cryption method.</param>
    /// <returns></returns>
    public static string? DeCryption(this string value, int mixer = 2, int section = 2)
    {
        if (value.Length < 3)
            throw new ArgumentException(ErrorMessages.CryptionValueError);

        if (section < 2)
            section = 2;
        else if (section > value.Length)
            section = value.Length - 2;

        if (mixer < 2)
            mixer = 2;

        string changeValue = value;
        for (int i = 0; i < mixer; i++)
        {
            string val1 = changeValue[..^section];
            string val2 = changeValue[^section..];
            byte[] data = Convert.FromBase64String($"{val2}{val1}");
            string val = Encoding.UTF8.GetString(data);
            changeValue = val;
        }

        return changeValue;
    }
}