using System.Net;
using WebApi.Entity;

namespace WebApiForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<City> JsonListe()
        {
            List<City> JsonModelList = null;

            try
            {
                WebClient client = new WebClient();
                String JsonText = client.DownloadString(@"https://backend.etkinlik.io/api/v2/categories");
                JsonModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(JsonText);
                grdListe.DataSource = JsonModelList;

            }
            catch (Exception ex)
            {
                JsonModelList = null;
            }

            return JsonModelList;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            JsonListe();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            JsonListe();
        }
    }
}