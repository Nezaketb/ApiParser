using WebApi.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Exceptions;
using WebApi.Exceptions;

namespace WebApi.Services
{
    public class KategoriService
    {
        private ApiClient client;

        public KategoriService(ApiClient client)
        {
            this.client = client;
        }

        public List<Kategori> GetList()
        {
            HttpWebResponse response = client.ApiCall("/kategoriler");
            StreamReader reader = new StreamReader(response.GetResponseStream());
            
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Kategori>>(reader.ReadToEnd());

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }
            throw new UnknownException(response);

        }
    }
}
