using System;
namespace FuelConsumption2.Models
{
    public static class PathConverter
    {
        public static string MakeValidFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            var invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}
