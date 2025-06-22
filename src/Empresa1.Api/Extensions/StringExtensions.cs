namespace Empresa1.Api.Extensions;

public static class StringExtensions
{
    public static string OnlyNumbers(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        var onlyDigits = new string(str.Where(char.IsDigit).ToArray());
        return onlyDigits;
    }
}