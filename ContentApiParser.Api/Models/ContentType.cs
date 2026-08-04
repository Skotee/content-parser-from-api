using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))] 
public enum ContentType
{
    [JsonStringEnumMemberName("CSV")]
    Csv,

    [JsonStringEnumMemberName("INTERNAL_JSON")]
    InternalJson
}
