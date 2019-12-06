using System;
using System.Text;
using System.Globalization;

namespace PointProjectionForEllipsoid
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //int n;
            //Console.WriteLine("Введите размерность");
            //n = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Введите коэффициенты канонической формы эллипсоида");
            string[] astring = Console.ReadLine().Split();
            double[] a = new double[astring.Length];
            for (int i = 0; i < astring.Length; i++) {
                a[i] = Double.Parse(astring[i], NumberStyles.Any); 
            }

            for (int i = 0; i < astring.Length; i++) { Console.WriteLine(a[i]); }
        }
    }
}
