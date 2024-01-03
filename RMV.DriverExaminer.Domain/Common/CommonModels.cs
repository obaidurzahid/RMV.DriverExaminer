namespace RMV.DriverExaminer.Domain.Common
{
    public class Response
    {
        public string? ReturnCode { get; set; }
        public int? ReturnCodeInt { get; set; }
        public long? ReturnCodeLong { get; set; }
        public required bool IsSuccess { get; set; }
        public required string Message { get; set; }
    }
    public class NameId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class TextValue
    {
        public required string Value { get; set; }
        public required string Text { get; set; }
    }


    public class NameValue
    {
        public required string Name { get; set; }
        public decimal? Value { get; set; }
    }
}
