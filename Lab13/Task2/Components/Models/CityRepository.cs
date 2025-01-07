namespace Task2.Components.Models
{
    public class CityRepository
    {
        public static List<string> cities = new List<string>()
        {
            "Toronto",
            "Montreal",
            "Ottawa",
            "Calgary",
            "Halifax"
        };
        public static List<string> GetCities() => cities;
    }
}
