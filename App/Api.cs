using App.Types;
using QuickType;

namespace App;

public class Api
{
    public static Flights flights(Params parms)
    {
        var client = new HttpClient();
        var response = client
            .GetAsync(
                $"http://homeworktask.infare.lt/search.php?from={parms.from}&to={parms.to}&depart={parms.depart}&return={parms.arrive}")
            .Result;
        var content = response.Content;
        var result = content.ReadAsStringAsync().Result;
        return Flights.FromJson(result);
    }
}