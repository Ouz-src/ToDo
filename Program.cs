using System;
using System.Linq;

namespace ToDo
{
    public enum Buyukluk
    {
        XS, S, M, L, XL
    }
    public enum BoardTuru
    {
        TODO, INPROGRESS, DONE
    }

    public class Program : Kartlar
    {
        static void Main(string[] args)
        {
            kartlar.Add(new Kartlar() { id = 5, adSoyad = "Uğur Oğuzhan Karadeniz", baslik = "Server I/O Hata Teşhisi", icerik = "Server I/O hataları var ise düzeltilmesi ve serverin haftalık bakımı", buyukluk = Buyukluk.M, boardTuru = BoardTuru.INPROGRESS });
            kartlar.Add(new Kartlar() { id = 12, adSoyad = "Metehan Ürkmez", baslik = "Database temizliği", icerik = "Yeni anlaşmalı şirketten gelen Big Data'nın temizlenmesi", buyukluk = Buyukluk.XL, boardTuru = BoardTuru.DONE });
            kartlar.Add(new Kartlar() { id = 9, adSoyad = "Ayşe Tepe", baslik = "Yıllık zam", icerik = "Çalışanların yıllık zamlarının hesaplanması ve güncellenmesi", buyukluk = Buyukluk.S, boardTuru = BoardTuru.DONE });
            TakimUye();
            IslemTurleri islemTuru = new();
            islemTuru.AnaMenu();
        }
    }

