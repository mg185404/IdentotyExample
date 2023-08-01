using IdentotyExample.Enums;

namespace IdentotyExample.Models
{
    public class LocalDate
    {
        public CalendarSystem Calendar { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public IsoDayOfWeek IsoDayOfWeek { get; set; }
        public int DayOfWeek { get; set; }
        public int WeekYear { get; set; }
        public int WeekOfWeekYear { get; set; }
        public int YearOfCentury { get; set; }
        public int YearOfEra { get; set; }
        public Era Era { get; set; }
        public int DayOfYear { get; set; }

    }
}
