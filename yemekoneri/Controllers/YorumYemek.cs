using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Entities;

namespace yemekoneri.Controllers
{
    public class YorumYemek : Controller
    {
        private IYorumRepository yorumRepository;
        private IYemekRepository yemekRepository;
        private IKullaniciRepository kullaniciRepository;
        public YorumYemek(IYemekRepository _yemekRepository, IYorumRepository _yorumRepository, IKullaniciRepository _kullaniciRepository)
        {
            yorumRepository = _yorumRepository;
            yemekRepository = _yemekRepository;
            kullaniciRepository = _kullaniciRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetYorumlar()
        {
            var id = Convert.ToInt32(Request.Cookies["UserId"]);
            var yorums = yorumRepository.GetAll().Where(asdasd => asdasd.KullaniciId == id);
            return Ok(yorums);
        }

        public IActionResult GetYemekler()
        {
            var yemeks = yemekRepository.GetAll();
            return Ok(yemeks);
        }
        [HttpPost]
        public IActionResult GetFilteredFoods(string YemekAciklamasi)
        {
            var yemek = yemekRepository.GetAll().Where(A => A.YemekAciklamasi.Contains(YemekAciklamasi) || A.YemekAdi.Contains(YemekAciklamasi));

            return Ok(yemek);
        }

        public IActionResult updateYorumYemek(Yorum yorum, Yemek yemek)
        {
            if (yorum.YorumId != 0)
            {
                var oldYorum = yorumRepository.GetById(yorum.YorumId);
                oldYorum.YorumAciklama = yorum.YorumAciklama;
                yorumRepository.Update(oldYorum);
                yorumRepository.Save();

                return Ok();
            }
            else if (yemek.YemekId != 0)
            {
                var oldYemek = yemekRepository.GetById(yemek.YemekId);
                oldYemek.YemekAdi = yemek.YemekAdi;
                oldYemek.YemekAciklamasi = yemek.YemekAciklamasi;
                yemekRepository.Update(oldYemek);
                yemekRepository.Save();
                return Ok();
            }


            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddFood(Yemek yemek)
        {
            yemek.KullaniciId = Convert.ToInt32(Request.Cookies["UserId"]);
            yemekRepository.Add(yemek);
            yemekRepository.Save();

            return Ok();
        }

        public IActionResult AddComment(Yorum yorum)
        {
            yorumRepository.Add(yorum);
            yorumRepository.Save();

            return Ok();
        }

        public IActionResult DeleteComment(int id)
        {
            var yorum = yorumRepository.GetById(id);
            yorumRepository.Remove(yorum);
            yorumRepository.Save();
            return Ok();

        }

        public IActionResult DeleteFood(int id)
        {
            var yemek = yemekRepository.GetById(id);
            yemekRepository.Remove(yemek);
            yemekRepository.Save();
            return Ok();

        }

        public IActionResult GetComment(int id)
        {
            var yorum = yorumRepository.GetById(id);
            return Ok(yorum);
        }

        public IActionResult GetFood(int id)
        {
            var yemek = yemekRepository.GetById(id);
            return Ok(yemek);
        }
    }
}
