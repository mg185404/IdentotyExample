using IdentotyExample.Enums;

namespace IdentotyExample.Models
{
    public class LocalDateTime
    {
        public CalendarSystem Calendar { get; set; }
        public int CenturyOfEra { get; set; }
        public int Year { get; set; }
        public int YearOfCentury { get; set; }
        public int YearOfEra { get; set; }
        public Era Era { get; set; }
        public int WeekYear { get; set; }
        public int Month { get; set; }
        public int WeekOfWeekYear { get; set; }
        public int DayOfYear { get; set; }
        public int Day { get; set; }
        public IsoDayOfWeek IsoDayOfWeek { get; set; }
        public int DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int ClockHourOfHalfDay { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int Millisecond { get; set; }
        public int TickOfSecond { get; set; }
        public int TickOfDay { get; set; }
        public LocalTime TimeOfDay { get; set; }
        public LocalDate Date { get; set; }

    }
}