    public class IslemTurleri : Kartlar
    {
        public void AnaMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz.\n******************************************");
            Console.WriteLine("(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    BoardListele();
                    break;
                case 2:
                    KartEkle();
                    break;
                case 3:
                    Console.Clear();
                    KartSil();
                    break;
                case 4:
                    Console.Clear();
                    KartTası();
                    break;
                default:
                    Console.WriteLine("1-4 aralığında tuşlamalısınız.");
                    Console.ReadKey();
                    Console.Clear();
                    AnaMenu();
                    break;
            }
        }
        public void KartEkle()
        {
            string yeniBaslik;
            string yeniIcerik;
            Buyukluk yeniBuyukluk;

            Console.Write("Başlık giriniz: ");
            yeniBaslik = Console.ReadLine();
            Console.Write("İçerik giriniz: ");
            yeniIcerik = Console.ReadLine();
            Console.WriteLine("Listeden ID'ye göre atama yapınız: ");
            foreach (var uye in takimUyeleri)
                Console.WriteLine("ID: {0}  ->  İsim - Soyisim: {1}", uye.Key, uye.Value);

            int input = int.Parse(Console.ReadLine());
            var atanacakKisi = kartlar.Find(x => x.id == input);
            if (kartlar.Any(x => x.id == input))
            {
                Console.Write("Büyüklük seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
                int input2 = int.Parse(Console.ReadLine());
                switch (input2)
                {
                    case 1:
                        yeniBuyukluk = Buyukluk.XS;
                        kartlar.Add(new Kartlar() { id = input, adSoyad = atanacakKisi.adSoyad, baslik = yeniBaslik, icerik = yeniIcerik, buyukluk = yeniBuyukluk });
                        Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 2:
                        yeniBuyukluk = Buyukluk.S;
                        kartlar.Add(new Kartlar() { id = input, adSoyad = atanacakKisi.adSoyad, baslik = yeniBaslik, icerik = yeniIcerik, buyukluk = yeniBuyukluk });
                        Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 3:
                        yeniBuyukluk = Buyukluk.M;
                        kartlar.Add(new Kartlar() { id = input, adSoyad = atanacakKisi.adSoyad, baslik = yeniBaslik, icerik = yeniIcerik, buyukluk = yeniBuyukluk });
                        Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 4:
                        yeniBuyukluk = Buyukluk.L;
                        kartlar.Add(new Kartlar() { id = input, adSoyad = atanacakKisi.adSoyad, baslik = yeniBaslik, icerik = yeniIcerik, buyukluk = yeniBuyukluk });
                        Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 5:
                        yeniBuyukluk = Buyukluk.XL;
                        kartlar.Add(new Kartlar() { id = input, adSoyad = atanacakKisi.adSoyad, baslik = yeniBaslik, icerik = yeniIcerik, buyukluk = yeniBuyukluk });
                        Console.WriteLine("Kayıt işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    default:
                        Console.WriteLine("1-5 aralığında tuşlamalısınız.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Tuşladığınız ID veritabanında bulunamadı.\nAna Menü'ye dönmek için bir tuşa basın.");
                Console.ReadKey();
                Console.Clear();
                AnaMenu();
            }
        }
        public void KartSil()
        {
            Console.WriteLine("Silmek istediğiniz kartın başlığını yazınız:");
            foreach (var item in kartlar)
                Console.WriteLine("-> " + item.baslik);
            string baslik = Console.ReadLine();
            if (kartlar.Any(x => x.baslik == baslik))
            {
                var obj = kartlar.Find(x => x.baslik == baslik);
                Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************");
                Console.WriteLine("Başlık: {0}", obj.baslik);
                Console.WriteLine("İçerik: {0}", obj.icerik);
                Console.WriteLine("Atanan Kişi: {0}", obj.adSoyad);
                Console.WriteLine("Büyüklük: {0}", obj.buyukluk);
                Console.WriteLine("-");
                Console.WriteLine("Silme işlemine devam etmek istiyor musunuz? (y/n)");
                string y_n = Console.ReadLine();
                if (y_n == "y")
                {
                    kartlar.Remove(obj);
                    Console.WriteLine("Silme işlemi başarılı!\nAna Menü'ye dönmek için bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                    AnaMenu();
                }
                else if (y_n == "n")
                {
                    Console.WriteLine("Silme işlemi iptal edildi!\nAna Menü'ye dönmek için bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                    AnaMenu();
                }
                else
                {
                    Console.WriteLine("Sadece y veya n tuşuna basmalısınız.\nAna Menü'ye dönmek için bir tuşa basın.");
                    Console.ReadKey();
                    Console.Clear();
                    AnaMenu();
                }
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 2:
                        Console.Clear();
                        KartSil();
                        break;
                    default:
                        Console.WriteLine("1 veya 2 yi tuşlamalısınız.");
                        Console.Clear();
                        AnaMenu();
                        break;
                }
            }
        }
        public void KartTası()
        {
            Console.WriteLine("Taşımak istediğiniz kartın başlığını yazınız:");
            foreach (var item in kartlar)
                Console.WriteLine("-> " + item.baslik);
            string baslik = Console.ReadLine();
            if (kartlar.Any(x => x.baslik == baslik))
            {
                var obj = kartlar.Find(x => x.baslik == baslik);
                Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************");
                Console.WriteLine("Başlık: {0}", obj.baslik);
                Console.WriteLine("İçerik: {0}", obj.icerik);
                Console.WriteLine("Atanan Kişi: {0}", obj.adSoyad);
                Console.WriteLine("Büyüklük: {0}", obj.buyukluk);
                Console.WriteLine("Line: {0}\n", obj.boardTuru);
                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz.\n(1) TODO\n(2) IN PROGRESS\n(3) DONE");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        obj.boardTuru = BoardTuru.TODO;
                        Console.WriteLine("Taşıma işlemi başarılı! Ana Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 2:
                        obj.boardTuru = BoardTuru.INPROGRESS;
                        Console.WriteLine("Taşıma işlemi başarılı! Ana Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 3:
                        obj.boardTuru = BoardTuru.DONE;
                        Console.WriteLine("Taşıma işlemi başarılı! Ana Menü'ye dönmek için bir tuşa basın.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                    default:
                        Console.WriteLine("1-3 aralığında tuşlamalısınız.");
                        Console.ReadKey();
                        Console.Clear();
                        AnaMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Taşımayı sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        AnaMenu();
                        break;
                    case 2:
                        Console.Clear();
                        KartSil();
                        break;
                    default:
                        Console.WriteLine("1 veya 2 yi tuşlamalısınız.");
                        Console.Clear();
                        AnaMenu();
                        break;
                }
            }
        }
        public void BoardListele()
        {
            Console.WriteLine("{0} Line\n************************", BoardTuru.TODO);
            if (kartlar.Any(x => x.boardTuru == BoardTuru.TODO))
            {
                foreach (var kart in kartlar)
                {
                    if (kart.boardTuru == BoardTuru.TODO)
                    {
                        Console.WriteLine("Başlık: {0}", kart.baslik);
                        Console.WriteLine("İçerik: {0}", kart.icerik);
                        Console.WriteLine("Atanan Kişi: {0}", kart.adSoyad);
                        Console.WriteLine("Büyüklük: {0}", kart.buyukluk);
                        Console.WriteLine("-");
                    }
                }
            }
            else
            {
                Console.WriteLine("~ BOŞ ~\n-");
            }
            Console.WriteLine("{0} Line\n************************", BoardTuru.INPROGRESS);
            if (kartlar.Any(x => x.boardTuru == BoardTuru.INPROGRESS))
            {
                foreach (var kart in kartlar)
                {
                    if (kart.boardTuru == BoardTuru.INPROGRESS)
                    {
                        Console.WriteLine("Başlık: {0}", kart.baslik);
                        Console.WriteLine("İçerik: {0}", kart.icerik);
                        Console.WriteLine("Atanan Kişi: {0}", kart.adSoyad);
                        Console.WriteLine("Büyüklük: {0}", kart.buyukluk);
                        Console.WriteLine("-");
                    }
                }
            }
            else
            {
                Console.WriteLine("~ BOŞ ~\n-");
            }
            Console.WriteLine("{0} Line\n************************", BoardTuru.DONE);
            if (kartlar.Any(x => x.boardTuru == BoardTuru.DONE))
            {
                foreach (var kart in kartlar)
                {
                    if (kart.boardTuru == BoardTuru.DONE)
                    {
                        Console.WriteLine("Başlık: {0}", kart.baslik);
                        Console.WriteLine("İçerik: {0}", kart.icerik);
                        Console.WriteLine("Atanan Kişi: {0}", kart.adSoyad);
                        Console.WriteLine("Büyüklük: {0}", kart.buyukluk);
                        Console.WriteLine("-");
                    }
                }
            }
            else
            {
                Console.WriteLine("~ BOŞ ~\n-");
            }
            Console.WriteLine("Ana Menü'ye dönmek için bir tuşa basın.");
            Console.ReadKey();
            Console.Clear();
            AnaMenu();
        }
    }
}