namespace IdentotyExample.Models
{
    public class CalendarSystem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool UsesIsoDayOfWeek { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public List<Era> Eras { get; set; }
    }
}
