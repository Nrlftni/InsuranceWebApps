using Microsoft.AspNetCore.Mvc;

namespace InsuranceWebApps.Models
{
    public class BannerModel
    {
        public List<BannerItem> BannerItems { get; set; }
    }

    public class BannerItem
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string Url { get; set; }
    }
}
