using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Text;
using Yapay_Zeka.Arayuzler;

namespace Yapay_Zeka.Modeller
{
    internal class Fonksiyonlar
    {

        internal class F1 : IFonksiyon
        {

            public double altSinir(int degiskenIndex) => -2D;

            public string AltSinir() => "-2";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak) 
                => Math.Abs(kiyaslanan.degeri()) < Math.Abs(kiyaslanacak.degeri());

            public double fonksiyonDegeri(Parametre deger)
            {
                double x = deger.degiskeniAl(0);
                return Math.Pow(Math.E, x) * Math.Sin(x);
            }

            public int fonksiyonDegiskenSayisi() => 1;

            public double ustSinir(int degiskenIndex) => 3D;

            public string UstSinir() => "3";

        }

        internal class F2 : IFonksiyon
        {

            public double altSinir(int degiskenIndex) => 1D;

            public string AltSinir() => "1";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak)
                => Math.Abs(kiyaslanan.degeri()) < Math.Abs(kiyaslanacak.degeri());

            public double fonksiyonDegeri(Parametre deger)
            {
                double x = deger.degiskeniAl(0);
                return 150 * Math.Pow(Math.E, x * -1 / 2) * (Math.Cos(x) - Math.Sin(x));
            }

            public int fonksiyonDegiskenSayisi() => 1;

            public double ustSinir(int degiskenIndex) => 6D;

            public string UstSinir() => "6";

        }

        internal class F3 : IFonksiyon
        {

            public double altSinir(int degiskenIndex) => -10D;

            public string AltSinir() => "-10";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak)
                => Math.Abs(kiyaslanan.degeri()) < Math.Abs(kiyaslanacak.degeri());

            public double fonksiyonDegeri(Parametre deger)
            {
                double x = deger.degiskeniAl(0);
                return (Math.Pow(Math.E, x) - Math.Pow(Math.E, x * -1)) / (Math.Pow(Math.E, x) + Math.Pow(Math.E, x * -1));
            }

            public int fonksiyonDegiskenSayisi() => 1;

            public double ustSinir(int degiskenIndex) => 10D;

            public string UstSinir() => "10";

        }

        internal class F4 : IFonksiyon
        {

            public double altSinir(int degiskenIndex) => 2D;

            public string AltSinir() => "2";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak)
                => Math.Abs(kiyaslanan.degeri()) < Math.Abs(kiyaslanacak.degeri());

            public double fonksiyonDegeri(Parametre deger)
            {
                double x = deger.degiskeniAl(0);
                return Math.Log(x - 1) + Math.Sin(x - 3);
            }

            public int fonksiyonDegiskenSayisi() => 1;

            public double ustSinir(int degiskenIndex) => 15D;

            public string UstSinir() => "15";

        }

        internal class F5 : IFonksiyon
        {

            public double altSinir(int degiskenIndex) => -1.5D;

            public string AltSinir() => "-1.5";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak)
                => Math.Abs(kiyaslanan.degeri()) < Math.Abs(kiyaslanacak.degeri());

            public double fonksiyonDegeri(Parametre deger)
            {
                double x = deger.degiskeniAl(0);
                return -1 * x * x * ((x * x) - 4) * (x - 5);
            }

            public int fonksiyonDegiskenSayisi() => 1;

            public double ustSinir(int degiskenIndex) => 1D;

            public string UstSinir() => "1";

        }

        internal class F6 : IFonksiyon
        {
            public double altSinir(int degiskenIndex)
            {
                if (degiskenIndex == 0)
                    return -3D;
                else
                    return -2D;
            }

            public string AltSinir() => "-3, -2";

            public bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak)
                => kiyaslanan.degeri() < kiyaslanacak.degeri();

            public double fonksiyonDegeri(Parametre deger)
            {
                double degisken1 = deger.degiskeniAl(0), degisken2 = deger.degiskeniAl(1);
                return ((4 - (2.1F * degisken1 * degisken1) + (Math.Pow(degisken1, 4) / 3)) * degisken1 * degisken1) +
                    (degisken1 * degisken2) +
                    ((-4 + (4 * degisken2 * degisken2)) * degisken2 * degisken2);
            }

            public int fonksiyonDegiskenSayisi()
            {
                return 2;
            }

            public double ustSinir(int degiskenIndex)
            {
                if (degiskenIndex == 0)
                    return 3D;
                else
                    return 2D;
            }

            public string UstSinir() => "3, 2";
        }

    }
}
