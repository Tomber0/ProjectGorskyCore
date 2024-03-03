namespace Framework.Utils
{
    public static class StringUtils
    {
        public static double ToDouble(this string value) 
        {
            return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
