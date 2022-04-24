using CsvHelper.Configuration.Attributes;

namespace App.Types;

public class Flight
{
    public double Price { get; set; }
    public double Taxes { get; set; }
    [Name("Outbound 1 airport departure")] public string outbound_1_airport_departure { get; set; }
    [Name("Outbound 1 airport arrival")] public string outbound_1_airport_arrival { get; set; }
    [Name("Outbound 1 time departure")] public string outbound_1_time_departure { get; set; }
    [Name("Outbound 1 time arrival")] public string outbound_1_time_arrival { get; set; }
    [Name("Outbound 2 airport departure")] public string outbound_2_airport_departure { get; set; }
    [Name("Outbound 2 airport arrival")] public string outbound_2_airport_arrival { get; set; }
    [Name("Outbound 2 time departure")] public string outbound_2_time_departure { get; set; }
    [Name("Outbound 2 time arrival")] public string outbound_2_time_arrival { get; set; }
}