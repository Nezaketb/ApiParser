using System;
using System.Net.Http;
namespace ApiParser
{
     class Program
    {
        public void Main(string[] args)
        {
            //
            Console.WriteLine("YapilacakIslemiSecin:");
            Console.WriteLine(" 1 = Etkinlik " + Environment.NewLine + " 2 = Sehir " + Environment.NewLine + " 3 = otherayn...");
            int islem = 0;
            Console.Write(" Tip: ");
            islem = Console.Read();
            switch (islem)
            {
                case 0: Console.WriteLine("Islem Secilmedi");
                    break;
                case 1: Console.WriteLine("Etkinlik Islemi Yapiliyor");
                    Etkinlik1();
                    break;
                default:Console.WriteLine("tanimsiz islem");
                    break;
            }

            Console.WriteLine("Devam etmek için R cıkmak için E ");
            string IslemText = Console.Read().ToString();
            if(IslemText == "E" || IslemText == "e")
            {
                Main(new string[0]);
            }
            else
            {
                Environment.Exit(0);
            }

        }

        void Etkinlik1()
        {
            // burada api islemi yapilip sonuc console.write / console.writeline ile basilabilir.
        }
        void Sehir1()
        {
            var baseAddress = new Uri("https://backend.etkinlik.io/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {


                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = httpClient.GetAsync("api/v2/events"))
                {

                    string responseData = response.W
                }
            }
        }
        void OtherAnyApiRequest()
        {

        }
    }
}