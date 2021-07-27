using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.Entities
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public List<Yemek> Yemekler { get; set; }

    }
}
