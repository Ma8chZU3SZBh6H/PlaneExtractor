using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickType;

public partial class Flights
{
    [JsonProperty("header")] public Header Header { get; set; }

    [JsonProperty("body")] public Body Body { get; set; }
}

public class Body
{
    [JsonProperty("data")] public Data Data { get; set; }
}

public class Data
{
    [JsonProperty("sessionId")] public string SessionId { get; set; }

    [JsonProperty("availabilityId")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long AvailabilityId { get; set; }

    [JsonProperty("locale")] public string Locale { get; set; }

    [JsonProperty("marketCode")] public string MarketCode { get; set; }

    [JsonProperty("swirt")] public bool Swirt { get; set; }

    [JsonProperty("switax")] public bool Switax { get; set; }

    [JsonProperty("swisdto")] public bool Swisdto { get; set; }

    [JsonProperty("adultPax")] public long AdultPax { get; set; }

    [JsonProperty("childPax")] public long ChildPax { get; set; }

    [JsonProperty("infantPax")] public long InfantPax { get; set; }

    [JsonProperty("adultPaxResident")] public long AdultPaxResident { get; set; }

    [JsonProperty("childPaxResident")] public long ChildPaxResident { get; set; }

    [JsonProperty("infantPaxResident")] public long InfantPaxResident { get; set; }

    [JsonProperty("messageItemization")] public object[] MessageItemization { get; set; }

    [JsonProperty("serviceFee")] public long ServiceFee { get; set; }

    [JsonProperty("serviceFeeDiscount")] public long ServiceFeeDiscount { get; set; }

    [JsonProperty("serviceFeeResidentDiscount")]
    public long ServiceFeeResidentDiscount { get; set; }

    [JsonProperty("totalAvailabilities")] public TotalAvailability[] TotalAvailabilities { get; set; }

    [JsonProperty("journeys")] public Journey[] Journeys { get; set; }

    [JsonProperty("calendarJourneys")] public object[] CalendarJourneys { get; set; }

    [JsonProperty("journeyConstraint")] public object[] JourneyConstraint { get; set; }

    [JsonProperty("blockType")] public string BlockType { get; set; }

    [JsonProperty("availabilityFactor")] public AvailabilityFactor AvailabilityFactor { get; set; }

    [JsonProperty("showDiscounts")] public bool ShowDiscounts { get; set; }

    [JsonProperty("discountLabel")] public string DiscountLabel { get; set; }

    [JsonProperty("swiservicefee")] public bool Swiservicefee { get; set; }

    [JsonProperty("availabilityZoneType")] public string AvailabilityZoneType { get; set; }
}

public class AvailabilityFactor
{
    [JsonProperty("availabilityProviderType")]
    public string AvailabilityProviderType { get; set; }

    [JsonProperty("availabilityProviderReasonType")]
    public string AvailabilityProviderReasonType { get; set; }
}

public class Journey
{
    [JsonProperty("recommendationId")] public long RecommendationId { get; set; }

    [JsonProperty("identity")] public long Identity { get; set; }

    [JsonProperty("direction")] public string Direction { get; set; }

    [JsonProperty("cabinClass")] public string CabinClass { get; set; }

    [JsonProperty("importChild")] public long ImportChild { get; set; }

    [JsonProperty("importInfant")] public long ImportInfant { get; set; }

    [JsonProperty("importAdultResident")] public long ImportAdultResident { get; set; }

    [JsonProperty("importChildResident")] public long ImportChildResident { get; set; }

    [JsonProperty("importInfantResident")] public long ImportInfantResident { get; set; }

    [JsonProperty("discountAdultResident")]
    public long DiscountAdultResident { get; set; }

    [JsonProperty("discountChildResident")]
    public long DiscountChildResident { get; set; }

    [JsonProperty("discountInfantResident")]
    public long DiscountInfantResident { get; set; }

    [JsonProperty("importTaxAdl")] public double ImportTaxAdl { get; set; }

    [JsonProperty("importTaxChd")] public long ImportTaxChd { get; set; }

    [JsonProperty("importTaxInf")] public long ImportTaxInf { get; set; }

