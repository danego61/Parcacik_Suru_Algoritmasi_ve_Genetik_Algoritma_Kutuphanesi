using OptimizasyonAlgoritmaları.Arayuzler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları.Modeller
{
    public class ParametreDegeri : Parametre
    {
        private double deger = double.NaN;

        internal ParametreDegeri(ParametreDegeri deger) : base(deger) => this.deger = deger.deger;

        internal ParametreDegeri(double[] degiskenler, int hassasiyet) : base(degiskenler, hassasiyet)
        {

        }

        internal ParametreDegeri(int degiskenSayisi, int hassasiyet) : base(degiskenSayisi, hassasiyet)
        {

        }

        public double degeri() => deger;

        internal void degeriGuncelle(double yeniDeger)
            => deger = Math.Round(yeniDeger, hassasiyet);

        internal void DegeriKopyala(ParametreDegeri kopyalanacak)
        {
            base.DegeriKopyala(kopyalanacak);
            deger = kopyalanacak.deger;
        }

    }

}
