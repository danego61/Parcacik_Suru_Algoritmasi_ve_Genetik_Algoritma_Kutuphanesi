using LiveCharts;
using LiveCharts.Wpf;
using OptimizasyonAlgoritmaları;
using OptimizasyonAlgoritmaları.Arayuzler;
using OptimizasyonAlgoritmaları.Modeller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yapay_Zeka.Arayuzler;
using static Yapay_Zeka.Modeller.Fonksiyonlar;

namespace Yapay_Zeka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAlgoritmaDurumu
    {
        private static IFonksiyon[] fonksiyonlar = new IFonksiyon[]
        {
            new F1(),
            new F2(),
            new F3(),
            new F4(),
            new F5(),
            new F6()
        };
        private static IFonksiyon seciliFonksiyon = fonksiyonlar[0];

        public SeriesCollection SeriesCollection1 { get; set; }
        public string[] Labels1 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> YFormatter1 { get; set; }
        public Func<double, string> YFormatter2 { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }

        private bool parcacikMi = true;
        private ParcacikSuruAlgoritması pso;
        private GenetikAlgoritma ga;
        private bool grafikCizilsin = true;
        private bool gaHesaplanacak = false;
        private double[,] geciciDegiskenDegerleri;
        private double[] geciciFonksiyonDegerleri;

        public MainWindow()
        {
            InitializeComponent();
            pso = new ParcacikSuruAlgoritması(this);
            ga = new GenetikAlgoritma(this);
            GrafikHazirla();
        }

        private void GrafikHazirla()
        {
            SeriesCollection1 = new SeriesCollection();
            Labels1 = new string[1000];
            Labels2 = new string[1000];
            for (int i = 0; i < 1000; i++)
            {
                Labels1[i] = i.ToString();
                Labels2[i] = i.ToString();
            }

            YFormatter1 = value => value.ToString();
            YFormatter2 = value => value.ToString();
            SeriesCollection2 = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Amac Fonksiyonu - PSO",
                    Values = new ChartValues<double>()
                },
                new LineSeries
                {
                    Title = "Amac Fonksiyonu - GA",
                    Values = new ChartValues<double>()
                }
            };
            DataContext = this;
        }

        private void btnHesapla_Click(object sender, RoutedEventArgs e)
        {
            grafikCizilsin = chcGrafik.IsChecked == true;
            SeriesCollection1.Clear();
            SeriesCollection2[0].Values.Clear();
            SeriesCollection2[1].Values.Clear();
            if (chcPSO.IsChecked == true)
            {
                gaHesaplanacak = chcGA.IsChecked == true;
                parcacikMi = true;
                PSOHesapla();
            } else if(chcGA.IsChecked == true)
            {
                gaHesaplanacak = false;
                parcacikMi = false;
                GAHesapla();
            }
        }

        private void PSOHesapla()
        {
            pso.Hesapla(seciliFonksiyon,
                   Convert.ToInt32(txtHassasiyet.Text),
                   Convert.ToInt32(txtPSOPopulasyonBuyuklugu.Text),
                   Convert.ToInt32(txtPSOiterasyon.Text),
                   Convert.ToDouble(txtC1.Text),
                   Convert.ToDouble(txtC2.Text)
                   );
        }

        private void GAHesapla()
        {
            ga.Hesapla(seciliFonksiyon,
                   Convert.ToInt32(txtHassasiyet.Text),
                   Convert.ToInt32(txtGAPopulasyonBuyuklugu.Text),
                   Convert.ToInt32(txtGAiterasyon.Text),
                   Convert.ToDouble(txtGAMutasyon.Text),
                   Convert.ToDouble(txtGACaprazlama.Text)
                   );
        }

        private void SeciliFonksiyonDegisti(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton chcbox)
            {
                seciliFonksiyon = chcbox.Name switch
                {
                    "F1" => fonksiyonlar[0],
                    "F2" => fonksiyonlar[1],
                    "F3" => fonksiyonlar[2],
                    "F4" => fonksiyonlar[3],
                    "F5" => fonksiyonlar[4],
                    _ => fonksiyonlar[5]
                };
                ArayuzGuncelle();
            }
        }

        private void ArayuzGuncelle()
        {
            if (txtMinimum != null && txtMaksimum != null)
            {
                txtMaksimum.Text = seciliFonksiyon.UstSinir();
                txtMinimum.Text = seciliFonksiyon.AltSinir();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double yuk = e.NewSize.Height - 350;
            double gen = (e.NewSize.Width / 2) - 20;
            Tablo1.Height = yuk;
            Tablo1.Width = gen;
            Tablo2.Height = yuk;
            Tablo2.Width = gen;
        }

        private void TabloyaSeriEkle(string title)
        {
            SeriesCollection1.Add(new LineSeries
            {
                Title = title,
                Values = new ChartValues<double>()
            });
        }

        private void TabloSerisineVeriEkle(int index, double veri, int amacIndex, double degeri)
        {
            SeriesCollection1[index].Values.Add(veri);
            SeriesCollection2[amacIndex].Values.Add(degeri);
        }

        public void HesaplamaBasladi(int iterasyonSayisi, int degiskenSayisi)
        {
            if (grafikCizilsin)
            {
                geciciDegiskenDegerleri = new double[degiskenSayisi, iterasyonSayisi];
                geciciFonksiyonDegerleri = new double[iterasyonSayisi];
            }
        }

        public void HesaplamaBitti(ParametreDegeri sonuc)
        {
            Dispatcher.Invoke(() =>
            {
                if (grafikCizilsin)
                {
                    for (int i = 0; i < geciciDegiskenDegerleri.GetLength(0); i++)
                        if (parcacikMi)
                            TabloyaSeriEkle("PSO-X" + (i + 1));
                        else
                            TabloyaSeriEkle("GA-X" + (i + 1));

                    for (int i = 0; i < geciciDegiskenDegerleri.GetLength(0); i++)
                    {
                        for (int ii = 0; ii < geciciDegiskenDegerleri.GetLength(1); ii++)
                        {
                            int index = parcacikMi ? i : gaHesaplanacak ? geciciDegiskenDegerleri.GetLength(0) + i : i;
                            TabloSerisineVeriEkle(index, geciciDegiskenDegerleri[i, ii], parcacikMi ? 0 : 1, geciciFonksiyonDegerleri[ii]);
                        }
                    }

                    geciciFonksiyonDegerleri = null;
                    geciciDegiskenDegerleri = null;
                }

                string mesaj = $"{(parcacikMi ? "Parçacık Sürü Algoritması" : "Genetik Algroritma")} {(parcacikMi ? pso.HesaplamaZamani : ga.HesaplamaZamani)} sürede sonucu hesapladı.\nBulunan en iyi değer: {sonuc.degeri()}\n";

                for (int i = 0; i < sonuc.degiskenSayisi; i++)
                    mesaj += $"X{i}: {sonuc.degiskeniAl(i)}\n";

                if (parcacikMi && gaHesaplanacak)
                {
                    mesaj += "Genetik Algoritma hesaplamasına devam etmek için tamam butonuna basın!";
                    if (MessageBox.Show(mesaj, "Sonuç", MessageBoxButton.OKCancel, MessageBoxImage.None) == MessageBoxResult.OK)
                    {
                        parcacikMi = false;
                        GAHesapla();
                    }
                }
                else
                    MessageBox.Show(mesaj, "Sonuç");
            });
        }

        public void DonguSonucu(int iterasyon, ParametreDegeri enIyiDeger)
        {
            if (grafikCizilsin)
            {
                for (int i = 0; i < enIyiDeger.degiskenSayisi; i++)
                    geciciDegiskenDegerleri[i, iterasyon] = enIyiDeger.degiskeniAl(i);

                geciciFonksiyonDegerleri[iterasyon] = enIyiDeger.degeri();
            }
        }
    }

}
