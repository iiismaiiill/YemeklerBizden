using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Entities;
using yemekoneri.LoginFilter;
using yemekoneri.Models;

namespace yemekoneri.Controllers
{
    [FilterContext]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IYemekRepository yemekRepository;
        private IYorumRepository yorumRepository;
        private IKullaniciRepository kullaniciRepository;
        private IBegenRepository begenRepository;

        public HomeController(ILogger<HomeController> logger, IYemekRepository _yemekRepository, IYorumRepository _yorumRepository, IKullaniciRepository _kullaniciRepository, IBegenRepository _begenRepository)
        {
            _logger = logger;
            kullaniciRepository = _kullaniciRepository;
            yemekRepository = _yemekRepository;
            yorumRepository = _yorumRepository;
            begenRepository = _begenRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }
        public IActionResult FoodDetail(int id)
        {
            var food = yemekRepository.GetById(id);
            return View(food);
        }
        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetCommentsOfFood(string YemekId)
        {
            var comments = yorumRepository.GetAll().Where(q=>q.YemekId == Convert.ToInt32(YemekId) && q.isActive);
            return Ok(comments);
        }

        public IActionResult SendComment(Yorum yorum)
        {
            yorum.KullaniciId = Convert.ToInt32(Request.Cookies["UserId"]);

            yorumRepository.Add(yorum);
            yorumRepository.Save();

            return Ok();
        }

        public IActionResult isLikedFood(string yemekId)
        {
            var userId = Convert.ToInt32(Request.Cookies["UserId"]);

            var isLiked = begenRepository.GetAll().Where(q => q.KullaniciId == userId && q.YemekId == Convert.ToInt32(yemekId)).FirstOrDefault();

            if (isLiked != null && isLiked.IsLike)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult countOfLikedFood(string yemekId)
        {
            var likeCount = begenRepository.GetAll().Where(q => q.YemekId == Convert.ToInt32(yemekId) && q.IsLike).Count();
            var disLikeCount = begenRepository.GetAll().Where(q => q.YemekId == Convert.ToInt32(yemekId) && !q.IsLike).Count();
            

            return Ok(new { likeCount,disLikeCount} );
        }

        public IActionResult likeFoodOrDisLike(bool like, string yemekId)
        {
            var userId = Convert.ToInt32(Request.Cookies["UserId"]);

            var isBegeniYemek = begenRepository.GetAll().Where(q => q.KullaniciId == userId && q.YemekId == Convert.ToInt32(yemekId)).FirstOrDefault();
            if (isBegeniYemek != null)
            {
                isBegeniYemek.IsLike = like ? true : false ;
                begenRepository.Update(isBegeniYemek);
                begenRepository.Save();
            }
            else
            {
                Begen begen = new Begen() 
                { 
                    KullaniciId = userId,
                    YemekId = Convert.ToInt32(yemekId),
                    IsLike = like
                };
                begenRepository.Add(begen);
                begenRepository.Save();
            }

            return Ok();
        }



    }
}

