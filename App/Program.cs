using Newtonsoft.Json;

internal class App
{
    private static void Main(string[] args)
    {
        var client = new HttpClient();
        var response = client
            .GetAsync("http://homeworktask.infare.lt/search.php?from=MAD&to=FUE&depart=2022-05-09&return=2022-05-16")
            .Result;
        var content = response.Content;
        var result = content.ReadAsStringAsync().Result;

        dynamic test = JsonConvert.DeserializeObject(result);

        Console.WriteLine(test);
    }
}