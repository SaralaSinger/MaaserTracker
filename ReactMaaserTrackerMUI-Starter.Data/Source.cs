using System.Text.Json.Serialization;

namespace ReactMaaserTrackerMUI_Starter.Data
{
    public class Source
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<Income> Incomes { get; set; }
    }
}