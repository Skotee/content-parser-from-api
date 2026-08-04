using System.Text.Json;

public class InternalJsonContentParser : IContentParser
{
    public ContentType SupportedType => ContentType.InternalJson;

    public List<Dictionary<string, object?>> Parse(string decodedContent)
    {
        try
        {
            var parsedData = JsonSerializer.Deserialize<List<Dictionary<string, object?>>>(decodedContent);
            if (parsedData == null)
            {
                throw new ContentParsingException("Parsed data is null.");
            }
            return parsedData;
        }
        catch (JsonException ex)
        {
            throw new ContentParsingException($"Failed to parse JSON content: {ex.Message}");
        }
    }
}