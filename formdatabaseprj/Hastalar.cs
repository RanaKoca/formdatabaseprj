using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formdatabaseprj
{
    public class Hastalar
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Alerji { get; set; }
        public string Adres { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string Saat { get; set; }
        public string Tedavi { get; set; }

    }

}
