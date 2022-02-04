namespace NotaSpeseRESTService
{
    public class NotaSpese
    {
        public long Id { get; set; }
        public string Title { get; set; } = "Untitled";
        public string? Description { get; set; }
        public string? TextLocation { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? Amount { get; set; }
        public string? PhotoLocation { get; set; }
        public DateTime? Date { get; set; }
    }
}