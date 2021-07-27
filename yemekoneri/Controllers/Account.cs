using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using yemekoneri.Bussiness.Abstract;
using yemekoneri.Entities;

namespace yemekoneri.Controllers
{
    public class Account : Controller
    {
        private IKullaniciRepository kullaniciRepository;
        public Account(IKullaniciRepository _kullaniciRepository)
        {
            kullaniciRepository = _kullaniciRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Kullanici kullanici)
        {
            Kullanici gelenKullanici = kullaniciRepository.GetAll().Where(a => a.Email == kullanici.Email).FirstOrDefault();
            if (gelenKullanici != null && gelenKullanici.Password == kullanici.Password && gelenKullanici.IsActive)
            {
                //cookie eklenecek
                HttpCookie loginCookie = new HttpCookie();
                loginCookie.Comment = "User";
                loginCookie.Value = gelenKullanici.Email;
                loginCookie.HttpOnly = true;
                loginCookie.Expires = DateTime.Now.AddHours(12);

                HttpCookie loginCookieId = new HttpCookie();
                loginCookieId.Comment = "UserId";
                loginCookieId.Value = gelenKullanici.KullaniciId.ToString();
                loginCookieId.HttpOnly = true;
                loginCookieId.Expires = DateTime.Now.AddHours(12);

                Response.Cookies.Append(loginCookie.Comment, loginCookie.Value);
                Response.Cookies.Append(loginCookieId.Comment, loginCookieId.Value);
                return RedirectToAction("MainPage","Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Kullanici kullanici)
        {
            kullanici.IsActive = true;
            kullaniciRepository.Add(kullanici);
            kullaniciRepository.Save();
            return RedirectToAction("Login");
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Kullanici kullanici)
        {
            Kullanici gelenKullanici = kullaniciRepository.GetAll().Where(a => a.Email == kullanici.Email).FirstOrDefault();
            if (gelenKullanici.Password == kullanici.Password && gelenKullanici.IsAdmin)
            {
                //cookie eklencek
                HttpCookie loginCookie = new HttpCookie();
                loginCookie.Comment = "User";
                loginCookie.Value = gelenKullanici.Email;
                loginCookie.HttpOnly = true;
                loginCookie.Expires = DateTime.Now.AddHours(12);

                HttpCookie loginCookieId = new HttpCookie();
                loginCookieId.Comment = "UserId";
                loginCookieId.Value = gelenKullanici.KullaniciId.ToString();
                loginCookieId.HttpOnly = true;
                loginCookieId.Expires = DateTime.Now.AddHours(12);

                Response.Cookies.Append(loginCookie.Comment, loginCookie.Value);
                Response.Cookies.Append(loginCookieId.Comment, loginCookieId.Value);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult ForgotPassword()
        {
            //mail gitti
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            //mail gitti
            return Ok();
        }
        public IActionResult Quit()
        {
            Response.Cookies.Delete("User");
            Response.Cookies.Delete("UserId");
            return RedirectToAction("Index","Home");
        }

        public IActionResult UpdatePassword()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePassword(string lastPassword,string newPassword)
        {
            var cookie = Request.Cookies["UserId"];
            Kullanici kisi = kullaniciRepository.GetById(Convert.ToInt32(cookie));

            if(kisi.Password == lastPassword)
            {
                kisi.Password = newPassword;
                kullaniciRepository.Update(kisi);
                kullaniciRepository.Save();
            }
            JsonModel model = new JsonModel();
            model.status = "200";
            model.message = "basarili mq";
            model.data = JsonConvert.SerializeObject(kisi);

            return Ok(JsonConvert.SerializeObject(model));
        }

        public IActionResult GetProfile()
        {
            var kullaniciId = Request.Cookies["UserId"];
            Kullanici kullanici = kullaniciRepository.GetById(Convert.ToInt32(kullaniciId));

            return Ok(kullanici);
        }

        [HttpPost]
        public IActionResult GetProfile(Kullanici kisi)
        {
            var kisiId = Request.Cookies["UserId"];
            Kullanici oldKisi = kullaniciRepository.GetById(Convert.ToInt32(kisiId));

            oldKisi.Name = kisi.Name;
            oldKisi.SurName = kisi.SurName;
            oldKisi.Email = kisi.Email;

            kullaniciRepository.Update(oldKisi);
            kullaniciRepository.Save();



            return Ok();
        }

        public IActionResult ByPassPerson()
        {
            var id = Convert.ToInt32(Request.Cookies["UserId"]);
            var kullanici = kullaniciRepository.GetById(id);
            kullanici.IsActive = false;

            kullaniciRepository.Update(kullanici);
            kullaniciRepository.Save();
            return Ok();
        }

        public IActionResult RefreshPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RefreshPassword(string mail)
        {
            SendMail(mail);
            return Ok();
        }

        public IActionResult NewPassword(string mail)
        {
            ViewBag.Mail = mail;
            return View();
        }
        [HttpPost]
        public IActionResult NewPassword(string mail,string pass)
        {
            Kullanici kullanici = kullaniciRepository.GetAll().Where(q => q.Email == mail).FirstOrDefault();
            kullanici.Password = pass;
            kullaniciRepository.Update(kullanici);
            kullaniciRepository.Save();
            return Ok();
        }

        public void SendMail(string mail)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Yemek Önerme Şifremi Unuttum.";
            msg.From = new MailAddress("hasanmertermis@gmail.com", "Yemek Önerme");
            msg.To.Add(new MailAddress(mail));
            msg.Body = string.Format("Şifrenizi unuttuğunuz için bu maili alıyorsunuz. Lütfen linke tıklayarak yeni şifre belirleyiniz. <a href='https://localhost:44388/Account/NewPassword?mail={0}'> Tıklayın </a>", mail);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            //Host ve port buraya
            SmtpClient smp = new SmtpClient("smtp.gmail.com", 587);
            //Güvenli bağlantı amacıyla kullanıcı adı ve şifre giriliyor
            NetworkCredential AccountInfo = new NetworkCredential("hasanmertermis@gmail.com", "Me9askal1");
            smp.UseDefaultCredentials = false;
            smp.Credentials = AccountInfo;
            smp.EnableSsl = true;
            smp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smp.Send(msg);
        }


    }
}
