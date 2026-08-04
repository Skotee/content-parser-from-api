public class InternalJsonContentParserTests
{
    [Fact]
    public void Parse_ValidInternalJson_ReturnsExpectedRows()
    {
        var parser = new InternalJsonContentParser();
        var json = "[{\"name\":\"Jan\",\"age\":25}]";

        var result = parser.Parse(json);

        Assert.Single(result);
        Assert.Equal("Jan", result[0]["name"].ToString());
    }

    [Fact]
    public void Parse_InvalidJson_ThrowsContentParsingException()
    {
        var parser = new InternalJsonContentParser();

        Assert.Throws<ContentParsingException>(() => parser.Parse("niepoprawny json"));
    }
}