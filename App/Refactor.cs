using System.Dynamic;
using System.Reflection;
using App.Types;
using Newtonsoft.Json;
using QuickType;

namespace App;

public class Refactor
{
    private readonly Flights flights;
    private readonly Params parms;

    private readonly List<dynamic> records;
    private double cheapesInbound;
    private double cheapesOutbound;
    private Journey inboundJourney;
    private Journey[] inboundJourneys;

    private Journey outboundJourney;

    private Journey[] outboundJourneys;

    public Refactor(Flights _flights, Params _parms)
    {
        flights = _flights;
        parms = _parms;
        records = new List<dynamic>();
        cheapesInbound = 0;
        cheapesOutbound = 0;
        getOutboundJourneys();
        getInboundJourneys();
        getCheapestInboundPrice();
        getCheapestOutboundPrice();
        getCheapestInboundJourneys();
        getCheapestOutboundJourneys();
    }

    public List<dynamic> execute()
    {
        for (var i = 0; i < outboundJourneys.Length; i += 1)
        {
            records.Add(new ExpandoObject());

            outboundJourney = outboundJourneys[i];
            inboundJourney = inboundJourneys[i];

            addPrice();

            addInboundConnections();
            addOutboundConnections();

            Console.WriteLine($"{parms.from}-{parms.to} adding {getCurrentRecord()}");
        }

        return records;
    }

    public string getCurrentRecord()
    {
        var list = new List<object>();
        var record = records.Last();
        var d = (IDictionary<string, object>)record;
        foreach(var key in d.Keys)
        {
            var value = d[key];
            list.Add(value);
        }
        return string.Join(", ", list);
    }

    public void addProperty(string propertyName, object propertyValue)
    {
        var expandoDict = records.Last() as IDictionary<string, object>;
        if (expandoDict.ContainsKey(propertyName))
            expandoDict[propertyName] = propertyValue;
        else
            expandoDict.Add(propertyName, propertyValue);
    }

    private void addConnections(Journey journey, string title)
    {
       
        for (var i = 0; i < journey.Flights.Length; i++)
        {
            var flight = journey.Flights[i];
           
            addProperty($"{title} {i + 1} airport departure", flight.AirportDeparture.Code);
            addProperty($"{title} {i + 1} airport arrival", flight.AirportArrival.Code);
            addProperty($"{title} {i + 1} time departure", flight.DateDeparture);
            addProperty($"{title} {i + 1} time arrival", flight.DateArrival);
            addProperty($"{title} {i + 1} flight number", flight.CompanyCode + flight.Number);
        }
    }

    private void addInboundConnections()
    {
        Console.WriteLine(JsonConvert.SerializeObject(outboundJourney));
        addConnections(outboundJourney, "Inbound");
    }

    private void addOutboundConnections()
    {
        addConnections(inboundJourney, "Outbound");
    }

    private void addPrice()
    {
        addProperty("Price", getPrice(outboundJourney.RecommendationId).ToString());
        addProperty("Taxes", (outboundJourney.ImportTaxAdl + inboundJourney.ImportTaxAdl).ToString());
    }

    private double getPrice(double id)
    {
        foreach (var availability in flights.Body.Data.TotalAvailabilities)
            if (availability.RecommendationId == id)
                return availability.Total;
        return 0;
    }

    private void getOutboundJourneys()
    {
        outboundJourneys = Array.FindAll(flights.Body.Data.Journeys,
            journey => journey.Flights[0].AirportDeparture.Code == parms.from);
    }

    private void getInboundJourneys()
    {
        inboundJourneys = Array.FindAll(flights.Body.Data.Journeys,
            journey => journey.Flights[0].AirportDeparture.Code == parms.to);
    }

    private double filterCheapestPrice(Journey[] journeys)
    {
        var cheapest = double.MaxValue;
        for (var i = 0; i < journeys.Length; i++)
        {
            var journey = journeys[i];
            var price = getPrice(journey.RecommendationId);
            if (price < cheapest)
                cheapest = price;
        }

        return cheapest;
    }

    private Journey[] filterCheapestJourneys(Journey[] journeys, double cheapest)
    {
        return Array.FindAll(journeys,
            journey => getPrice(journey.RecommendationId) == cheapest);
    }

    private void getCheapestInboundPrice()
    {
        cheapesInbound = filterCheapestPrice(inboundJourneys);
    }

    private void getCheapestOutboundPrice()
    {
        cheapesOutbound = filterCheapestPrice(outboundJourneys);
    }

    private void getCheapestInboundJourneys()
    {
        inboundJourneys = filterCheapestJourneys(inboundJourneys, cheapesInbound);
    }

    private void getCheapestOutboundJourneys()
    {
        outboundJourneys = filterCheapestJourneys(outboundJourneys, cheapesOutbound);
    }
}