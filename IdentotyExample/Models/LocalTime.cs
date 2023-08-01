namespace IdentotyExample.Models
{
    public class LocalTime
    {
        public int Hour { get; set; }
        public int ClockHourOfHalfDay { get; set; }
        public int Minute { get; set; }

        public int Second { get; set; }

        public int Millisecond { get; set; }

        public int TickOfSecond { get; set; }

        public int TickOfDay { get; set; }

        public LocalDateTime LocalDateTime { get; set; }
    
    }
}
