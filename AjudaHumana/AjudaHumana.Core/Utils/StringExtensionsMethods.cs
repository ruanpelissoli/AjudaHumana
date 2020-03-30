namespace AjudaHumana.Core.Utils
{
    public static class StringExtensionsMethods
    {
        public static string RemoveSpecialCharacters(this string text)
        {
            return text.Replace(".", "").Replace("-", "").Replace("/", "");
        }
    }
}
