public interface IContentParser
{
    ContentType SupportedType { get; }
    List<Dictionary<string, object?>> Parse(string decodedContent); // zwracany typ to ten sam co w ParseContentResponse.Data — zapobiegnie to dodatkowemu przekształceniu między parserem a odpowiedzią
}
