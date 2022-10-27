namespace WebApi.Entity
{
    public class Activity
    {
        public int id { get; set; }

        public string adi { get; set; }

        public string radi { get; set; }

        public string url { get; set; }

        public string icerik { get; set; }

        public string baslangic { get; set; }

        public string bitis { get; set; }

        public bool ucretliMi { get; set; }

        public Format tur { get; set; }

        public Category kategori { get; set; }

        public Place mekan { get; set; }

        public List<Ticket> etiketler { get; set; }
    }

}
