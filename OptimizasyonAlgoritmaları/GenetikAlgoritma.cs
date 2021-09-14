using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları
{
    public class GenetikAlgoritma : OptimizasyonAlgoritması
    {
        internal static double MutasyonOrani, CaprazlamaOrani;
        private ParametreDegeri EnIyıGen;
        private Gen[] Populasyon = null;
        private int[] genBuyuklukleri;
        private int Genbuyuklugu;

        public GenetikAlgoritma(IAlgoritmaDurumu algoritmaDurumu) : base(algoritmaDurumu)
        {

        }

        public void Hesapla(
            IAmacFonksiyonu amacFonksiyonu,
            int hassasiyet,
            int populasyonBuyuklugu,
            int iterasyonSayisi,
            double mutasyonOrani,
            double caprazlamaOrani
            ) => Task.Factory.StartNew(() =>
            {
                MutasyonOrani = mutasyonOrani;
                CaprazlamaOrani = caprazlamaOrani;
                HesaplamaBasladi(amacFonksiyonu, iterasyonSayisi);
                Populasyon = BaslangicPopulasyonu(populasyonBuyuklugu, hassasiyet, amacFonksiyonu);

                for (int i = 0; i < iterasyonSayisi; i++)
                {
                    var best = AdimIsle(amacFonksiyonu);
                    DonguSonucu(i, best);
                }

                HesaplamaBitti(EnIyıGen);
                Populasyon = null;
                genBuyuklukleri = null;
                EnIyıGen = null;
            });

        private ParametreDegeri AdimIsle(IAmacFonksiyonu amacFonksiyonu)
        {
            ParametreDegeri best = EnIyiHesapla(amacFonksiyonu);

            TurnuvaSeciminiUygula(amacFonksiyonu);
            CaprazlamaIsleminiUygula();

            Parallel.ForEach(Populasyon, gen =>
            {
                for (int i = 0; i < Genbuyuklugu; i++)
                {
                    double sayi = rastgele.NextDouble();
                    if (sayi < MutasyonOrani)
                        gen.MutasyonUygula(i);
                }

                AmacFonksiyonunuHesapla(gen, amacFonksiyonu);
            });

            //foreach (var gen in Populasyon)
            //{
            //    for (int i = 0; i < Genbuyuklugu; i++)
            //    {
            //        double sayi = rastgele.NextDouble();
            //        if (sayi < MutasyonOrani)
            //            gen.MutasyonUygula(i);
            //    }

            //    AmacFonksiyonunuHesapla(gen, amacFonksiyonu);
            //}

            return best;
        }

        private void CaprazlamaIsleminiUygula()
        {
            List<Gen> caprazlamaListesi = new List<Gen>();

            for (int i = 0; i < Populasyon.Length; i++)
            {
                if(rastgele.NextDouble() < CaprazlamaOrani)
                {
                    int index = rastgele.Next(0, caprazlamaListesi.Count + 1);
                    caprazlamaListesi.Insert(index, Populasyon[i]);
                }
            }

            for (int i = 0; (caprazlamaListesi.Count - i) > 1; i += 2)
            {
                caprazlamaListesi[i].GeniCaprazla(caprazlamaListesi[i + 1], rastgele.Next(0, Genbuyuklugu));
            }
        }

        private void TurnuvaSeciminiUygula(IAmacFonksiyonu amacFonksiyonu)
        {
            bool[][] yeniPopulasyon = new bool[Populasyon.Length][];
            int kacTane = Math.Max(Populasyon.Length / 10, 2);

            Parallel.For(0, Populasyon.Length, index =>
            {
                Gen secilen = GAUtils.TurnuvaSecimi(Populasyon, kacTane, amacFonksiyonu, rastgele);
                bool[] genDegeri = new bool[Genbuyuklugu];
                Array.Copy(secilen.GenAl, genDegeri, Genbuyuklugu);
                yeniPopulasyon[index] = genDegeri;
            });

            //for (int i = 0; i < Populasyon.Length; i++)
            //{
            //    Gen secilen = GAUtils.TurnuvaSecimi(Populasyon, kacTane, amacFonksiyonu, rastgele);
            //    bool[] genDegeri = new bool[Genbuyuklugu];
            //    Array.Copy(secilen.GenAl, genDegeri, Genbuyuklugu);
            //    yeniPopulasyon[i] = genDegeri;
            //}

            for (int i = 0; i < Populasyon.Length; i++)
            {
                Populasyon[i].YeniGeniKopyala(yeniPopulasyon[i]);
            }

        }

        private ParametreDegeri EnIyiHesapla(IAmacFonksiyonu amacFonksiyonu)
        {
            Gen best = Populasyon[0];

            foreach (Gen parcacik in Populasyon)
                if (amacFonksiyonu.degerKiyasla(parcacik, best))
                    best = parcacik;

            if (EnIyıGen == null)
                EnIyıGen = new ParametreDegeri(best);
            else if (amacFonksiyonu.degerKiyasla(best, EnIyıGen))
                EnIyıGen.DegeriKopyala(best);

            return best;
        }

        private void AmacFonksiyonunuHesapla(Gen gen, IAmacFonksiyonu amacFonksiyonu)
        {
            int currentIndex = 0;
            int uzunluk = 0;

            for (int ii = 0; ii < genBuyuklukleri.Length; ii++)
            {
                ArraySegment<bool> parca = new ArraySegment<bool>(gen.GenAl, currentIndex, genBuyuklukleri[ii] + uzunluk);
                gen.degiskeniGuncelle(ii, GAUtils.GeninGercekDegeri(parca, amacFonksiyonu.altSinir(ii), amacFonksiyonu.ustSinir(ii)));
                uzunluk += genBuyuklukleri[ii];
            }

            double deger = amacFonksiyonu.fonksiyonDegeri(gen);
            gen.degeriGuncelle(deger);
        }

        private Gen[] BaslangicPopulasyonu(int buyukluk, int hassasiyet, IAmacFonksiyonu amacFonksiyonu)
        {
            Gen[] populasyon = new Gen[buyukluk];
            int degiskenBuyuklugu = amacFonksiyonu.fonksiyonDegiskenSayisi();
            genBuyuklukleri = new int[degiskenBuyuklugu];
            int toplamGenUzunlugu = 0;

            for (int i = 0; i < degiskenBuyuklugu; i++)
            {
                int uzunluk = GAUtils.GenUzunlukHesapla(amacFonksiyonu.altSinir(i), amacFonksiyonu.ustSinir(i), hassasiyet);
                genBuyuklukleri[i] = uzunluk;
                toplamGenUzunlugu += uzunluk;
            }

            for (int i = 0; i < buyukluk; i++)
            {
                Gen gen = new Gen(GAUtils.GenOlustur(toplamGenUzunlugu, rastgele), degiskenBuyuklugu, hassasiyet);
                AmacFonksiyonunuHesapla(gen, amacFonksiyonu);
                populasyon[i] = gen;
            }

            Genbuyuklugu = toplamGenUzunlugu;
            return populasyon;
        }

    }

}
