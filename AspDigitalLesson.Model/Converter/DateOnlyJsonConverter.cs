using System.Globalization;
using Newtonsoft.Json;

namespace AspDigitalLesson.Model.Converter
{
    /// <summary>
    /// Конвертировать DateOnly в формат yyyy-MM-dd
    /// </summary>
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly ReadJson(JsonReader reader,
            Type objectType,
            DateOnly existingValue,
            bool hasExistingValue,
            JsonSerializer serializer) =>
            DateOnly.ParseExact((string)reader.Value, Format, CultureInfo.InvariantCulture);

        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer) => 
            writer.WriteValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}