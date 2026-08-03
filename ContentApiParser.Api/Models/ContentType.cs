using System.Text.Json.Serialization;

public enum ContentType
{
    [JsonStringEnumMemberName("CSV")]
    Csv,

    [JsonStringEnumMemberName("INTERNAL_JSON")]
    InternalJson
}
