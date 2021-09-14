using OptimizasyonAlgoritmaları.Arayuzler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OptimizasyonAlgoritmaları.ParcacikSuruAlgoritması;

namespace OptimizasyonAlgoritmaları.Modeller
{
    class Parcacik : ParametreDegeri
    {
        internal ParametreDegeri pBest { private set; get; }
        private double[] parcacikHizlari;

        internal Parcacik(double[] degiskenler, int hassasiyet) : base(degiskenler, hassasiyet)
        {
            parcacikHizlari = new double[degiskenler.Length];
            pBest = new ParametreDegeri(this);
        }

        internal void HizlariGuncelle(Parametre gBest, Random rastgele)
        {
            for (int i = 0; i < parcacikHizlari.Length; i++)
                parcacikHizlari[i] =
                    (W * parcacikHizlari[i]) +
                    Convert.ToSingle(
                        (C1 * rastgele.NextDouble() * (pBest.degiskeniAl(i) - degiskeniAl(i))) +
                        (C2 * rastgele.NextDouble() * (gBest.degiskeniAl(i) - degiskeniAl(i)))
                        );
        }

        internal void KonumuGuncelle(IAmacFonksiyonu amacFonksiyonu)
        {
            for (int i = 0; i < parcacikHizlari.Length; i++)
            {
                double yeniKonum = degiskeniAl(i) + parcacikHizlari[i];
                yeniKonum = Math.Max(Math.Min(yeniKonum, amacFonksiyonu.ustSinir(i)), amacFonksiyonu.altSinir(i));
                degiskeniGuncelle(i, yeniKonum);
            }
        }

        internal void YeniPBest()
        {
            pBest.DegeriKopyala(this);
        }
    }
}
