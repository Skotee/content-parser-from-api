public class CsvContentParserTests
{
    [Fact]
    public void Parse_ValidCsv_ReturnsExpectedRows()
    {
        var parser = new CsvContentParser();
        var csv = "name,age\nJan,25";

        var result = parser.Parse(csv);

        Assert.Single(result);
        Assert.Equal("Jan", result[0]["name"]);
        Assert.Equal("25", result[0]["age"]);
    }

    [Fact]
    public void Parse_MismatchedColumnCount_ThrowsContentParsingException()
    {
        var parser = new CsvContentParser();
        var csv = "name,age\nJan";

        Assert.Throws<ContentParsingException>(() => parser.Parse(csv));
    }
}
