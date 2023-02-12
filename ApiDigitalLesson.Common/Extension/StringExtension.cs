namespace ApiDigitalLesson.Common.Extension
{
    public static class StringExtension
    {
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