    [JsonProperty("classCode")] public string ClassCode { get; set; }

    [JsonProperty("farebasisCode")] public string FarebasisCode { get; set; }

    [JsonProperty("promotionLabel")] public object PromotionLabel { get; set; }

    [JsonProperty("flights")] public Flight[] Flights { get; set; }

    [JsonProperty("businessJourneys")] public object[] BusinessJourneys { get; set; }

    [JsonProperty("passengersAvailable")] public long PassengersAvailable { get; set; }

    [JsonProperty("fareFamily")] public FareFamily FareFamily { get; set; }

    [JsonProperty("franchiseInformation")] public FranchiseInformation FranchiseInformation { get; set; }

    [JsonProperty("cabinInformation")] public CabinInformation CabinInformation { get; set; }
}

public class CabinInformation
{
    [JsonProperty("number")] public long Number { get; set; }

    [JsonProperty("baggageWeight")] public BaggageWeight BaggageWeight { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}

public class BaggageWeight
{
    [JsonProperty("amount")] public long Amount { get; set; }

    [JsonProperty("measurementType")] public FareFamily MeasurementType { get; set; }
}

public class FareFamily
{
    [JsonProperty("code")] public string Code { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}

public class Flight
{
    [JsonProperty("number")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Number { get; set; }

    [JsonProperty("airportDeparture")] public Airport AirportDeparture { get; set; }

    [JsonProperty("airportArrival")] public Airport AirportArrival { get; set; }

    [JsonProperty("dateDeparture")] public string DateDeparture { get; set; }

    [JsonProperty("dateArrival")] public string DateArrival { get; set; }

    [JsonProperty("gmtDateDeparture")] public string GmtDateDeparture { get; set; }

    [JsonProperty("gmtDateArrival")] public string GmtDateArrival { get; set; }

    [JsonProperty("companyCode")] public string CompanyCode { get; set; }

    [JsonProperty("operator")] public string Operator { get; set; }

    [JsonProperty("flote")] public FareFamily Flote { get; set; }

    [JsonProperty("technicalStop")] public TechnicalStop TechnicalStop { get; set; }

    [JsonProperty("terminalDeparture")] public string TerminalDeparture { get; set; }

    [JsonProperty("terminalArrival")] public string TerminalArrival { get; set; }

    [JsonProperty("cabinClass")] public FareFamily CabinClass { get; set; }
}

public class Airport
{
    [JsonProperty("code")] public string Code { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("resident")] public bool Resident { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("zone")] public string Zone { get; set; }

    [JsonProperty("image")] public Uri Image { get; set; }
}

public class TechnicalStop
{
    [JsonProperty("numberStops")] public long NumberStops { get; set; }

    [JsonProperty("airportStops")] public object[] AirportStops { get; set; }
}

public class FranchiseInformation
{
    [JsonProperty("franchise")] public long Franchise { get; set; }

    [JsonProperty("baggageWeight")] public BaggageWeight BaggageWeight { get; set; }

    [JsonProperty("hiringSupported")] public bool HiringSupported { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}

public class TotalAvailability
{
    [JsonProperty("recommendationId")] public long RecommendationId { get; set; }

    [JsonProperty("total")] public double Total { get; set; }
}

public class Header
{
    [JsonProperty("message")] public string Message { get; set; }

    [JsonProperty("code")] public long Code { get; set; }

    [JsonProperty("error")] public bool Error { get; set; }

    [JsonProperty("bodyType")] public string BodyType { get; set; }
}

public partial class Flights
{
    public static Flights FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Flights>(json, Converter.Settings);
    }
}

public static class Serialize
{
    public static string ToJson(this Flights self)
    {
        return JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new()
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        }
    };
}

internal class ParseStringConverter : JsonConverter
{
    public static readonly ParseStringConverter Singleton = new();

    public override bool CanConvert(Type t)
    {
        return t == typeof(long) || t == typeof(long?);
    }

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        long l;
        if (long.TryParse(value, out l)) return l;
        throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (long)untypedValue;
        serializer.Serialize(writer, value.ToString());
    }
}