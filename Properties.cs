using System;

namespace ToDo
{
    public interface IKart
    {
        int id { get; set; }
        string adSoyad { get; set; }
        string baslik { get; set; }
        string icerik { get; set; }
        Buyukluk buyukluk { get; set; }
        BoardTuru boardTuru { get; set; }
    }

    public class Kartlar : IKart
    {
        public static List<IKart> kartlar = new List<IKart>();
        public static Dictionary<int, string> takimUyeleri = new Dictionary<int, string>();
        public int id { get; set; }
        public string adSoyad { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public Buyukluk buyukluk { get; set; }
        public BoardTuru boardTuru { get; set; }

        public static void TakimUye() {
            foreach (var item in kartlar)
            {
                takimUyeleri.Add(item.id, item.adSoyad); 
            }
        }
    }
}