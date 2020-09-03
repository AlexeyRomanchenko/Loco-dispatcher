namespace AGAT.LocoDispatcher.Common.Models
{
    public class RoutePlate : Coords
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Angle { get; set; }
    }
}
