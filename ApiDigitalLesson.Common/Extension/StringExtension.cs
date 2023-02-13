namespace ApiDigitalLesson.Common.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Выполнить проверку на null или empty
        /// </summary>
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
