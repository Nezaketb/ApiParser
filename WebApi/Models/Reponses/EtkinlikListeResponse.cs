using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Reponses
{
    public class EtkinlikListeResponse
    {
        public Sayfalama sayfalama { get; set; }

        public List<Etkinlik> kayitlar { get; set; }
    }
}
