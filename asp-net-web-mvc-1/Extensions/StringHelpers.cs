namespace asp_net_web_mvc_1.Extensions
{
    public static class StringHelpers
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}