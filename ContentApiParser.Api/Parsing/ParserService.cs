public class ParserService
{
    private readonly Dictionary<ContentType, IContentParser> _parsers;

    public ParserService(IEnumerable<IContentParser> parsers)
    {
        _parsers = parsers.ToDictionary(p => p.SupportedType);
    }

    public ParseContentResponse Parse(ContentType type, string decodedContent)
    {
        if (!_parsers.TryGetValue(type, out var foundValue))
        {
            throw new ContentParsingException($"Unsupported content type: {type}");
        }

        var result = foundValue.Parse(decodedContent);

        return new ParseContentResponse
        {
            Status = "Success",
            TypeProcessed = type,
            ProcessedCount = result.Count,
            Data = result
        };
    }

}
