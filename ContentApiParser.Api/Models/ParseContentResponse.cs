  public record ParseContentResponse  
   {  
       public required string Status { get; init; }
       public required ContentType TypeProcessed { get; init; }  
       public required int ProcessedCount { get; init; }  
       public required List<Dictionary<string, object?>> Data { get; init; }
   }  