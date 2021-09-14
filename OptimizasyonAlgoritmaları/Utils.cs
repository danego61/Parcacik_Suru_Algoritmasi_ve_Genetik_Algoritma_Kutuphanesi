using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları
{

    internal static class GAUtils
    {

        internal static bool[] GenOlustur(int genUzunlugu, Random rastgele)
        {
            var gen = new bool[genUzunlugu];

            for (int i = 0; i < genUzunlugu; i++)
            {
                var sayi = rastgele.NextDouble();
                gen[i] = sayi > 0.5D ? true : false;
            }

            return gen;
        }

        internal static Gen TurnuvaSecimi(Gen[] populasyon, int kacTane, IAmacFonksiyonu amacFonksiyonu, Random rastgele)
        {
            Gen enIyi = null;

            for (int i = 0; i < kacTane; i++)
            {
                int index = rastgele.Next(populasyon.Length);
                Gen gen = populasyon[index];
                if (enIyi == null || amacFonksiyonu.degerKiyasla(gen, enIyi))
                    enIyi = gen;
            }

            return enIyi;
        }

        internal static int GenUzunlukHesapla(double minDeger, double maksimumDeger, double hassasiyet)
        {
            double formul = ((maksimumDeger - minDeger) / hassasiyet * 100) + 1;
            int deger = 1;
            for (int i = 1; i < 30; i++)
            {
                if (deger >= formul)
                    return i;
                deger *= 2;
            }

            throw new Exception("Gen uzunluğu hesaplanırken hata oluştu!");
        }

        internal static int GenDegeriHesapla(ArraySegment<bool> gen)
        {
            int deger = 0;
            int carp = 1;

            foreach (bool bit in gen)
            {
                int bitDegeri = bit ? carp : 0;
                deger += bitDegeri;
                carp *= 2;
            }

            return deger;
        }

        internal static double GeninGercekDegeri(ArraySegment<bool> gen, double altSinir, double ustSinir)
        {
            int deger = GenDegeriHesapla(gen);
            double formul = (ustSinir - altSinir) / (Math.Pow(2, gen.Count) - 1) * deger;
            return altSinir + formul;
        }

    }

}
