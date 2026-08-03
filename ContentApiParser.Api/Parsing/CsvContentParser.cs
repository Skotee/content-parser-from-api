public class CsvContentParser : IContentParser
{
    public ContentType SupportedType => ContentType.Csv;

    public List<Dictionary<string, object?>> Parse(string decodedContent)
    {
        var lines = decodedContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        var rows = lines
        .Where(line => !string.IsNullOrWhiteSpace(line)) 
        .Select(line => line.Split(','))
        .ToList();

        if (rows.Count == 0)
        {
            return new List<Dictionary<string, object?>>();
        }

        var headers = rows[0];
        var result = new List<Dictionary<string, object?>>();   

        for (int rowIndex = 1; rowIndex < rows.Count; rowIndex++)
{
        var values = rows[rowIndex];

        if (values.Length != headers.Length)
        {
            throw new ContentParsingException(
                $"Row {rowIndex} has {values.Length} values, expected {headers.Length}.");
        }

        var record = new Dictionary<string, object?>();
        for (int col = 0; col < headers.Length; col++)
        {
            record[headers[col]] = values[col];
        }

        result.Add(record);
    }

    return result; 
    }
}