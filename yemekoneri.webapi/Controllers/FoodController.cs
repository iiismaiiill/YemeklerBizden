using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Entities;

namespace yemekoneri.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IYemekRepository yemekRepository;
        public FoodController(IYemekRepository _yemekRepository)
        {
            yemekRepository = _yemekRepository;
        }
        [HttpGet]
        public IActionResult GetFoods()
        {
            var foods = yemekRepository.GetAll();
            return Ok(foods);
        }
        [HttpPost]
        public IActionResult AddFood(Yemek yemek)
        {
            try
            {
                yemekRepository.Add(yemek);
                yemekRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex+" yemek eklenemedi");
            }            
            return Ok("yemek eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteFood(int id)
        {
            try
            {
                var yemek = yemekRepository.GetById(id);
                yemekRepository.Remove(yemek);
                yemekRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex + " yemek silinemedi");
            }
            return Ok("yemek silindi");
        }
        [HttpPut]
        public IActionResult UpdateFood(Yemek yemek)
        {
            try
            {
                var oldYemek = yemekRepository.GetById(yemek.YemekId);
                oldYemek.YemekAdi = yemek.YemekAdi;
                oldYemek.YemekAciklamasi = yemek.YemekAciklamasi;
                yemekRepository.Update(oldYemek);
                yemekRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex + " yemek güncellenemedi");
            }
            return Ok("yemek güncellendi");
        }
    }
}
