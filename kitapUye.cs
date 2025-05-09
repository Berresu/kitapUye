using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Kitap
        {
            public string Baslik { get; set; }
            public string Yazar { get; set; }
            public Uye Uye { get; set; }

            public Kitap(string baslik, string yazar)
            {
                Baslik = baslik;
                Yazar = yazar;
            }

            public void UyeAta(Uye uye)
            {
                Uye = uye;
            }

            public void KitapBilgileriniGoster()
            {
                Console.WriteLine($"Kitabın Adı: {Baslik}");
                Console.WriteLine($"Kitabın Yazarı: {Yazar}");

                if (Uye != null)
                {
                    Console.WriteLine($"Kitabın Emanet Edildiği Üye: {Uye.Ad}");
                }
                else
                {
                    Console.WriteLine("Kitap Hiçbir Üyeye Emanet Edilmemiştir.");
                }
            }
        }

        public class Uye
        {
            public string Ad {  get; set; }
            public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

            public Uye(string ad)
            {
                this.Ad = ad;
            }

            public void KitapEkle(Kitap kitap)
            {
                Kitaplar.Add(kitap);
                kitap.UyeAta(this);
            }

            public void UyeninKitaplarınıGoster()
            {
                Console.WriteLine($"{Ad} İsimli Üyenin Emanet Aldığı Kitaplar:");
                foreach (var kitap in Kitaplar)
                {
                    Console.WriteLine($"- {kitap.Baslik}");
                }
            }
        }

        public class AssociationOrnek
        {
            public static void Main(string[] args)
            {
                Uye uye = new Uye("Berre");
                Kitap kitap1 = new Kitap("Kuşların ve Yılanların Şarkısı","Suzanne Collins");
                Kitap kitap2 = new Kitap("İstanbul Hatırası","Ahmet Ümit");
                Kitap kitap3 = new Kitap("Martin Eden","Jack London");

                uye.KitapEkle(kitap1);
                uye.KitapEkle(kitap2);
                uye.KitapEkle(kitap3);

                kitap1.KitapBilgileriniGoster();
                kitap2.KitapBilgileriniGoster();
                kitap3.KitapBilgileriniGoster();
            }
        }
    }
}
