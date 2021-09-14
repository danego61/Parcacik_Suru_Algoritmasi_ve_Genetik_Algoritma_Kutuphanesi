using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları.Arayuzler
{
    public interface IAlgoritmaDurumu
    {

        void HesaplamaBasladi(int iterasyonSayisi, int degiskenSayisi);

        void HesaplamaBitti(ParametreDegeri sonuc);

        void DonguSonucu(int iterasyon, ParametreDegeri enIyiDeger);

    }
}
