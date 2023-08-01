namespace IdentotyExample.Models.Dto
{
    public class OutNearbySitesByCoordinate
    {
        public Site Site { get; set; }
        public double Distance { get; set; }
        public bool InDeliveryZone { get; set; }
        public string SpecialEventReasons { get; set; }
        public List<SiteAttribute> Attributes { get; set; }
        public List<Setting> SiteSettings { get; set; }
        public List<Daypart> Dayparts { get; set; }
        public List<ManualDaypart> ManualDayparts { get; set; }
    }
}
