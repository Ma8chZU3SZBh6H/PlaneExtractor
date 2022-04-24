using System.Globalization;
using App;
using App.Types;
using CsvHelper;

internal class Program
{
    private static void Main(string[] args)
    {
        var parms = new Params { from = "MAD", to = "FUE", depart = "2022-05-09", arrive = "2030-05-16" };
        var flights = Api.flights(parms);
        var reformatedFlights = Refactor.flights(flights, parms);

        Console.WriteLine(reformatedFlights.Count);

        using var writer = new StreamWriter("test.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(reformatedFlights);
        csv.Flush();
    }
}