using WebApi.Models;
using System.Collections.Generic;
//using System.Web.Mvc;
using WebApi.Models.Requests;
using WebApi.Models;
using WebApi.Models.Reponses;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiTestController : Controller
    {
        WebApi.ApiClient client =
            new WebApi.ApiClient("b9bd400caa73cf13af5ef43ba9d0f50b");


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Etkinlik()
        {
            EtkinlikListeResponse response = client.EtkinlikService.GetList();
            ViewBag.sayfalama = response.sayfalama;
            return View(response.kayitlar);
        }

        [HttpPost]
        [Route("Etkinlik")]

        public ActionResult Etkinlik(EtkinlikFilter model)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();

            if (model.adet != 0) config.setAdet(model.adet);
            if (model.kategoriIds != null) config.setKategoriIds(model.kategoriIds);
            if (model.mekanIds != null) config.setMekanIds(model.mekanIds);
            if (model.sayfa != 0) config.setSayfa(model.sayfa);
            if (model.sehirIds != null) config.setSehirIds(model.sehirIds);
            if (model.turIds != null) config.setTurIds(model.turIds);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View(response.kayitlar);
        }


        [HttpPost]
        [Route("Kategori")]
        public ActionResult Kategori()
        {
            List<Kategori> kategoriler = client.KategoriService.GetList();
            return View(kategoriler);
        }

        [HttpPost]
        [Route("KategoriEtkinlik")]
        public ActionResult KategoriEtkinlik(string id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setKategoriIds(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        [HttpPost]
        [Route("Sehir")]
        public ActionResult Sehir()
        {
            List<Sehir> sehirler = client.SehirService.GetList();
            return View(sehirler);
        }

        [HttpPost]
        [Route("SehirEtkinlik")]
        public ActionResult SehirEtkinlik(string ids)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setSehirIds(ids);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        [HttpPost]
        [Route("Tur")]
        public ActionResult Tur()
        {
            List<Tur> turler = client.TurService.GetList();
            return View(turler);
        }
        [HttpPost]
        [Route("TurEtkinlik")]
        public ActionResult TurEtkinlik(string id)
        {
            EtkinlikListeConfig config = new EtkinlikListeConfig();
            config.setTurIds(id);

            EtkinlikListeResponse response = client.EtkinlikService.GetList(config);
            ViewBag.sayfalama = response.sayfalama;
            return View("Etkinlik", response.kayitlar);
        }

        [HttpPost]
        [Route("Ilce")]
        public ActionResult Ilce(int id)
        {
            List<Ilce> ilceler = client.IlceService.GetListBySehirId(id);
            return View(ilceler);
        }

        [HttpPost]
        [Route("Semt")]
        public ActionResult Semt(int id)
        {
            List<Semt> semtler = client.SemtService.GetListByIlceId(id);
            return View(semtler);
        }


    }
}