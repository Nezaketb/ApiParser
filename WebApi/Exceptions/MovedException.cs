using WebApi.Models.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Exceptions
{
    public class MovedException : Exception
    {
        private EtkinlikMovedResponse response;

        public MovedException(EtkinlikMovedResponse response)
            : base(response.mesaj)
        {
            this.response = response;
        }

        public EtkinlikMovedResponse getResponse()
        {
            return this.response;
        }
    }
}
