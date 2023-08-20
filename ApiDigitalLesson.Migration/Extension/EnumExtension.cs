namespace ApiDigitalLesson.Migration.Extension
{
    public static class EnumExtension
    {
        public static int EnumToInt<TValue>(this TValue value) where TValue : Enum
            => (int)(object)value;
    }
}