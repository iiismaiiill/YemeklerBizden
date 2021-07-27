using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.Entities
{
    public class Begen
    {
        public int BegenId { get; set; }
        public bool IsLike { get; set; }
        public Kullanici Kullanici { get; set; }
        public Yemek Yemek { get; set; }
        public int KullaniciId { get; set; }
        public int YemekId { get; set; }
    }
}
