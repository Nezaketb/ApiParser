namespace WebApi.Entity
{
    public class PlaceDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string about { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string phone { get; set; }
        public string web_url { get; set; }
        public string facebook_url { get; set; }
        public string twitter_url { get; set; }
        public City city { get; set; }
        public District district { get; set; }
        public Neighborhoods semt { get; set; }
        public string address { get; set; }
    }
}

