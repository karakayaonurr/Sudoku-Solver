using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
 

namespace Yazlab1_2_Sudoku
{
    public partial class ZamanaBagli : Form
    {
        int y;
        int[,] d = new int[9, 9];

        public ZamanaBagli(int g,int [,] deger)
        {
            y = g;
            d = deger;
            InitializeComponent();
        }

        public void BulunanCozumuEkrandaGoster1(int[,] ButunSudokuDegerleri)
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
                        Thread.Sleep(300);
                    }
                }

            }
        }
        public void BulunanCozumuEkrandaGoster2(int[,] ButunSudokuDegerleri)
        {
            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 8; sutun>=0; sutun--)
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
                        Thread.Sleep(300);
                    }
                }

            }
        }
        public void BulunanCozumuEkrandaGoster3(int[,] ButunSudokuDegerleri)
        {
            for (int satir = 8; satir >=0; satir--)
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
                        Thread.Sleep(300);
                    }
                }

            }
        }
        private void ZamanaBagli_Load(object sender, EventArgs e)
        {
            if (y == 1)
            {
                BulunanCozumuEkrandaGoster1(d);
            }
            if (y == 2)
            {
                BulunanCozumuEkrandaGoster2(d);
            }
            if (y == 3)
            {
                BulunanCozumuEkrandaGoster3(d);
            }

        }
    }
}
