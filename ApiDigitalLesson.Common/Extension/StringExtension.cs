namespace ApiDigitalLesson.Common.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Выполнить проверку на null или empty
        /// </summary>
        public static bool IsNull(this string? str)
        {
            var result = str == null && string.IsNullOrEmpty(str) && string.IsNullOrWhiteSpace(str);
            return result;
        }
    }
}
