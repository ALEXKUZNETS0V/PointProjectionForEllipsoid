﻿using System;
using System.Text;
using System.Globalization;
using static System.Math;

namespace PointProjectionForEllipsoid
{
    class Program
    {
        static int n;
        public static double G(double mu, double[] y, double[] a) 
        {
            double G = 0;
            double c, f, d;
            for (int i = 0; i < n; i++)
            {
                c = Math.Pow(y[i], 2) / Math.Pow(a[i], 2);
                d = (1 + (mu / Math.Pow(a[i], 2)));
                f = 1 / Math.Pow(d, 2);
                G += c*f;
            }
                //G += Math.Round((Math.Pow(y[i],2)/Math.Pow(a[i], 2)*(Math.Pow(1+mu/Math.Pow(a[i], 2),2))), 5);
            G -= 1.0;
            return G;
        }

        public static double DGdmu(double mu, double[] y, double[] a)
        {
            double G = 0;
            double c, f, d;
            for (int i = 0; i < n; i++)
            {
                c = (-2) * y[i] / (Math.Pow(a[i], 4));
                d= (1 + (mu / Math.Pow(a[i], 2)));
                f = 1 / Math.Pow(d, 3);
                G += c * f;
            }
                //G -= Math.Round(2 * y[i] / (Math.Pow((1 + mu / Math.Pow(a[i], 4)), 3) * Math.Pow(a[i], 4)),5);
         
            return G;
        }


        public static double NewtonMethod(double[] y, double[] a)
        {
            double muo= 0;
            double mun;
            for (int i = 1; i < 5; i++)
            {
                mun = Math.Round(muo - (G(muo, y, a) / DGdmu(muo, y, a)),5);
                muo = mun;
            }
               
            return muo;
        }

        static void Main(string[] args)
        {
           
            //int n;
            //Console.WriteLine("Введите размерность");
            //n = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Введите коэффициенты канонической формы эллипсоида через пробел, отделяя десятичную часть запятой");
            string[] astring = Console.ReadLine().Split();
            n = astring.Length;
            double[] a = new double[n];
            for (int i = 0; i < n; i++) { a[i] = Double.Parse(astring[i], NumberStyles.Any);}
            for (int i = 0; i < n; i++) { Console.WriteLine(a[i]); }


            Console.WriteLine("Введите координаты точки через пробел, отделяя десятичную часть запятой");
            string[] ystring = Console.ReadLine().Split();
            double[] y = new double[n];
            for (int i = 0; i < n; i++) { y[i] = Double.Parse(ystring[i], NumberStyles.Any); }
            for (int i = 0; i < n; i++) { Console.WriteLine(y[i]); }

           
            Console.WriteLine("Result");
            Console.WriteLine(NewtonMethod(y, a));
            for (int i = 0; i < n; i++) { Console.WriteLine(y[i]/(1+(NewtonMethod(y, a)/Math.Pow(a[i], 2)))); }

        }
    }
}
