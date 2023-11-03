namespace PlaystationAPI.Models
{
    public class Playstation
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public double Price { get; set; }
        public bool Available { get; set; }
    }
}
