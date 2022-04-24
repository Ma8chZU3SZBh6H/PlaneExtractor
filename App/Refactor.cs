using System.Dynamic;
using App.Types;
using QuickType;

namespace App;

public class Refactor
{
    private static double getPrice(Flights flights, double id)
    {
        foreach (var availability in flights.Body.Data.TotalAvailabilities)
            if (availability.RecommendationId == id)
                return availability.Total;
        return 0;
    }

    public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
    {
        // ExpandoObject supports IDictionary so we can extend it like this
        var expandoDict = expando as IDictionary<string, object>;
        if (expandoDict.ContainsKey(propertyName))
            expandoDict[propertyName] = propertyValue;
        else
            expandoDict.Add(propertyName, propertyValue);
    }

    private static void addConnections(Journey journey, ExpandoObject record, string title)
    {
        for (var i2 = 0; i2 < journey.Flights.Length; i2++)
        {
            var flight = journey.Flights[i2];
            AddProperty(record, $"{title} {i2 + 1} airport departure", flight.AirportDeparture.Code);
            AddProperty(record, $"{title} {i2 + 1} airport arrival", flight.AirportArrival.Code);
            AddProperty(record, $"{title} {i2 + 1} time departure", flight.DateDeparture);
            AddProperty(record, $"{title} {i2 + 1} time arrival", flight.DateArrival);
            AddProperty(record, $"{title} {i2 + 1} flight number", flight.CompanyCode + flight.Number);
        }
    }

    private static void addInboundConnections(Journey journey, ExpandoObject record)
    {
        addConnections(journey, record, "Inbound");
    }

    private static void addOutboundConnections(Journey journey, ExpandoObject record)
    {
        addConnections(journey, record, "Outbound");
    }

    private static Journey[] getOutboundJourneys(Flights _flights, Params parms)
    {
        return Array.FindAll(_flights.Body.Data.Journeys,
            journey => journey.Flights[0].AirportDeparture.Code == parms.from);
    }

    private static Journey[] getInboundJourneys(Flights _flights, Params parms)
    {
        return Array.FindAll(_flights.Body.Data.Journeys,
            journey => journey.Flights[0].AirportDeparture.Code == parms.to);
    }

    private static Journey[] getCheapestJourneys(Flights _flights)
    {
        var cheapest = double.MaxValue;
        for (var i = 0; i < _flights.Body.Data.Journeys.Length; i++)
        {
            var journey = _flights.Body.Data.Journeys[i];
            var price = getPrice(_flights, journey.RecommendationId);
            if (price < cheapest)
                cheapest = price;
        }

        return Array.FindAll(_flights.Body.Data.Journeys,
            journey => getPrice(_flights, journey.RecommendationId) == cheapest);
    }

    public static List<dynamic> flights(Flights _flights, Params parms)
    {
        var reformatedFlights = new List<dynamic>();
        _flights.Body.Data.Journeys = getCheapestJourneys(_flights);
        var outboundJourneys = getOutboundJourneys(_flights, parms);
        var inboundJourneys = getInboundJourneys(_flights, parms);
        for (var i = 0; i < outboundJourneys.Length; i += 1)
        {
            dynamic record = new ExpandoObject();

            var outboundJourney = outboundJourneys[i];
            var inboundJourney = inboundJourneys[i];

            record.Price = getPrice(_flights, outboundJourney.RecommendationId).ToString();
            record.Taxes = outboundJourney.ImportTaxAdl.ToString();

            addOutboundConnections(outboundJourney, record);
            addInboundConnections(inboundJourney, record);

            reformatedFlights.Add(record);
            Console.WriteLine(i);
        }


        return reformatedFlights;
    }
}