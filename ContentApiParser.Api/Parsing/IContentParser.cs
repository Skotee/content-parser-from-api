public interface IContentParser
{
    ContentType SupportedType { get; }
    List<Dictionary<string, object?>> Parse(string decodedContent); // the return type is the same as in ParseContentResponse.Data - this will prevent additional transformation between the parser and the response
}
