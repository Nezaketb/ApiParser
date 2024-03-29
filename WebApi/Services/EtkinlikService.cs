﻿using WebApi.Exceptions;
using WebApi.Models;
using WebApi.Models.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using WebApi.Models.Reponses;
using WebApi.Models.Requests;

namespace WebApi.Services
{
    public class EtkinlikService
    {
        private ApiClient client;

        public EtkinlikService(ApiClient client)
        {
            this.client = client;
        }

        public EtkinlikListeResponse GetList(EtkinlikListeConfig config = null)
        {
            string queryString = config == null ? "" : "?" + config.Params().ToString();

            HttpWebResponse response = client.ApiCall("/etkinlikler" + queryString);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {

                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<EtkinlikListeResponse>(result);

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }

        public Etkinlik GetById(int id)
        {
            HttpWebResponse response = client.ApiCall("/etkinlik/" + id);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Etkinlik>(result);

                case HttpStatusCode.Moved:
                    throw new MovedException(JsonConvert.DeserializeObject<EtkinlikMovedResponse>(result));

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.NotFound:
                    throw new NotFoundException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }
    }
}
