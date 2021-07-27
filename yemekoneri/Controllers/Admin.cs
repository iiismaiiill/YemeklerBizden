using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Entities;

namespace yemekoneri.Controllers
{
    
    public class Admin : Controller
    {
        private IKullaniciRepository kullaniciRepository;
        private IYemekRepository yemekRepository;
        private IYorumRepository yorumRepository;
        public Admin(IKullaniciRepository _kullaniciRepository, IYemekRepository _yemekRepository, IYorumRepository _yorumRepository)
        {
            kullaniciRepository = _kullaniciRepository;
            yemekRepository = _yemekRepository;
            yorumRepository = _yorumRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult GetPersons()
        {
            List<Kullanici> kullanicilar = kullaniciRepository.GetAll().ToList();
            return Ok(kullanicilar);
        }

        public IActionResult DeletePerson(int id)
        {
            Kullanici kullanici = kullaniciRepository.GetAll().Where(X => X.KullaniciId == id).FirstOrDefault();
            kullaniciRepository.Remove(kullanici);
            kullaniciRepository.Save();
            return Ok();
        }

        public IActionResult MakeAdmin(int id)
        {
            Kullanici kisi = kullaniciRepository.GetAll().Where(A => A.KullaniciId == id).FirstOrDefault();
            kisi.IsAdmin = true;
            kullaniciRepository.Update(kisi);
            kullaniciRepository.Save();


            return Ok();
        }
    
        public IActionResult GetFoods()
        {
            var foods = yemekRepository.GetAll().Where(q=>q.isActive == false);
            return Ok(foods);
        }

        public IActionResult OkFood(int id)
        {
            var yemek = yemekRepository.GetById(id);
            yemek.isActive = true;
            yemekRepository.Update(yemek);
            yemekRepository.Save();

            return Ok();
        }

        public IActionResult GetCommentss()
        {
            var comments = yorumRepository.GetAll().Where(q => q.isActive == false);
            return Ok(comments);
        }

        public IActionResult OkComment(int id)
        {
            var yorum = yorumRepository.GetById(id);
            yorum.isActive = true;
            yorumRepository.Update(yorum);
            yorumRepository.Save();

            return Ok();
        }
    }

}
