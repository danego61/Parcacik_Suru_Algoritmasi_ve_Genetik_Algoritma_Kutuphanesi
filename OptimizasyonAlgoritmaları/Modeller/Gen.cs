using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizasyonAlgoritmaları.Modeller
{
    public class Gen : ParametreDegeri
    {
        private bool[] gen;
        internal bool[] GenAl { get => gen; }

        internal Gen(bool[] gen, int degiskenSayisi, int hassasiyet) : base(degiskenSayisi, hassasiyet)
            => this.gen = gen;

        internal void YeniGeniKopyala(bool[] yeniGen)
        {
            //gen = yeniGen;
            Array.Copy(yeniGen, gen, gen.Length);
        }

        internal void GeniCaprazla(Gen caprazlanacakGen, int caprazlamaNoktası)
        {
            int uzunluk = gen.Length - caprazlamaNoktası;
            bool[] gidecekGen = new bool[uzunluk];

            for (int i = caprazlamaNoktası; i < gen.Length; i++)
                gidecekGen[i - caprazlamaNoktası] = gen[i];

            bool[] gelenGen = caprazlanacakGen.Caprazla(caprazlamaNoktası, gidecekGen);

            for (int i = caprazlamaNoktası; i < gen.Length; i++)
                gen[i] = gelenGen[i - caprazlamaNoktası];
        }

        internal void MutasyonUygula(int i) => gen[i] = !gen[i];

        private bool[] Caprazla(int index, bool[] yeniDeger)
        {
            bool[] retval = new bool[gen.Length - index];

            for (int i = index; i < gen.Length; i++)
            {
                retval[i - index] = gen[i];
                gen[i] = yeniDeger[i - index];
            }

            return retval;
        }
    }
}
