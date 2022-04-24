using App;
using App.Types;

internal class Program
{
    private static void Main(string[] args)
    {
        var froms = new List<string> { "MAD", "JFK", "CPH" };
        var tos = new List<string> { "AUH", "FUE", "MAD" };

        foreach (var from in froms)
        foreach (var to in tos)
        {
            var parms = new Params
                { from = from, to = to, depart = "2022-05-09", arrive = "2030-05-16", maxConnections = 10 };
            var scrapper = new Scrapper(parms);
            scrapper.execute();
        }
    }
}