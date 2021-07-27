using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.Entities
{
    public class Yemek
    {
        public int YemekId { get; set; }
        public string YemekAdi { get; set; }
        public string YemekAciklamasi { get; set; }
        public bool isActive { get; set; }
        public string Yorumlar { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
    }

}
