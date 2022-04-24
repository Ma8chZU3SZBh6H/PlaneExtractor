using System.Globalization;
using App.Types;
using CsvHelper;

namespace App;

public class Scrapper
{
    private readonly Params parms;

    public Scrapper(Params _parms)
    {
        parms = _parms;
    }

    public void execute()
    {
       
        try
        {
            var flights = Api.flights(parms);
            var refactor = new Refactor(flights, parms);
            var records = refactor.execute();

            using var writer = new StreamWriter($"{parms.from}_{parms.to}.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
            csv.Flush();
            
            Console.WriteLine($"Scrapping {parms.from}-{parms.to} finished.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Scrapping {parms.from}-{parms.to} failed with message {e.Message}");
        }
        
    }
}