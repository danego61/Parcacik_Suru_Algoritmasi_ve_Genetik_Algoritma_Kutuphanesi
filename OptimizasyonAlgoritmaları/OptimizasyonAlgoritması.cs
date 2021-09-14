using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları
{

    public class OptimizasyonAlgoritması
    {
        private static Random _global = new Random();
        [ThreadStatic]
        private static Random _local;
        internal static Random rastgele
        {
            get
            {
                Random inst = _local;
                if (inst == null)
                {
                    int seed;
                    lock (_global) seed = _global.Next();
                    _local = inst = new Random(seed);
                }
                return inst;
            }
        }
        //internal Random rastgele;
        private ParametreDegeri enIyiDeger = null;
        private readonly Stopwatch sure = new Stopwatch();
        private readonly IAlgoritmaDurumu dinleyici;
        private IAmacFonksiyonu amacFonksiyonu = null;
        public TimeSpan HesaplamaZamani { get => sure.Elapsed; }

        internal OptimizasyonAlgoritması(IAlgoritmaDurumu dinleyici)
        {
            this.dinleyici = dinleyici;
        }

        internal void HesaplamaBasladi(IAmacFonksiyonu amacFonksiyonu, int iterasyonSayisi)
        {
            //rastgele = new Random();
            this.amacFonksiyonu = amacFonksiyonu;
            dinleyici?.HesaplamaBasladi(iterasyonSayisi, amacFonksiyonu.fonksiyonDegiskenSayisi());
            sure.Reset();
            sure.Start();
        }

        internal void DonguSonucu(int iterasyon, ParametreDegeri enIyiDeger)
        {
            dinleyici?.DonguSonucu(iterasyon, enIyiDeger);
            if (this.enIyiDeger == null || amacFonksiyonu.degerKiyasla(this.enIyiDeger, enIyiDeger))
                this.enIyiDeger = enIyiDeger;
        }

        internal void HesaplamaBitti(ParametreDegeri sonuc)
        {
            sure.Stop();
            dinleyici?.HesaplamaBitti(sonuc);
            amacFonksiyonu = null;
        }

    }

}