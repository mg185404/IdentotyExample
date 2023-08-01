namespace IdentotyExample.Models
{
    public class PriceInterval
    {
        public double BasePrice { get; set; }
        public List<PriceTimeInterval> Changes { get; set; }
    }
}
