using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları
{
    public class ParcacikSuruAlgoritması : OptimizasyonAlgoritması
    {
        private Parcacik[] populasyon = null;
        private ParametreDegeri gbest;
        internal static double C1, C2, W;

        public ParcacikSuruAlgoritması(IAlgoritmaDurumu algoritmaDurumu) : base(algoritmaDurumu)
        {

        }

        public void Hesapla(
            IAmacFonksiyonu amacFonksiyonu,
            int hassasiyet,
            int populasyonBuyuklugu,
            int iterasyonSayisi,
            double c1,
            double c2
            ) => Task.Factory.StartNew(() =>
        {
            var toplam = c1 + c2;
            C1 = c1;
            C2 = c2;
            W = 2 / Math.Abs(2 - toplam - Math.Pow((toplam * toplam) - (4 * toplam), 0.5));
            HesaplamaBasladi(amacFonksiyonu, iterasyonSayisi);
            populasyon = BaslangicPopulasyonu(populasyonBuyuklugu, hassasiyet, amacFonksiyonu);

            for (int i = 0; i < iterasyonSayisi; i++)
            {
                var best = AdimIsle(amacFonksiyonu);
                DonguSonucu(i, best);
            }

            HesaplamaBitti(gbest);
            populasyon = null;
            gbest = null;
        });

        private ParametreDegeri AdimIsle(IAmacFonksiyonu amacFonksiyonu)
        {
            var best = GBestHesapla(amacFonksiyonu);

            Parallel.ForEach(populasyon, parcacik =>
            {
                ParcacikHizHesapla(parcacik);
                ParcacikKonumGuncelle(parcacik, amacFonksiyonu);
                UygunlukDegeriHesapla(parcacik, amacFonksiyonu);
            });

            return best;
        }

        private ParametreDegeri GBestHesapla(IAmacFonksiyonu amacFonksiyonu)
        {
            Parcacik best = populasyon[0];

            foreach (var parcacik in populasyon)
                if (amacFonksiyonu.degerKiyasla(parcacik, best))
                    best = parcacik;

            if (gbest == null)
                gbest = new ParametreDegeri(best);
            else if (amacFonksiyonu.degerKiyasla(best, gbest))
                gbest.DegeriKopyala(best);

            return best;
        }

        private void ParcacikHizHesapla(Parcacik parcacik)
        {
            parcacik.HizlariGuncelle(gbest, rastgele);
        }

        private void ParcacikKonumGuncelle(Parcacik parcacik, IAmacFonksiyonu amacFonksiyonu)
        {
            parcacik.KonumuGuncelle(amacFonksiyonu);
        }

        private void UygunlukDegeriHesapla(Parcacik parcacik, IAmacFonksiyonu amacFonksiyonu)
        {
            var deger = amacFonksiyonu.fonksiyonDegeri(parcacik);
            parcacik.degeriGuncelle(deger);
            if (amacFonksiyonu.degerKiyasla(parcacik, parcacik.pBest))
                parcacik.YeniPBest();
        }

        private Parcacik[] BaslangicPopulasyonu(int buyukluk, int hassasiyet, IAmacFonksiyonu amacFonksiyonu)
        {
            var parcaciklar = new Parcacik[buyukluk];
            int degiskenBuyuklugu = amacFonksiyonu.fonksiyonDegiskenSayisi();

            for (int i = 0; i < buyukluk; i++)
            {
                var degiskenler = new double[degiskenBuyuklugu];
                for (int ii = 0; ii < degiskenBuyuklugu; ii++)
                {
                    double altSinir = amacFonksiyonu.altSinir(ii),
                        ustSinir = amacFonksiyonu.ustSinir(ii);
                    degiskenler[ii] = amacFonksiyonu.altSinir(ii) + (rastgele.NextDouble() * (ustSinir - altSinir));
                }
                var parcacik = new Parcacik(degiskenler, hassasiyet);
                var deger = amacFonksiyonu.fonksiyonDegeri(parcacik);
                parcacik.degeriGuncelle(deger);
                parcacik.YeniPBest();
                parcaciklar[i] = parcacik;
            }

            return parcaciklar;
        }

    }

}
