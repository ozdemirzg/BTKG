namespace BTK
{
    // Tanımlama
    public struct Ogrenci
    {
        //yapılandırıcı Metot- Constructor
        public Ogrenci(int numara, string adi,
            string soyadi, bool cinsiyet=true)             // burayı ctrl. ile alttaki taradığımız kısmı dönüştürerek yaptık sonradan.
                   //=true yu 4.öğrenci için yazdık.                // bu da bize üçüncü öğreciyi o şekilde yazmamızı sağladı.
        {
           //   Console.WriteLine("Otomatik olarak çalıştı");
            Numara = numara;
            Adi = adi;
            Soyadi = soyadi;
            Cinsiyet = cinsiyet;
        }

        public int Numara { get; set; }  //proporty (prop) -özellik
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }

        // Geçersiz kılmak/ Ezmek / Override 
        public override string ToString()     // bu temeli herbir öğrenci için ad soyad falan yazmamak için kurduk.
        {
            return $"{Numara,-5}" +
                $" {Adi,-10}" +
                $" {Soyadi,-10}" +
                string.Format("{0,5}", Cinsiyet == true ? "Bay" : "Bayan");
        }
    }
}
