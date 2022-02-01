using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTK
{
    public class OgretimElemani
    {
        // Prpperty-Özellik
        public int SicilNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }

        //DEfault ctor
        public OgretimElemani ()
	  {
        
	  }
        public override string ToString()
        {
            return $"{SicilNo,-5} " +
                $"{Adi,-10} " +
                $"{Soyadi,-10} " +
                string.Format("{0,-8}", Cinsiyet == true ? "Bay" :"Bayan");
        } 
        public OgretimElemani(int sicilno , string adi , string soyadi , bool cinsiyet)
        {
            SicilNo = sicilno;
            Adi =adi;
            Soyadi = soyadi;
            Cinsiyet = cinsiyet;
        }
      }
}
