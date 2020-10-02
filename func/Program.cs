using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace _3
{
    class Program
    {

        private static double Side(double x1, double y1, double x2, double y2)
        {
            double side = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Math.Abs(side);
        }

        private static double Area(double side1, double side2, double side3)
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        private static double Perimeter(double side1, double side2, double side3)
        {
            return side1 + side2 + side3; 
        }

        private static double Сircumscribed(double side1, double side2, double side3)
        {
            
            return (side1*side2*side3) / (4 * Area(side1, side2, side3));
        }

        private static double Inscribed(double side1, double side2, double side3)
        {
            return Area(side1, side2, side3) / (Perimeter(side1, side2, side3) / 2);
        }
        

        private static double Existing(double side1, double side2, double side3)
        {
            if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static double InFile(double coord)
        {
            using (var sw = new StreamWriter("test.txt",true))
            {

                sw.WriteLine($"{coord}");
                return 0;
            }
        }



        private static void OutFile()
        {
            using (var sr = new StreamReader("test.txt"))
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.WriteLine($"Координати точки {z+1}: ");
                    var text_x = sr.ReadLine();
                    Console.Write($"x{z + 1}: ");
                    Console.WriteLine(text_x);
                    var text_y = sr.ReadLine();
                    Console.Write($"y{z + 1}: ");
                    Console.WriteLine(text_y);
                }

                
            }
        }

        static void Main(string[] args)
        {

            double x_a;
            double y_a;
            double x_b;
            double y_b;
            double x_c;
            double y_c;



            double[] Sides = new double[3];

            Console.OutputEncoding = System.Text.Encoding.Unicode;


            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть x1 = ");
                    x_a = Convert.ToDouble(Console.ReadLine());
                        
                    InFile(x_a);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть y1 = ");
                    y_a = Convert.ToDouble(Console.ReadLine());
                    InFile(y_a);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть x2 = ");
                    x_b = Convert.ToDouble(Console.ReadLine());
                    InFile(x_b);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть y2 = ");
                    y_b = Convert.ToDouble(Console.ReadLine());
                    InFile(y_b);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть x3 = ");
                    x_c = Convert.ToDouble(Console.ReadLine());
                    InFile(x_c);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть y3 = ");
                    y_c = Convert.ToDouble(Console.ReadLine());
                    InFile(y_c);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
            }
            for (int i = 0; i < 3; i++)
            {
                
                if (i == 0)
                {
                    double side1 = Side(x_a, y_a, x_b, y_b);
                    Sides[i] = side1;
                    Console.WriteLine($"Сторона 1 = {side1} (од.вим.)");
                }
                else if (i == 1)
                {
                    double side2 = Side(x_a, y_a, x_c, y_c);
                    Sides[i] = side2;
                    Console.WriteLine($"Сторона 2 = {side2} (од.вим.)");
                }
                else
                {
                    double side3 = Side(x_c, y_c, x_b, y_b);
                    Sides[i] = side3;
                    Console.WriteLine($"Сторона 3 = {side3} (од.вим.)");

                    if (Existing(Sides[0], Sides[1], Sides[2]) == 0)
                    {
                        Console.WriteLine("Такого трикутника не існує");
                    }
                    else
                    {
                        OutFile();
                        Console.WriteLine("Периметр трикутника = {0} (од.вим.)", Perimeter(Sides[0], Sides[1], Sides[2]));
                        Console.WriteLine("Площа трикутника = {0} (кв.од.)", Area(Sides[0], Sides[1], Sides[2]));
                        Console.WriteLine("Радіус описаного кола = {0} (од.вим.)", Сircumscribed(Sides[0], Sides[1], Sides[2]));
                        Console.WriteLine("Радіус вписаного кола = {0} (од.вим.)", Inscribed(Sides[0], Sides[1], Sides[2]));
                    }
                }
            }
        Console.ReadKey();
        }
        
    }
}


