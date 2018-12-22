using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace Yazlab1_2_Sudoku{
    public partial class Form1 : Form{
        Stopwatch k = new Stopwatch();
        public Form1(){
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        ArrayList GerceklesenAdimlar1=  new ArrayList();
        ArrayList GerceklesenAdimlar2 = new ArrayList();
        ArrayList GerceklesenAdimlar3 = new ArrayList();

        Thread BirinciCozumumThread;
        Thread IkinciCozumumThread;
        Thread UcuncuCozumumThread;
        Thread CozumleriSonlandirThread;
        int [,] ButunSudokuDegerleriYedek = new int[9, 9];
        int CozumleriSonlandirmeDegeri = 0;
        //Dosyan Verileri Okur Ve Yedekler
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = openFileDialog1.FileName;
               
                FileStream Dosyam = new FileStream(DosyaYolu,FileMode.Open,FileAccess.Read);
                StreamReader Okuma = new StreamReader(Dosyam);
                
                string OkunanDeger ="";
                for (int i= 0; i < 9; i++)
			    {
                    OkunanDeger = Okuma.ReadLine();
                    for (int j  = 0; j < 9; j++)
                    {
                       
                        int AsilSayim = 0;
                        string sayi = OkunanDeger[j].ToString();
                        if (sayi.Equals("*"))
                        {
                            AsilSayim = 0;
                        }
                        else
                        {
                            AsilSayim = Convert.ToInt32(sayi);
                        }

                        ButunSudokuDegerleriYedek[i, j] = AsilSayim;
                    }
                    
			    }
                
                Okuma.Close();
                Dosyam.Close();
                
            }
        }
        public bool SatiraGelebilirMi(int x, int Denenen, int[,] ButunSudokuDegerleri)
        {
            bool DonenKontrolDegerim = true;
            for (int i = 0; i < 9; i++)
            {
                if (ButunSudokuDegerleri[x, i] == Denenen)
                {
                    DonenKontrolDegerim = false;
                    break;
                    
                }
            
            }
            return DonenKontrolDegerim;
        
        }
        public bool SutunaGelebilirMi(int y, int Denenen, int[,] ButunSudokuDegerleri)
        {
            bool DonenKontrolDegerim = true;
            for (int i = 0; i < 9; i++)
            {
                if (ButunSudokuDegerleri[i, y] == Denenen)
                {
                    DonenKontrolDegerim = false;
                    break;

                }

            }
            return DonenKontrolDegerim;        
        }
        public bool AlanaGelebilirMi(int x, int y, int Denenen,int [,] ButunSudokuDegerleri)
        {
            bool DonenKontrolDegerim = true;
            int xMin = 0, xMax = 0;
            int yMin = 0, yMax = 0;

            if (x >= 0 && x <= 2)
            {
                xMin = 0;
                xMax = 2;    
            }
            if (x >= 3 && x <= 5)
            {
                xMin = 3;
                xMax = 5;
            
            }
            if (x >= 6 && x <= 8)
            {
                xMin = 6;
                xMax = 8;

            }

            if (y >= 0 && y <= 2)
            {
                yMin = 0;
                yMax = 2;

            }
            if (y >= 3 && y <= 5)
            {
                yMin = 3;
                yMax = 5;

            }
            if (y >= 6 && y <= 8)
            {
                yMin = 6;
                yMax = 8;

            }

            for (int i = xMin; i <=xMax; i++)
            {
                for (int j = yMin; j < yMax; j++)
                {
                    if (ButunSudokuDegerleri[i, j] == Denenen)
                    {
                        DonenKontrolDegerim = false;
                        break;
                    }

                }
                if (DonenKontrolDegerim == false)
                {
                    break;
                }
                
            }


            return DonenKontrolDegerim;
        }
        public void BulunanCozumuEkrandaGoster(int[,] ButunSudokuDegerleri)
        {
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    if (ButunSudokuDegerleri[satir, sutun] != 0)
                    {
                        if (satir == 0)
                        {
                            if (sutun == 0) { label11.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label12.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label13.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label14.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label15.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label16.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label17.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label18.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label19.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 1)
                        {
                            if (sutun == 0) { label21.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label22.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label23.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label24.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label25.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label26.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label27.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label28.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label29.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 2)
                        {
                            if (sutun == 0) { label31.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label32.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label33.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label34.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label35.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label36.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label37.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label38.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label39.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }

                        else if (satir == 3)
                        {
                            if (sutun == 0) { label41.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label42.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label43.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label44.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label45.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label46.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label47.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label48.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label49.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 4)
                        {
                            if (sutun == 0) { label51.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label52.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label53.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label54.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label55.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label56.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label57.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label58.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label59.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 5)
                        {
                            if (sutun == 0) { label61.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label62.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label63.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label64.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label65.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label66.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label67.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label68.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label69.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 6)
                        {
                            if (sutun == 0) { label71.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label72.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label73.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label74.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label75.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label76.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label77.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label78.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label79.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 7)
                        {
                            if (sutun == 0) { label81.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label82.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label83.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label84.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label85.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label86.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label87.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label88.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label89.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                        else if (satir == 8)
                        {
                            if (sutun == 0) { label91.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 1) { label92.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 2) { label93.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 3) { label94.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 4) { label95.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 5) { label96.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 6) { label97.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 7) { label98.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                            else if (sutun == 8) { label99.Text = ButunSudokuDegerleri[satir, sutun].ToString(); }
                        }
                    }
                }

            }
        }
        public void SuDokuCoz1(int[,] ButunSudokuDegerleri)
        {
            int EklenenSayiAdeti = 0;
            for (int i = 0; i<9; i++)
            {

                for (int j = 0; j < 9; j++)
                {

                     if (ButunSudokuDegerleri[i, j] == 0)
                    {
                        string GelecekIhtimaller = "";
                        for (int DenenenDeger = 1; DenenenDeger <=9; DenenenDeger++)
                        {
                            bool DonenKontrolDegerim1 = SatiraGelebilirMi(i, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim2 = SutunaGelebilirMi(j, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim3 = AlanaGelebilirMi(i, j, DenenenDeger, ButunSudokuDegerleri);
                            if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                            {
                                GelecekIhtimaller += DenenenDeger.ToString();
                                
                            }

                        }
                        if (GelecekIhtimaller.Length == 1)
                        {
                           string AtananDeger=GelecekIhtimaller[0].ToString();
                           int IntAtananDeger = Convert.ToInt32(AtananDeger);
                           ButunSudokuDegerleri[i, j] = IntAtananDeger;                           
                           string s11 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                           GerceklesenAdimlar1.Add(s11);
                           EklenenSayiAdeti++;
                        }
                    
                    }
                
                }
                if (i == 8 && EklenenSayiAdeti!=0)
                {

                    i = -1;
                    EklenenSayiAdeti = 0;
                }
            
            }
            
        
        }
        public void SuDokuCoz2(int[,] ButunSudokuDegerleri)
        {
            int EklenenSayiAdeti = 0;
            for (int i = 0; i < 9; i++)
            {

                for (int j = 8; j>=0; j--)
                {

                    if (ButunSudokuDegerleri[i, j] == 0)
                    {
                        string GelecekIhtimaller = "";
                        for (int DenenenDeger = 1; DenenenDeger <= 9; DenenenDeger++)
                        {
                            bool DonenKontrolDegerim1 = SatiraGelebilirMi(i, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim2 = SutunaGelebilirMi(j, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim3 = AlanaGelebilirMi(i, j, DenenenDeger, ButunSudokuDegerleri);
                            if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                            {
                                GelecekIhtimaller += DenenenDeger.ToString();

                            }

                        }
                        if (GelecekIhtimaller.Length == 1)
                        {
                            string AtananDeger = GelecekIhtimaller[0].ToString();
                            int IntAtananDeger = Convert.ToInt32(AtananDeger);
                            ButunSudokuDegerleri[i, j] = IntAtananDeger;
                            string s22 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                            GerceklesenAdimlar2.Add(s22);
                            EklenenSayiAdeti++;
                        }

                    }

                }
                if (i == 8 && EklenenSayiAdeti != 0)
                {

                    i = -1;
                    EklenenSayiAdeti = 0;
                }

            }


        }
        public void SuDokuCoz3(int[,] ButunSudokuDegerleri)
        {
            int EklenenSayiAdeti = 0;
            for (int i = 8; i >=0; i--)
            {

                for (int j = 0; j < 9; j++)
                {

                    if (ButunSudokuDegerleri[i, j] == 0)
                    {
                        string GelecekIhtimaller = "";
                        for (int DenenenDeger = 1; DenenenDeger <= 9; DenenenDeger++)
                        {
                            bool DonenKontrolDegerim1 = SatiraGelebilirMi(i, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim2 = SutunaGelebilirMi(j, DenenenDeger, ButunSudokuDegerleri);
                            bool DonenKontrolDegerim3 = AlanaGelebilirMi(i, j, DenenenDeger, ButunSudokuDegerleri);
                            if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                            {
                                GelecekIhtimaller += DenenenDeger.ToString();

                            }

                        }
                        if (GelecekIhtimaller.Length == 1)
                        {
                            string AtananDeger = GelecekIhtimaller[0].ToString();
                            int IntAtananDeger = Convert.ToInt32(AtananDeger);
                            ButunSudokuDegerleri[i, j] = IntAtananDeger;
                            string s33 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                            GerceklesenAdimlar3.Add(s33);
                            EklenenSayiAdeti++;
                        }

                    }

                }
                if (i == 0 && EklenenSayiAdeti != 0)
                {

                    i = 9;
                    EklenenSayiAdeti = 0;
                }

            }


        }
        public int DoluYerlerinAdetiniGeriDondur(int[,] ButunSudokuDegerleri)
        {
            int ToplamAdet = 0;
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    if (ButunSudokuDegerleri[satir, sutun] != 0)
                    {

                        ToplamAdet = ToplamAdet + 1;
                    }
                }
            }

            return ToplamAdet;
        }
        public string AnaElemanlarimiStringeCevir(int[,] ButunSudokuDegerleri)
        {
            string StringSonucum= "";
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    StringSonucum += ButunSudokuDegerleri[satir, sutun].ToString();   
                }
            }

            return StringSonucum;
        }
        public void SuDokuTamaminiCoz1(int[,] ButunSudokuDegerleri)
        {


            string [,] DenenenIhtimaller =new string[9,9];
            string [] DenenenVerilerim = new string[81];
            string [,] Adimlarim=new string [81,2];
            int SuankiKonumum = -1;
            for (int i = 0; i < 9; i++)
            {
                for (int J = 0; J < 9; J++)
                {
                    DenenenIhtimaller[i,J] = "";
                }
                    
                
            }
            int k = 0, l = 0, ilerle = 0;
            int satir=0;
            int sutun=0;
           
            int sutunSiradaki = 0;
            int GirilmisMi = 0;
            int ToplamVeriAdeti = 0;
            int sutunyedek = 0;
            SuDokuCoz1(ButunSudokuDegerleri);
            while (true)
            {
                if (ToplamVeriAdeti < 81)
                {

                    for (satir = 0; satir < 9; satir++)
                    {
                        if (GirilmisMi == 1)
                        {
                           
                            sutunSiradaki=sutunyedek;
                            GirilmisMi = 0;
                            
                        }
                        else
                        {

                            sutunSiradaki = 0;
                        }

                        for (sutun = sutunSiradaki; sutun < 9; sutun++)
                        {

                            if (ButunSudokuDegerleri[satir, sutun] == 0)
                            {
                                string GelecekIhtimaller = "";
                                for (int DenenenDeger = 1; DenenenDeger <= 9; DenenenDeger++)
                                {
                                    bool DonenKontrolDegerim1 = SatiraGelebilirMi(satir, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim2 = SutunaGelebilirMi(sutun, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim3 = AlanaGelebilirMi(satir, sutun, DenenenDeger, ButunSudokuDegerleri);
                                    if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                                    {
                                        GelecekIhtimaller += DenenenDeger.ToString();


                                    }
                                }
                                if (GelecekIhtimaller.Length >=1)
                                {

                                    int Gelenuzunluk = GelecekIhtimaller.Length;
                                    string yedek = "";
                                    int Knt = 0;
                                   
                                        for (int i = 0; i < Gelenuzunluk; i++)
                                        {
                                            int DenenenUzunluk = DenenenIhtimaller[satir,sutun].ToString().Length;
                                            for (int j = 0; j < DenenenUzunluk; j++)
                                            {
                                                if (GelecekIhtimaller[i].ToString().Equals(DenenenIhtimaller[satir,sutun][j].ToString()))
                                                {

                                                    Knt = 1;
                                                }

                                            }
                                            if (Knt == 0)
                                            {
                                                yedek += GelecekIhtimaller[i].ToString();
                                            }
                                            else
                                            {
                                                Knt = 0;


                                            }


                                        }
                                        GelecekIhtimaller = yedek;
                                    if (GelecekIhtimaller.Length == 0)
                                    {
                                        String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();
                                        
                                        k = 0;
                                        l = 0;
                                        ilerle = 0;
                                        for (ilerle = 0; ilerle < 81; ilerle++)
                                        {
                                            int mod = ilerle % 9;
                                            if (ilerle != 0 && mod == 0)
                                            {
                                                k++;
                                                l = 0;

                                            }
                                            String deger = YeniAnaVerim[ilerle].ToString();
                                            int degerim = Convert.ToInt32(deger);
                                            ButunSudokuDegerleri[k, l] = degerim;
                                            
                                            l++;
                                        }
                                        
                                        string s11 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        if (s11.Length > 0)
                                        {
                                            GerceklesenAdimlar1.Add(s11);
                                        }
                                        GirilmisMi = 1;
                                        DenenenIhtimaller[satir, sutun] = "";
                                         satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString())-1;
                                        sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                        Adimlarim[SuankiKonumum, 0] = "";
                                        Adimlarim[SuankiKonumum, 1] = "";
                                        DenenenVerilerim[SuankiKonumum] = "";                                        
                                        SuankiKonumum--;
                                        break;

                                    }
                                    else if (GelecekIhtimaller.Length >= 1)
                                    {

                                        SuankiKonumum += 1;
                                        Adimlarim[SuankiKonumum, 0] = satir.ToString();
                                        Adimlarim[SuankiKonumum, 1] = sutun.ToString();
                                        DenenenVerilerim[SuankiKonumum] = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        DenenenIhtimaller[satir, sutun] += GelecekIhtimaller[0].ToString();
                                        ButunSudokuDegerleri[satir, sutun] = Convert.ToInt32(GelecekIhtimaller[0].ToString());
                                        string s11 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        GerceklesenAdimlar1.Add(s11);
                                        SuDokuCoz1(ButunSudokuDegerleri);
                                    }
                                }
                                //Hata Var Bir Onceki Adıma Git
                                else if (GelecekIhtimaller.Length == 0)
                                {
                                    String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();

                                    k = 0;
                                    l = 0;
                                    ilerle = 0;
                                    for (ilerle = 0; ilerle < 81; ilerle++)
                                    {
                                        int mod = ilerle % 9;
                                        if (ilerle != 0 && mod == 0)
                                        {
                                            k++;
                                            l = 0;

                                        }
                                        String deger = YeniAnaVerim[ilerle].ToString();
                                        int degerim = Convert.ToInt32(deger);
                                        ButunSudokuDegerleri[k, l] = degerim;
                                        l++;
                                    }

                                    string s11 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                    if (s11.Length > 0)
                                    {
                                        GerceklesenAdimlar1.Add(s11);
                                    }
                                    GirilmisMi = 1;
                                    satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString()) - 1;
                                    sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                    Adimlarim[SuankiKonumum, 0] = "";
                                    Adimlarim[SuankiKonumum, 1] = "";
                                    DenenenVerilerim[SuankiKonumum] = "";
                                    SuankiKonumum--;
                                    break;
                                }

                            }

                        }

                        ToplamVeriAdeti = DoluYerlerinAdetiniGeriDondur(ButunSudokuDegerleri);                                        
                       
                        if (ToplamVeriAdeti == 81)
                        {

                            break;
                        }
                    }
                    if (ToplamVeriAdeti == 81)
                    {

                        break;
                    }
                }
            }
        
        }
        public void SuDokuTamaminiCoz2(int[,] ButunSudokuDegerleri)
        {
            string[,] DenenenIhtimaller = new string[9, 9];
            string[] DenenenVerilerim = new string[81];
            string[,] Adimlarim = new string[81, 2];
            int SuankiKonumum = -1;
            for (int i = 0; i < 9; i++)
            {
                for (int J = 8; J>=0; J--)
                {
                    DenenenIhtimaller[i, J] = "";
                }


            }
            int k = 0, l = 0, ilerle = 0;
            int satir = 0;
            int sutun = 0;

            int sutunSiradaki = 0;
            int GirilmisMi = 0;
            int ToplamVeriAdeti = 0;
            int sutunyedek = 0;
            SuDokuCoz2(ButunSudokuDegerleri);
            while (true)
            {
                if (ToplamVeriAdeti < 81)
                {

                    for (satir = 0; satir < 9; satir++)
                    {
                        if (GirilmisMi == 1)
                        {

                            sutunSiradaki = sutunyedek;
                            GirilmisMi = 0;

                        }
                        else
                        {

                            sutunSiradaki = 8;
                        }

                        for (sutun = sutunSiradaki; sutun>=0; sutun--)
                        {

                            if (ButunSudokuDegerleri[satir, sutun] == 0)
                            {
                                string GelecekIhtimaller = "";
                                for (int DenenenDeger = 1; DenenenDeger <= 9; DenenenDeger++)
                                {
                                    bool DonenKontrolDegerim1 = SatiraGelebilirMi(satir, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim2 = SutunaGelebilirMi(sutun, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim3 = AlanaGelebilirMi(satir, sutun, DenenenDeger, ButunSudokuDegerleri);
                                    if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                                    {
                                        GelecekIhtimaller += DenenenDeger.ToString();


                                    }
                                }
                                if (GelecekIhtimaller.Length >= 1)
                                {

                                    int Gelenuzunluk = GelecekIhtimaller.Length;
                                    string yedek = "";
                                    int Knt = 0;

                                    for (int i = 0; i < Gelenuzunluk; i++)
                                    {
                                        int DenenenUzunluk = DenenenIhtimaller[satir, sutun].ToString().Length;
                                        for (int j = 0; j < DenenenUzunluk; j++)
                                        {
                                            if (GelecekIhtimaller[i].ToString().Equals(DenenenIhtimaller[satir, sutun][j].ToString()))
                                            {

                                                Knt = 1;
                                            }

                                        }
                                        if (Knt == 0)
                                        {
                                            yedek += GelecekIhtimaller[i].ToString();
                                        }
                                        else
                                        {
                                            Knt = 0;


                                        }


                                    }
                                    GelecekIhtimaller = yedek;
                                    if (GelecekIhtimaller.Length == 0)
                                    {
                                        String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();

                                        k = 0;
                                        l = 0;
                                        ilerle = 0;
                                        for (ilerle = 0; ilerle < 81; ilerle++)
                                        {
                                            int mod = ilerle % 9;
                                            if (ilerle != 0 && mod == 0)
                                            {
                                                k++;
                                                l = 0;

                                            }
                                            String deger = YeniAnaVerim[ilerle].ToString();
                                            int degerim = Convert.ToInt32(deger);
                                            ButunSudokuDegerleri[k, l] = degerim;
                                            l++;
                                        }
                                        string s22 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        if (s22.Length > 0)
                                        {
                                            GerceklesenAdimlar2.Add(s22);
                                        }
                                        
                                        GirilmisMi = 1;
                                        DenenenIhtimaller[satir, sutun] = "";
                                        satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString()) -1;
                                        sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                        Adimlarim[SuankiKonumum, 0] = "";
                                        Adimlarim[SuankiKonumum, 1] = "";
                                        DenenenVerilerim[SuankiKonumum] = "";
                                        SuankiKonumum--;
                                        break;

                                    }
                                    else if (GelecekIhtimaller.Length >= 1)
                                    {

                                        SuankiKonumum += 1;
                                        Adimlarim[SuankiKonumum, 0] = satir.ToString();
                                        Adimlarim[SuankiKonumum, 1] = sutun.ToString();
                                        DenenenVerilerim[SuankiKonumum] = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        DenenenIhtimaller[satir, sutun] += GelecekIhtimaller[0].ToString();
                                        ButunSudokuDegerleri[satir, sutun] = Convert.ToInt32(GelecekIhtimaller[0].ToString());
                                        string s22 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        GerceklesenAdimlar2.Add(s22);
                                        SuDokuCoz2(ButunSudokuDegerleri);
                                    }
                                }
                                //Hata Var Bir Onceki Adıma Git
                                else if (GelecekIhtimaller.Length == 0)
                                {
                                    String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();

                                    k = 0;
                                    l = 0;
                                    ilerle = 0;
                                    for (ilerle = 0; ilerle < 81; ilerle++)
                                    {
                                        int mod = ilerle % 9;
                                        if (ilerle != 0 && mod == 0)
                                        {
                                            k++;
                                            l = 0;

                                        }
                                        String deger = YeniAnaVerim[ilerle].ToString();
                                        int degerim = Convert.ToInt32(deger);
                                        ButunSudokuDegerleri[k, l] = degerim;
                                        l++;
                                    }

                                    string s22 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                    if (s22.Length > 0)
                                    {
                                        GerceklesenAdimlar2.Add(s22);
                                    }
                                    GirilmisMi = 1;
                                    satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString()) - 1;
                                    sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                    Adimlarim[SuankiKonumum, 0] = "";
                                    Adimlarim[SuankiKonumum, 1] = "";
                                    DenenenVerilerim[SuankiKonumum] = "";
                                    SuankiKonumum--;
                                    break;
                                }

                            }

                        }

                        ToplamVeriAdeti = DoluYerlerinAdetiniGeriDondur(ButunSudokuDegerleri);

                        if (ToplamVeriAdeti == 81)
                        {

                            break;
                        }
                    }
                    if (ToplamVeriAdeti == 81)
                    {

                        break;
                    }
                }
            }

        }
        public void SuDokuTamaminiCoz3(int[,] ButunSudokuDegerleri)
        {
            string[,] DenenenIhtimaller = new string[9, 9];
            string[] DenenenVerilerim = new string[81];
            string[,] Adimlarim = new string[81, 2];
            int SuankiKonumum = -1;
            for (int i = 8; i >=0; i--)
            {
                for (int J = 0; J < 9; J++)
                {
                    DenenenIhtimaller[i, J] = "";
                }


            }
            int k = 0, l = 0, ilerle = 0;
            int satir = 0;
            int sutun = 0;

            int sutunSiradaki = 0;
            int GirilmisMi = 0;
            int ToplamVeriAdeti = 0;
            int sutunyedek = 0;
            SuDokuCoz3(ButunSudokuDegerleri);
            while (true)
            {
                if (ToplamVeriAdeti < 81)
                {

                    for (satir = 0; satir < 9; satir++)
                    {
                        if (GirilmisMi == 1)
                        {

                            sutunSiradaki = sutunyedek;
                            GirilmisMi = 0;

                        }
                        else
                        {

                            sutunSiradaki = 0;
                        }

                        for (sutun = sutunSiradaki; sutun < 9; sutun++)
                        {

                            if (ButunSudokuDegerleri[satir, sutun] == 0)
                            {
                                string GelecekIhtimaller = "";
                                for (int DenenenDeger = 1; DenenenDeger <= 9; DenenenDeger++)
                                {
                                    bool DonenKontrolDegerim1 = SatiraGelebilirMi(satir, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim2 = SutunaGelebilirMi(sutun, DenenenDeger, ButunSudokuDegerleri);
                                    bool DonenKontrolDegerim3 = AlanaGelebilirMi(satir, sutun, DenenenDeger, ButunSudokuDegerleri);
                                    if (DonenKontrolDegerim1 == true && DonenKontrolDegerim2 == true && DonenKontrolDegerim3 == true)
                                    {
                                        GelecekIhtimaller += DenenenDeger.ToString();


                                    }
                                }
                                if (GelecekIhtimaller.Length >= 1)
                                {

                                    int Gelenuzunluk = GelecekIhtimaller.Length;
                                    string yedek = "";
                                    int Knt = 0;

                                    for (int i = 0; i < Gelenuzunluk; i++)
                                    {
                                        int DenenenUzunluk = DenenenIhtimaller[satir, sutun].ToString().Length;
                                        for (int j = 0; j < DenenenUzunluk; j++)
                                        {
                                            if (GelecekIhtimaller[i].ToString().Equals(DenenenIhtimaller[satir, sutun][j].ToString()))
                                            {

                                                Knt = 1;
                                            }

                                        }
                                        if (Knt == 0)
                                        {
                                            yedek += GelecekIhtimaller[i].ToString();
                                        }
                                        else
                                        {
                                            Knt = 0;


                                        }


                                    }
                                    GelecekIhtimaller = yedek;
                                    if (GelecekIhtimaller.Length == 0)
                                    {
                                        String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();

                                        k = 0;
                                        l = 0;
                                        ilerle = 0;
                                        for (ilerle = 0; ilerle < 81; ilerle++)
                                        {
                                            int mod = ilerle % 9;
                                            if (ilerle != 0 && mod == 0)
                                            {
                                                k++;
                                                l = 0;

                                            }
                                            String deger = YeniAnaVerim[ilerle].ToString();
                                            int degerim = Convert.ToInt32(deger);
                                            ButunSudokuDegerleri[k, l] = degerim;
                                            l++;
                                        }
                                        string s33 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        if (s33.Length > 0)
                                        {
                                            GerceklesenAdimlar3.Add(s33);
                                        }
                                       
                                        GirilmisMi = 1;
                                        DenenenIhtimaller[satir, sutun] = "";
                                        satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString()) +1;
                                        sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                        Adimlarim[SuankiKonumum, 0] = "";
                                        Adimlarim[SuankiKonumum, 1] = "";
                                        DenenenVerilerim[SuankiKonumum] = "";
                                        SuankiKonumum--;
                                        break;

                                    }
                                    else if (GelecekIhtimaller.Length >= 1)
                                    {

                                        SuankiKonumum += 1;
                                        Adimlarim[SuankiKonumum, 0] = satir.ToString();
                                        Adimlarim[SuankiKonumum, 1] = sutun.ToString();
                                        DenenenVerilerim[SuankiKonumum] = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                        DenenenIhtimaller[satir, sutun] += GelecekIhtimaller[0].ToString();
                                        ButunSudokuDegerleri[satir, sutun] = Convert.ToInt32(GelecekIhtimaller[0].ToString());
                                        string s33 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);

                                        GerceklesenAdimlar3.Add(s33);
                                        SuDokuCoz3(ButunSudokuDegerleri);
                                    }
                                }
                                //Hata Var Bir Onceki Adıma Git
                                else if (GelecekIhtimaller.Length == 0)
                                {
                                    String YeniAnaVerim = DenenenVerilerim[SuankiKonumum].ToString();

                                    k = 0;
                                    l = 0;
                                    ilerle = 0;
                                    for (ilerle = 0; ilerle < 81; ilerle++)
                                    {
                                        int mod = ilerle % 9;
                                        if (ilerle != 0 && mod == 0)
                                        {
                                            k++;
                                            l = 0;

                                        }
                                        String deger = YeniAnaVerim[ilerle].ToString();
                                        int degerim = Convert.ToInt32(deger);
                                        ButunSudokuDegerleri[k, l] = degerim;
                                        l++;
                                    }

                                    string s33 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri);
                                    if (s33.Length > 0)
                                    {
                                        GerceklesenAdimlar3.Add(s33);
                                    }
                                    GirilmisMi = 1;
                                    satir = Convert.ToInt32(Adimlarim[SuankiKonumum, 0].ToString()) +1;
                                    sutunyedek = Convert.ToInt32(Adimlarim[SuankiKonumum, 1].ToString());
                                    Adimlarim[SuankiKonumum, 0] = "";
                                    Adimlarim[SuankiKonumum, 1] = "";
                                    DenenenVerilerim[SuankiKonumum] = "";
                                    SuankiKonumum--;
                                    break;
                                }

                            }

                        }

                        ToplamVeriAdeti = DoluYerlerinAdetiniGeriDondur(ButunSudokuDegerleri);

                        if (ToplamVeriAdeti == 81)
                        {

                            break;
                        }
                    }
                    if (ToplamVeriAdeti == 81)
                    {

                        break;
                    }
                }
            }

        }
        public void BirinciCozumum(object  Gonderilen)
        { 
            int [,]  Dizim =Gonderilen as int[,];
            SuDokuTamaminiCoz1(Dizim);
            CozumleriSonlandirmeDegeri = 1;
        }
        public void IkinciCozumum(object  Gonderilen)
        { 
            int [,]  Dizim =Gonderilen as int[,];
            SuDokuTamaminiCoz2(Dizim);
            CozumleriSonlandirmeDegeri = 1;
        
        }
        public void UcuncuCozumum(object  Gonderilen)
        { 
            int [,]  Dizim =Gonderilen as int[,];
            SuDokuTamaminiCoz3(Dizim);
            CozumleriSonlandirmeDegeri = 1;
        
        }
        public void DosyayaKaydet()
        {
            FileStream fileDosyam = new FileStream("C://Users//Chicharito//Desktop//SudokumIhtimaller1.txt", FileMode.Create, FileAccess.Write);
            StreamWriter yazdir = new StreamWriter(fileDosyam);
            int i = 0;
            string eleman = "";
            foreach (string b in GerceklesenAdimlar1)
            {
                eleman = b;

                if (  eleman!=null)
                {

                    for (int k = 0; k < 81; k++)
                    {
                        if (k != 0 && k % 9 == 0)
                        {

                            yazdir.WriteLine("");
                        }
                        if (eleman[k].ToString().Equals("0"))
                        {

                            yazdir.Write("*");
                        }
                        else
                        {

                            yazdir.Write(eleman[k].ToString());

                        }

                    }
                    yazdir.WriteLine("");
                    yazdir.WriteLine("");
                }

                i++;
            }
            yazdir.Close();
            fileDosyam.Close();


            fileDosyam = new FileStream("C://Users//Chicharito//Desktop//SudokumIhtimaller2.txt", FileMode.Create, FileAccess.Write);
            yazdir = new StreamWriter(fileDosyam);

            foreach (string d in GerceklesenAdimlar2)
            {
                eleman = d;

                if (eleman != null)
                {
                    for (int k = 0; k < 81; k++)
                    {
                        if (k != 0 && k % 9 == 0)
                        {

                            yazdir.WriteLine("");
                        }
                        if (eleman[k].ToString().Equals("0"))
                        {

                            yazdir.Write("*");
                        }
                        else
                        {

                            yazdir.Write(eleman[k].ToString());

                        }

                    }
                    yazdir.WriteLine("");
                    yazdir.WriteLine("");
                }
                i++;
            }
            yazdir.Close();
            fileDosyam.Close();



            fileDosyam = new FileStream("C://Users//Chicharito//Desktop//SudokumIhtimaller3.txt", FileMode.Create, FileAccess.Write);
            yazdir = new StreamWriter(fileDosyam);

            foreach (string b in GerceklesenAdimlar3)
            {
                eleman = b;

                if (eleman != null)
                {
                    for (int k = 0; k < 81; k++)
                    {
                        if (k != 0 && k % 9 == 0)
                        {

                            yazdir.WriteLine("");
                        }
                        if (eleman[k].ToString().Equals("0"))
                        {

                            yazdir.Write("*");
                        }
                        else
                        {

                            yazdir.Write(eleman[k].ToString());

                        }

                    }
                    yazdir.WriteLine("");
                    yazdir.WriteLine("");
                }
                i++;
            }
            yazdir.Close();
            fileDosyam.Close();


           
        }
        public void CozumleriSonlandir()
        {
            while (true)
            {
                if (CozumleriSonlandirmeDegeri == 1)
                {
                    k.Stop();
                    label1.Text = k.Elapsed.Milliseconds.ToString()+" Mili Sayine" ;
                    BirinciCozumumThread.Abort();
                    IkinciCozumumThread.Abort();
                    UcuncuCozumumThread.Abort();
                    
                    DosyayaKaydet();
                    break;
                }
                
            }
            string s1 = "";
            string s2 = "";
            string s3 = "";
            foreach (string b in GerceklesenAdimlar1)
            {
                s1 = b;
            }
            foreach (string b in GerceklesenAdimlar2)
            {
                s2 = b;
            }
            foreach (string b in GerceklesenAdimlar3)
            {
                s3 = b;
            }
            int sr = 0;
            int st = 0;


            int[,] d1 = new int[9, 9];
            int[,] d2 = new int[9, 9];
            int[,] d3 = new int[9, 9];

            sr = 0;
            st = 0;
            
            for (int i = 0; i < 81; i++)
            {
                if (i != 0 && i % 9 == 0)
                {

                    sr++;
                    st = 0;
                }
                d1[sr, st] = Convert.ToInt32(s1[i].ToString());
                st++;


            }

            sr = 0;
            st = 0;

            for (int i = 0; i < 81; i++)
            {
                if (i != 0 && i % 9 == 0)
                {

                    sr++;
                    st = 0;
                }
                d2[sr, st] = Convert.ToInt32(s2[i].ToString());
                st++;
            }
            sr = 0;
            st = 0;

            for (int i = 0; i < 81; i++)
            {
                if (i != 0 && i % 9 == 0)
                {

                    sr++;
                    st = 0;
                }
                d3[sr, st] = Convert.ToInt32(s3[i].ToString());
                st++;
            }
            int snc = 0;
            if(s1.Contains("0")==false)
            {
                snc = 1;
                BulunanCozumuEkrandaGoster(d1);
                //ZamanaBagli zm = new ZamanaBagli(snc, d1);
               // zm.ShowDialog();
            
            }
            else if (s2.Contains("0") == false)
            {

                snc = 1;
                BulunanCozumuEkrandaGoster(d2);
                //ZamanaBagli zm = new ZamanaBagli(snc, d2);
                //zm.ShowDialog();


            }
            else if (s3.Contains("0") == false)
            {
                snc = 2;
                BulunanCozumuEkrandaGoster(d3);
              //  ZamanaBagli zm = new ZamanaBagli(snc, d3);
                //zm.ShowDialog();
            
            }

            
            Thread1 t1 = new Thread1(d1);
            t1.ShowDialog();
            Thread2 t2 = new Thread2(d2);
            t2.ShowDialog();
            Thread3 t3 = new Thread3(d3);
            t3.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int[,] ButunSudokuDegerleri1 = new int[9, 9];
            int[,] ButunSudokuDegerleri2 = new int[9, 9];
            int[,] ButunSudokuDegerleri3 = new int[9, 9];
           
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ButunSudokuDegerleri1[i, j] = ButunSudokuDegerleriYedek[i, j];
                    ButunSudokuDegerleri2[i, j] = ButunSudokuDegerleriYedek[i, j];
                    ButunSudokuDegerleri3[i, j] = ButunSudokuDegerleriYedek[i, j];

                }
            }
            string s1=AnaElemanlarimiStringeCevir(ButunSudokuDegerleri1);
            GerceklesenAdimlar1.Add(s1);
            string s2 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri2);
            GerceklesenAdimlar2.Add(s2);
            string s3 = AnaElemanlarimiStringeCevir(ButunSudokuDegerleri3);
            GerceklesenAdimlar3.Add(s3);

            k.Start();
            BirinciCozumumThread = new Thread(BirinciCozumum);
            IkinciCozumumThread = new Thread(IkinciCozumum);
            UcuncuCozumumThread = new Thread(UcuncuCozumum);
            CozumleriSonlandirThread = new Thread(CozumleriSonlandir);
            CozumleriSonlandirThread.Start();
            BirinciCozumumThread.Start(ButunSudokuDegerleri1);
            IkinciCozumumThread.Start(ButunSudokuDegerleri2);
            UcuncuCozumumThread.Start(ButunSudokuDegerleri3);
                      
            
            
        }
        
    }
}
