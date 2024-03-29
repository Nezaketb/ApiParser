﻿using WebApi.Exceptions;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WebApi.Services
{
    public class SehirService
    {
        private ApiClient client;

        public SehirService(ApiClient client)
        {
            this.client = client;
        }

        public List<Sehir> GetList()
        {
            HttpWebResponse response = client.ApiCall("/sehirler");

            StreamReader reader = new StreamReader(response.GetResponseStream());

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Sehir>>(reader.ReadToEnd());

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }

            throw new UnknownException(response);
        }
    }
}
