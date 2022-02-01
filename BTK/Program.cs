using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTK
{  /*
    * BUKISIM IComparable İÇİN YAZILDI.
     // class tanımı yaptık.
     public class Sehir : IComparable<Sehir>  // : dan sonrasını sehirleri sıralı yazdırırken sort ta oluşan sorunu gidermek için ekledik.
                                                   // daha sonra da implemant ettik.
     {
        // prop tab ile özellik tanımladık iki tane.daha sonra bunları tarayıp crtl. ile generate constructor yaptı ve
        //bana yeni Sehir claa açtı. public Sehir(int plakaNo, string sehirAdi diye.iki propun altında hemen tanımlama.
        public int PlakaNo { get; set; }
        public string SehirAdi { get; set; }

        public Sehir(int plakaNo, string sehirAdi)
        {
            PlakaNo = plakaNo;
            SehirAdi = sehirAdi;
        }

        //bunu Sehir Listesini yazdırabilmek için over ride ile yaptık.orada sadece to String i seçtik.
        public override string ToString()
        {
            return $"{PlakaNo, -5} {"-",-5} {SehirAdi,-5}";
        }

        //IComparable ı Implemant edince burası çıktı.buarada if else leri yazınca altta sehirleri sıralı listemeyi sağladık.sort çalıştı yani.
        public int CompareTo(Sehir other)
        {
            if (this.PlakaNo<other.PlakaNo)
            {
                return -1;
            }
            else if (this.PlakaNo==other.PlakaNo)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
    */

    public class Program
    {

        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        private static void IComparable()
        {
            //List
            var sayilar = new List<int>() { 53, 40, 14, 27, 2, 3, 12 };
            sayilar.ForEach(s => Console.WriteLine(s));  //sayıları foreach yapmadan s ile direkt tazdırdı.
            sayilar.Sort();  // sayıları sıralı yazdırdı.

            //Sehir Listesi
            var sehirler = new List<Sehir>()  // buraya <Sehir> yazdığımızda tanımasını başa yazdığımız sayesinde sağladık.
            {
                new Sehir(6,"Ankara"),
                new Sehir(34,"İstanbul"),
                new Sehir(55,"Samsun"),
                new Sehir(23,"Elazığ"),
                new Sehir(44,"Malatya"),
            };
            sehirler.Add(new Sehir(1, "Adana"));  // sonradan eklesekte sıralamaya katıldı.

            sehirler.Sort();   // sıralı yazsın diye yazdık.
            sehirler.ForEach(s => Console.WriteLine(s));
        }

        private static void SortedList_Uygulaması()
        {
            //SortedList
            var kitapIcerigi = new SortedList();
            kitapIcerigi.Add(1, "Önsöz");
            kitapIcerigi.Add(50, "Değişkenler");
            kitapIcerigi.Add(40, "Operatörler");
            kitapIcerigi.Add(60, "Döngüler");
            kitapIcerigi.Add(45, "ilişkisel Operatörler");

            Console.WriteLine("İÇİNDEKİLER: ");
            Console.WriteLine(new String('-', 25));
            Console.WriteLine($"{"Konular",-35} {"Sayfalar",5}");
            foreach (DictionaryEntry item in kitapIcerigi)
            {
                Console.WriteLine($"{item.Value,-35} {item.Key,5}");
            }
        }

        private static void Sortelist_Temelleri()
        {
            //SortedList -Temeller
            //Tanımlama
            var list = new SortedList()
            {
                {1, "Bir" },    //HashTable dan farklı olarak bunu çalıştırdığımızda sıralı verir.
                {2, "İki" },
                {3, "Üç" },
                {8, "Sekiz" },
                {5, "Beş" },
                {6, "Altı" },
            };

            list.Add(4, "Dört");

            ////  list.Add(1, "Bir");       böyle tek tek tanımlayabiliriz.Ama bir üstteki yol daha kısa
            ////  list.Add(2, "İki");
            ///
            //Dolaşma
            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("Listedeki eleman sayısı  :{0} ", list.Count);
            Console.WriteLine("Listenin kapasitesi      :{0} ", list.Capacity);
            list.TrimToSize();
            Console.WriteLine("Listenin kapasitesi      :{0} ", list.Capacity);

            //Erişim
            //Key'e bağlı olarak 4 e karşılık geleni getirdi.
            Console.WriteLine(list[4]);

            //index'e bağlı olarak getirmek için ise sıfırıncı index te 1 ifadesi var.onu getirir.
            Console.WriteLine(list.GetByIndex(0));

            //Get-> key ile  yazdırırız.
            Console.WriteLine(list.GetKey(0));

            //Lista sonundaki elemamnın değerini bulmak için (index değeri)
            Console.WriteLine(list.GetByIndex(list.Count - 1));

            var anahtarlar = list.Keys;
            Console.WriteLine("\nANAHTARLAR");
            foreach (var item in anahtarlar) //anahtarları alabilmek için foreach yazdık.
            {
                Console.WriteLine(item);
            }

            var degerler = list.Values;
            Console.WriteLine("\nDEĞERLER");
            foreach (var item in degerler)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nGÜNCELLEME");
            if (list.ContainsKey(1))   //senin 1'e karşılık gelen bir anahtarın var mı?
            {
                list[1] = "One";  // 1 olan elemanı one diye yazdırdık.
            }
            //Dolaşma   tekrar dolaşma ile bunu yazdırırız.
            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private static void HashTableUygulaması()
        {
            //HashTable Uygulaması//

            //Başlığı okuma
            Console.WriteLine("Başlığı Giriniz: ");
            string baslık = Console.ReadLine();

            //kucultme
            baslık = baslık.ToLower();

            //HashTable
            var karakterSeti = new Hashtable()
            {
                {'ç','c'},     //ç gördüğünde c yap demek.küçültem yapmaya gerek yok.bir üstte yaptık çünkü.
                {'ı','i'},     //birde aynı şeyi iki kere yazarsan çakıştırdığında hata verir. ç yi iki re girme mesela
                {'ö','o'},
                {'ü','u'},
                {' ','-'},
                {'\'','-'},
                {'ğ','g'},
                {'.','-'},
                {'?','-'},

            };

            // DÖngü ile harflerin kontrolünü sağladık.
            foreach (DictionaryEntry item in karakterSeti)
            {
                baslık = baslık.Replace((char)item.Key, (char)item.Value);   //Replace char char istediği için objectleri car yaptı.
            }

            Console.WriteLine(baslık);
        }

        private static void HashTable_Temelleri()
        {
            //HASHTABLE
            //Tanımlama
            var sehirler = new Hashtable();

            //Ekleme
            sehirler.Add(6, "Ankara");
            sehirler.Add(34, "Istanbul");
            sehirler.Add(55, "Samsun");
            sehirler.Add(23, "Elazığ");

            //Dolaşma
            foreach (DictionaryEntry item in sehirler)
            {
                Console.WriteLine($"{item.Key,-5}" +
                    $"- {item.Value,-20}");
            }
            //Anahtarları alma sadece

            Console.WriteLine("\nanahtarlar (Keys)");  //  '\n' bir satır boşluk bıraktırıyor.
            var anahtarlar = sehirler.Keys;

            foreach (var item in anahtarlar)
            {
                Console.WriteLine(item);
            }
            //Değerler
            Console.WriteLine("\nDeğerler (Value)");
            ICollection degerler = sehirler.Values;
            foreach (var item in degerler)
            {
                Console.WriteLine(item);
            }

            //Elemana Erişme
            Console.WriteLine("\nElemana erişme");
            Console.WriteLine(sehirler[55]);

            //Eleman silme
            Console.WriteLine("\nEleman silme");
            sehirler.Remove(23);

            //silme işlemini görmemiz için bu dolaşımı tekrar yazdık.
            //Dolaşma
            foreach (DictionaryEntry item in sehirler)
            {
                Console.WriteLine($"{item.Key,-5}" +
                    $"- {item.Value,-20}");
            }
        }

        private static void arrayClassMetotları()
        {
            // Array-Dizi-Tanımlama 3farklı yolla yaptık bunu burada
            int[] sayilar = new int[] { 5, 3, 8, 10, 2, 18, 23, 44, 55, 6, 34, 19 };
            var numbers = Array.CreateInstance(typeof(int), sayilar.Length);
            var arr = new ArrayList(sayilar);

            /* for (int i = 0; i < sayilar.Length; i++)    //hepsine sıfır çıktısı numbers için sayıları bu yolla atadık.
               {
                   numbers.SetValue(sayilar[i], i); 
               } 
              bunun yerineikinci yol olarak copyTo ile yaptı.
              */
            sayilar.CopyTo(numbers, 0);  //sayıları nubers a atamanın 2.yolu
            Array.Sort(sayilar);  // sayiları sıralı hale getirmek için ArrAY KULLANIDIK.DZİZİLERDE ARRAY.
            Array.Sort(numbers);  //bunu çalıştırınca numaralar sıfır olarak çıkar.for döngüsü setvalue ile yapabiliriz .
            arr.Sort();       //bununla arr listesini sayı sırasına göre yazdırdı.Diğer ikisinde (dizilerde)sort çalışmadı.
            Array.Clear(sayilar, 2, 2); // ikiden başla 3 taneyi sıfırla demek.

            Console.WriteLine(Array.IndexOf(sayilar, 100)); // 100 sayısı olmadığı için -1 çıktısını verir.
            /*
            var x = Array.IndexOf(sayilar, 44); 
            Console.WriteLine(x);
            bunu kısaca içine yazarak yaptı sonra.ayrıca bu yöntem ile aranan sayınnın kaçıncı sırada olduğunu yazıyor bize.burada başta 10 dedi.
            */

            //Dolaşma
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"sayilar[{i}] = " +
                   $"{sayilar[i],3}  -  " +
                   $"numbers[{i}] = " +
                   $"{numbers.GetValue(i),3} - " +
                   $"arr[{i}] = " +
                   $"{arr[i],3}");
            }
        }


        private static void arrayAlternatifArrayOluşturma()
        {
            // Array-Dizi
            int[] sayilar = new int[] { 5, 3, 8, 10, 2 };
            var numbers = Array.CreateInstance(typeof(int), 5);  //tür ve boyutu yazdık.parantezde.
            //dizi içindeki değerlere ulaşmak için
            numbers.SetValue(-5, 0);
            numbers.SetValue(3, 1);
            numbers.SetValue(8, 2);
            numbers.SetValue(10, 3);
            numbers.SetValue(-2, 4);

            //Dolaşma
            for (int i = 0; i < numbers.Length; i++)
            {
                // birinci yol
                //  //[{0}] bu i yi temsil ediyor
                //  Console.WriteLine("Sayilar[{0}] ={1} - numbers[{0}] = {2}",
                //      i, // sıfırın etkili olduğu yerleri dolduracak.
                //      sayilar[i], // {1} için karşılık gelecek
                //      numbers.GetValue(i)); //{2} için karşılık gelecek
                //ikinci yol

                Console.WriteLine($"sayilar[{i}] = " +
                    $"{sayilar[i],3}  -  " +
                    $"numbers[{i}] = " +
                    $"{numbers.GetValue(i),3}");
            }
        }

        //// {

        // // OgretimElemani ogrGor = new OgretimElemani (103,"Ahmet", "Yalçın", true);   // parantezin yanındaki ; alttaki süslü parantezin yanına geldi.
        /*
            {                                     (    2.yol)
               SicilNo =102,
               Adi = "Ahmet",
               Soyadi = "Yalçın",
               Cinsiyet = true  
            };
        */


        //Bu altta yazdığımıız dört satır işi uzattığı için kaldırdık.üstte süslü parantes içinde kısaca yazdık.
        //Atama                                       (1.yol)
        //ogrGor.SicilNo = 101;
        // ogrGor.Adi = "Ahmet";
        // ogrGor.Soyadi = "Yalçın";
        //ogrGor.Cinsiyet = true;

        // // Console.WriteLine(ogrGor);
        // // Console.ReadKey();
        ////  }

        private static void struct1()
        {
            ////Struct-kullanma
            //Ogrenci ogr = new Ogrenci();
            //ogr.Numara = 10;
            //ogr.Adi = "Ahmet";
            //ogr.Soyadi = "Yılmaz";
            //ogr.Cinsiyet = true;

            ////Alternatif kullanma 2
            //var ogr2 = new Ogrenci()
            //{
            //    Numara = 20,
            //    Adi = "Fatma",
            //    Soyadi = "Dag",
            //    Cinsiyet = false
            //};
            ////Alternatif Kullanma 3
            //var ogr3 = new Ogrenci(30, "Mehmet", "Avşar", true);
            //var ogr4 = new Ogrenci(40, "Asaf", "Karlıdağ");



            //Console.WriteLine($"{ogr.Numara}  " +
            //    $"{ogr.Adi}  {ogr.Soyadi}  " +
            //    $"{ogr.Cinsiyet}  ");

            //Console.WriteLine($"{ogr2.Numara}  " +
            //     $"{ogr2.Adi}  {ogr2.Soyadi}  " +
            //     $"{ogr2.Cinsiyet}  ");

            //Console.WriteLine($"{ogr3.Numara}  " +
            //     $"{ogr3.Adi}  {ogr3.Soyadi}  " +
            //     $"{ogr3.Cinsiyet}  ");

            //Console.WriteLine($"{ogr4.Numara}  " +
            //    $"{ogr4.Adi}  {ogr4.Soyadi}  " +
            //    $"{ogr4.Cinsiyet}  ");

            ////Üstteki gibi tek tek yazmak yerine ;

            //Console.WriteLine(ogr);
            //Console.WriteLine(ogr2);
            //Console.WriteLine(ogr3);
            //Console.WriteLine(ogr4);

            ////Bir üstteki dörtlüyü tek tek yazmak yerine;

            var OgrenciListesi = new List<Ogrenci>()
            {
                new Ogrenci(10, "Ahmet", "Yılmaz"),
                new Ogrenci(20, "Fatma", "Dağ", false),
                new Ogrenci(30, "Mehmet", "Avşar", true),
                new Ogrenci(40, "Asaf", "Karlıdağ")

            };
            //foreach (Ogrenci o in OgrenciListesi)
            //{
            //    Console.WriteLine(o);
            //}

            ////üsttekinin yerine ;

            OgrenciListesi.ForEach(o => Console.WriteLine(o));
        }

        private static void VeriTürlerininAltVeÜstLimitleri()
        {
            // 8 -bit integer

            Console.WriteLine(nameof(SByte));           // ilgili veri yapısının ismini verir=nameof biz sbyte dedik.
            Console.WriteLine($"Alt limit       :   {SByte.MinValue}");
            Console.WriteLine($"Üst limit       :   {SByte.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(SByte)}");
            Console.WriteLine();
            Console.ReadKey();

            // Unsigned 8-bit integar
            Console.WriteLine(nameof(Byte));
            Console.WriteLine($"Alt limit       :   {Byte.MinValue}");
            Console.WriteLine($"Üst limit       :   {Byte.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(Byte)}");
            Console.WriteLine();
            Console.ReadKey();

            // Signed 16-bit integar
            Console.WriteLine(nameof(Int16));
            Console.WriteLine($"Alt limit       :   {Int16.MinValue}");
            Console.WriteLine($"Üst limit       :   {Int16.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(Int16)}");
            Console.WriteLine();
            Console.ReadKey();

            // Unsigned 16-bit integar
            Console.WriteLine(nameof(UInt16));
            Console.WriteLine($"Alt limit       :   {UInt16.MinValue}");
            Console.WriteLine($"Üst limit       :   {UInt16.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(UInt16)}");
            Console.WriteLine();
            Console.ReadKey();

            // Signed 32-bit integar
            Console.WriteLine(nameof(Int32));
            Console.WriteLine($"Alt limit       :   {Int32.MinValue}");
            Console.WriteLine($"Üst limit       :   {Int32.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(Int32)}");
            Console.WriteLine();
            Console.ReadKey();

            // Double
            Console.WriteLine(nameof(Double));
            Console.WriteLine($"Alt limit       :   {Double.MinValue}");
            Console.WriteLine($"Üst limit       :   {Double.MaxValue}");
            Console.WriteLine($"Boyut           :   {sizeof(Double)}");
            Console.WriteLine();
            Console.ReadKey();
        }
        private static void Listeuygulamsı()
        {
            var sehirler = new List<string>()
            {
                "Ankara",
                "İstanbul",
                "Van",
                "Samsun",
                "Ordu"
            };

            //foreach (string s in sehirler)
            //{                                         //bu kısım yerine lambda daki kısmı yazdı tek satırda
            //    Console.WriteLine(s);
            //}


            // Lambda expression

            sehirler.ForEach(s => Console.WriteLine(s));

            Console.WriteLine(new string('-', 50));

            var iller = sehirler;
            iller.ForEach(i => Console.WriteLine(i));

            sehirler.Add("Sinop");
            Console.WriteLine();
            sehirler.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();
            iller.ForEach(i => Console.WriteLine(i));

            iller.Remove("Ankara");
            iller.ForEach(i => Console.WriteLine(i));
            sehirler.ForEach(s => Console.WriteLine(s));
        }
        private static void değervereferans()
        {
            int x = 10;
            int y = 20;
            Console.WriteLine("{0},{1}", x, y);
            Degistir(ref x, ref y);     //ref ekleyerek sayıların değere göre değil referansa göre çalıltırdı.
            Console.WriteLine("{0},{1}", x, y);
        }
        private static void Degistir(ref int x,ref int y)
        {
            int gecici = x;
            x = y;
            y = gecici;
            Console.WriteLine("{0},{1}",x,y );
        }
        private static void metotyapısısonuncu()
        {
            var odenecekMiktar = SatisYap(100);
            Console.WriteLine("{0,5:0.##}", odenecekMiktar);

            var odenecekMiktar2 = SatisYap(100, .1);
            Console.WriteLine("{0,5:0.##}", odenecekMiktar2);
        }
        /// <summary>
        /// Satiş yapan fonksiyon.
        /// </summary>
        /// <param name="miktar">Alış-Veriş tutarı</param>
        /// <returns>KDV eklenmiş toplam ödenecek tutar</returns>
        static double SatisYap(double miktar)
        {
            return miktar * 1.18;
        }
        /// <summary>
        /// Satiş yapan fonksiyon.
        /// </summary>
        /// <param name="miktar">Alış-Veriş tutarı</param>
        /// <param name="indirim">İndirim Oranı</param>
        /// <returns>KDV eklenmiş toplam ödenecek tutar</returns>
        static double SatisYap(double miktar, double indirim)
        {
            return (miktar * (1.0 - indirim) * 1.18);
        }
        private static void metotTasarimi()
        {
            /*
            int buyuk = Karsilastir(3, 5);
            Console.WriteLine(buyuk);
            */

            //var x = KareAL(3);
            //double y = KareAL(x);
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            double toplam = SeriToplami(5.3, 3, 7, 15, 0);  //bunu direkt bir alt satırda toplam yerine taşıyarak SeriToplami(5,3..); yazab

            Console.WriteLine("{0,5:0.##}", toplam);
        }
        private static double SeriToplami(params double[] seri)       //(double v1, int v2, int v3, int v4, int v5)dinamik olsun diye bunun yerine param yazdı.
        {
            double toplam = 0;
            foreach (double s in seri)
            {
                toplam += s;
            }
            return toplam;
        }

        public static int Karsilastir(int A, int B)
        {
            //if (A>B)                      // A veya B den büyük oanı yazdırdı bu grup ile.
            //{
            //    return A;
            //}
            //else
            //{
            //    return B;
            //}
            return A > B ? A : B;           // bir üsttekini kısadan yaptı bu satır ile.
        }
        static double KareAL(double sayi)
        {
          double kare = sayi * sayi;
          return kare;
        }
        private static void listeler()
        {
            //Tanımlama
            var sayilar = new List<int>();    //List<int> bunu var yerine yazabilirdin.
            int x = 55;
            int[] Seri = new int[] { 70, 80, 90 };

            //Ekleme
            sayilar.Add(10);
            sayilar.Add(15);
            sayilar.Add(20);
            sayilar.Add(x);
            sayilar.AddRange(Seri);
            sayilar.AddRange(new int[] { 40, 50, 60 });      // seri linin daha da kısaltılmış hal
            //Araya ekleme
            sayilar.Insert(3, 0);  // 3.indise sıfır değeri geldi.
            sayilar.InsertRange(4, new int[] { 13, 27 });

            sayilar.RemoveAt(4);  // 4.eleman olan sıfırı atar
            sayilar.RemoveAt(sayilar.IndexOf(55));

            ////foreach (var item in Seri)
            ////{                                      //bunun yerine sayilar.AddRange ile ekledi üstte kısaca 'Seri'yi
            ////    sayilar.Add(item);
            ////}

            //Dolaşım
            foreach (int s in sayilar)
            {
                Console.Write($"{s,-5}");
            }
        }
        private static void Arryalist()
        {
            // Tanımlama 
            var arrayList = new ArrayList()
            {10, "BTK Akademi" , true, 'e'

            };

            //Ekleme (burayı sonradan üste kısaca yazdı)
            /*
            arrayList.Add(10);
            arrayList.Add("BTK Akademi");
            arrayList.Add(true);
            arrayList.Add('e');
            */

            // Dolaşım
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }

            int[] sayilar = new int[] { 23, 44, 55 };
            arrayList.AddRange(sayilar);

            // Dolaşım
            Console.WriteLine();     // bunu eklediğinde ikinci turu bir alt satıra yazdı.
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();    // 23 ün en alt satırda yazmasını sağladı.

            // Elemana erişme
            Console.WriteLine(arrayList[4]);

            // elemana erişme- atama

            int x = (int)arrayList[0];      //var x = arrayList[0]; bunu var bırakırsan altta x+10 hata verirdi
            Console.WriteLine(x + 10);

            //Eleman silme
            // arrayList.Remove(10);
            //arrayList.RemoveAt(1);     // yeni durumdaki 1. elemanı atar.
            arrayList.RemoveRange(3, 3);  //3.indisten başlayıp üç elemamnı siler.
            // Dolaşım
            Console.WriteLine();     // bunu eklediğinde ikinci turu bir alt satıra yazdı.
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }
        }
        private static void çboyutludiziler2()
        {
            double[,] matris = new double[,]
                        {
                { 1, 2, 3 },
                { 2, 3, 4 },
                { 3, 4, 5},
                { 4, 5, 6 }
                        };
            double toplam = 0;

            for (int i = 0; i < matris.GetLength(0); i++) //satır
            {
                for (int j = 0; j < matris.GetLength(1); j++)  //sütun
                {
                    if (i == j)
                        matris[i, j] = -1;

                    if (matris[i, j] % 2 == 0)
                        matris[i, j] = 0;

                    toplam += matris[i, j];

                    Console.Write($"{matris[i, j],5}");
                }

                Console.WriteLine();         // alt alta yazdırdı grupları
            }
            Console.WriteLine($"Toplam: {toplam}");
        }
        private static void çboyutludiziler()
        {
            Console.WriteLine("Dizi boyutunu giriniz: ");
            int boyut = Convert.ToInt32(Console.ReadLine());
            int[] sayilar = new int[boyut];

            var r = new Random();

            for (int i = 0; i < sayilar.Length; i++)
                sayilar[i] = r.Next(1, 10);

            foreach (var s in sayilar)
            {
                Console.WriteLine($"{s,5} {s * s,5}");
            }
        }
    }
}
