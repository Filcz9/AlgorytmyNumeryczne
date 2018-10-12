using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szeregi
{
    class Program
    {
        public static int j = 0;
        public static int z = 0;
        private static double Power(double x, int pow)
        {
            double res = 0;

            for (int i = 0; i <= pow; i++)
            {
                if (i == 0) res = 1;
                else if (i == 1) res = x;
                else res *= x;
            }
            //Console.WriteLine(res);
            return res;
        }
        private static double Silnia(double n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        private static double PoczBT(double x)
        {
            //int j = 0;
            double wynikcos = 0;
            double wyniklog = 0;
            double wynikpocz = 0;
            
            for (int i = 0; i < 30; i++)
            {
                if (i == 0)
                {
                    wynikcos = 1;

                }
                else if (i == 1)
                {
                    wynikcos -= Power(x, 2) / Silnia(2);
                    wyniklog += (Power(-1, i + 1) / i) * Power(x, i);
                }
                else
                {
                    wyniklog += (Power(-1, i + 1) * Power(x, i) / i);
                    wynikcos += (Power(-1, i) * Power(x, 2 * i) / Silnia(2 * i));
                }

            }
            j++;
            wynikpocz = wynikcos * wyniklog;
            Console.WriteLine("Wynik od poczatku bez tablicy: " + wynikpocz);
            Console.WriteLine("Wynik Math: " + Math.Cos(x) * Math.Log(1 + x));
            //using (StreamWriter writer3 = new StreamWriter("PoczBT.txt", true))
            //{

            //    writer3.WriteLine("Różnica " + j + " : " + (wynikpocz - (Math.Cos(x) * Math.Log(1 + x))));

            //}
            return wynikpocz;

        }
        private static double KonBT(double x)
        {
            double powx;
            double pow;
            double powxcos;
            double powlog;
            double powlogx;
            double wyniklog;
            double wynikcos;
            double wynikkon;
            double test;
            double test2;
            // int j = 0;
            int n = 30;
            double[] szeregcos = new double[n];
            double[] szereglog = new double[n];
            //double[] wyniki = new double[10];

            for (int i = 0; i < n; i++)
            {
                powx = Power(x, i);
                powxcos = Power(x, 2 * i);
                pow = Power(-1, i);
                powlog = Power(-1, i + 2);
                powlogx = Power(x, i + 1);

                // wynik = ((pow / Silnia(2 * i)) * powxcos) * (powlog / (i + 1) * powlogx);
                test = (powlog / (i + 1) * powlogx);
                szereglog[i] = test;
                test2 = (pow / Silnia(2 * i) * powxcos);
                szeregcos[i] = test2;
                //szereg[i] = szeregcos[i] * szereglog[i]; ;

            }
            wyniklog = szereglog[n - 1];
            wynikcos = szeregcos[n - 1];
            for (int i = n - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    wynikcos += 1;
                }
                else if (i == 1)
                {
                    wynikcos -= Power(x, 2) / Silnia(2);
                    wyniklog += (Power(-1, i + 1) * Power(x, i) / i);
                }
                else
                {
                    wyniklog += (Power(-1, i + 1) * Power(x, i) / i);
                    wynikcos += (Power(-1, i) * Power(x, 2 * i) / Silnia(2 * i));
                }
            }

            wynikkon = wyniklog * wynikcos;
            z++;
            Console.WriteLine("Wynik od konca bez tablicy: " + wynikkon);
            Console.WriteLine("Wynik Math: " + Math.Cos(x) * Math.Log(1 + x));
            //using (StreamWriter writer4 = new StreamWriter("KonBT.txt", true))
            //{

            //    writer4.WriteLine("Różnica " + z + " : " + (wynikkon - (Math.Cos(x) * Math.Log(1 + x))));

            //}
            return wynikkon;
        }
        static void Main(string[] args)
        {
            //double r = Power(-1, 0);
            //Console.WriteLine(r);

            int y = 0;
            double roznica;
            double roznica2;
            double wynik = 0;
            double suma_koniec = 0;
            double suma_poczatek = 0;
            double test = 0;
            double test2 = 0;
            int n = 30;
            double x = 0.1;
            double pow = -1;
            double powlog = -1;
            double powx = 1;
            double powlogx = 1;
            double powxcos = 1;
            double[] szereg = new double[n];
            double[] szeregcos = new double[n];
            double[] szereglog = new double[n];

            for (x = 0; x <= 1; x += 0.01)
            {
                for (int i = 0; i < n; i++)
                {
                    powx = Power(x, i);
                    powxcos = Power(x, 2 * i);
                    pow = Power(-1, i);
                    powlog = Power(-1, i + 2);
                    powlogx = Power(x, i + 1);

                    wynik = ((pow / Silnia(2 * i)) * powxcos) * (powlog / (i + 1) * powlogx);
                    test = (powlog / (i + 1) * powlogx);
                    szereglog[i] = test;
                    test2 = (pow / Silnia(2 * i) * powxcos);
                    szeregcos[i] = test2;
                    //szereg[i] = szeregcos[i] * szereglog[i]; ;

                }
                test = 0;
                test2 = 0;
                y++;
                for (int i = n - 1; i >= 0; i--)
                {
                    test += szereglog[i];
                    test2 += szeregcos[i];

                }
                suma_koniec = test * test2;
                Console.WriteLine("Suma liczenia od końca: " + suma_koniec);
                test = 0;
                test2 = 0;
                Console.WriteLine("Suma liczenia od końca Math: " + Math.Cos(x) * Math.Log(x + 1));
                //using (StreamWriter writer = new StreamWriter("Odkonca.txt", true))
                //{

                //    writer.WriteLine("Różnica " + y + " : " + (suma_koniec - (Math.Cos(x) * Math.Log(1 + x))));


                //}
                for (int i = 0; i < n; i++)
                {
                    test += szereglog[i];
                    test2 += szeregcos[i];


                }
                suma_poczatek = test * test2;
                Console.WriteLine("Suma liczenia od poczatku: " + suma_poczatek);
                Console.WriteLine("Suma liczenia od poczatku Math: " + Math.Cos(x) * Math.Log(1 + x));
                //using (StreamWriter writer2 = new StreamWriter("Odpoczatku.txt", true))
                //{

                //    writer2.WriteLine("Różnica " + y + " : " + (suma_poczatek - (Math.Cos(x) * Math.Log(1 + x))));

                //}

                roznica= suma_koniec - suma_poczatek;
               // if(roznica>=0)
               // {
                    Console.WriteLine("Roznica tablica: " + roznica);
               // }
              //  else Console.WriteLine("Roznica tablica: " + (-roznica));
               // PoczBT(x);
               // KonBT(x);
                roznica2 = PoczBT(x) - KonBT(x);
               // if (roznica2 >= 0)
               // {
                    Console.WriteLine("Roznica bez tablicy: " + roznica2);
              //  }
              //  else Console.WriteLine("Roznica bez tablicy: " + (-roznica2));
                //  Console.WriteLine("Roznica: " + roznica);
                //suma_koniec = 0;
                //suma_poczatek = 0;
                // Console.WriteLine(x * 1000000);
            }


            Console.ReadLine();

        }
    }
}
