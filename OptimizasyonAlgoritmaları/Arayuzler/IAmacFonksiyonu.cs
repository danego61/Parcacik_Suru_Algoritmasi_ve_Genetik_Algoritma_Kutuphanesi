using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları.Arayuzler
{
    public interface IAmacFonksiyonu
    {
        int fonksiyonDegiskenSayisi();

        double altSinir(int degiskenIndex);

        double ustSinir(int degiskenIndex);

        bool degerKiyasla(ParametreDegeri kiyaslanan, ParametreDegeri kiyaslanacak);

        double fonksiyonDegeri(Parametre deger);

    }
}
