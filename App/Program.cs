class App
{
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync("http://homeworktask.infare.lt/search.php?from=MAD&to=FUE&depart=2022-05-09&return=2022-05-16").Result;
        HttpContent content = response.Content;
        string result = content.ReadAsStringAsync().Result;
        Console.WriteLine(result);
    }
}