using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları.Modeller
{
    public class Parametre
    {
        private double[] degiskenler;
        public int degiskenSayisi { get => degiskenler.Length; }
        public readonly int hassasiyet;

        internal Parametre(double[] degiskenler, int hassasiyet)
        {
            this.degiskenler = degiskenler;
            this.hassasiyet = hassasiyet;
        }

        internal Parametre(int degiskenSayisi, int hassasiyet)
        {
            this.hassasiyet = hassasiyet;
            degiskenler = new double[degiskenSayisi];
        }

        internal Parametre(Parametre parametre)
        {
            DegeriKopyala(parametre);
            hassasiyet = parametre.hassasiyet;
        }

        public double degiskeniAl(int index) => degiskenler[index];

        internal void degiskeniGuncelle(int index, double yeniDeger)
            => degiskenler[index] = Math.Round(yeniDeger, hassasiyet);

        internal void DegeriKopyala(Parametre kopyalanacak)
        {
            var buyukluk = kopyalanacak.degiskenler.Length;
            if (degiskenler == null || degiskenler.Length != buyukluk)
                degiskenler = new double[buyukluk];
            Array.Copy(kopyalanacak.degiskenler, degiskenler, buyukluk);
        }

    }
}