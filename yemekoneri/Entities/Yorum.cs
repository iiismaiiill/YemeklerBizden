using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.Entities
{
    public class Yorum
    {
        public int YorumId { get; set; }
        public string YorumMail { get; set; }
        public string YorumAciklama { get; set; }
        public bool isActive { get; set; }
        public Kullanici Kullanici { get; set; }
        public Yemek Yemek { get; set; }
        public int YemekId { get; set; }
        public int KullaniciId { get; set; }
    }
}
