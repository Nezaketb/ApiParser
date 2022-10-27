using WebApi.Models.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Exceptions
{
    public class NotFoundException : Exception
    {
        private GeneralErrorResponse response;

        public NotFoundException(GeneralErrorResponse response)
            : base(response.mesaj)
        {
            this.response = response;
        }

        public GeneralErrorResponse getResponse()
        {
            return this.response;
        }
    }
}
