namespace Project.AVIew.OtherAPI.Model.OpenWeather
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
