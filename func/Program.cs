using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_4
{

    class Coord
    {
        private double x;
        private double y;
        public double XCoord
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double YCoord
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
    class Sides
    {
        private double lenght;

        public double Side
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
            }
        }
    }

    class Program
    {
        static string choice;
        private static double TriangleSide(double x1, double y1, double x2, double y2)
        {
            double side = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Math.Abs(side);
        }

        private static void OutFile()
        {

            using (var sr = new StreamReader("test.txt"))
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.WriteLine($"Координати точки {z + 1}: ");
                    var text_x = sr.ReadLine();
                    Console.Write($"x{z + 1}: ");
                    Console.WriteLine(text_x);
                    var text_y = sr.ReadLine();
                    Console.Write($"y{z + 1}: ");
                    Console.WriteLine(text_y);
                }
                if (choice == "0")
                {
                    sr.Close();
                    File.WriteAllText("test.txt", String.Empty);
                }

            }

        }

        private static double InFile(double coord)
        {
            using (var sw = new StreamWriter("test.txt", true))
            {

                sw.WriteLine($"{coord}");
                sw.Close();
                return 0;
            }
        }

        public static double OutputingX(double x)
        {
            while (true)
            {
                try
                {
                    if (choice == "0")
                    {
                        Console.WriteLine($"Введіть x = ");
                        x = Convert.ToDouble(Console.ReadLine());
                        InFile(x);
                        break;
                    }
                    else if (choice == "1")
                    {
                        var lines = File.ReadAllLines("test.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
                        File.WriteAllLines("test.txt", lines);
                        using (var sr = new StreamReader("test.txt"))
                        {
                            x = Convert.ToDouble(sr.ReadLine());
                            sr.Close();
                            InFile(x);
                            sr.Close();
                            Delete();
                            sr.Close();
                            break;
                        }
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                    if (choice == "1")
                    {
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            return x;
        }

        public static double OutputingY(double y)
        {
            while (true)
            {
                try
                {
                    if (choice == "0")
                    {
                        Console.WriteLine($"Введіть y = ");
                        y = Convert.ToDouble(Console.ReadLine());
                        InFile(y);
                        break;
                    }
                    else if (choice == "1")
                    {
                        var lines = File.ReadAllLines("test.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
                        File.WriteAllLines("test.txt", lines);
                        using (var sr = new StreamReader("test.txt"))
                        {
                            y = Convert.ToDouble(sr.ReadLine());
                            sr.Close();
                            InFile(y);
                            sr.Close();
                            Delete();
                            sr.Close();
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");

                    if (choice == "1")
                    {
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }
            }
            return y;
        }

        public static void Delete()
        {
            var lines = File.ReadAllLines("test.txt");
            File.WriteAllLines("test.txt", lines.Skip(1).ToArray());
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

            return (side1 * side2 * side3) / (4 * Area(side1, side2, side3));
        }

        private static double Inscribed(double side1, double side2, double side3)
        {
            return Area(side1, side2, side3) / (Perimeter(side1, side2, side3) / 2);
        }
        private static void ChoiceControl()
        {
            Console.WriteLine($"Введення з файлу чи з клавіатури?\n0 - з клавіатури  1 - з файлу: ");
            while (true)
            {
                choice = Console.ReadLine();
                if (choice == "0" ^ choice == "1")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Будь ласка оберіть один із режимів роботи");
                }
            }

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ChoiceControl();
            if (choice == "0")
            {
                Coord dot1 = new Coord();
                Console.WriteLine($"Введіть координати 1 точки: ");
                dot1.XCoord = OutputingX(dot1.XCoord);
                dot1.YCoord = OutputingY(dot1.YCoord);
                Coord dot2 = new Coord();
                Console.WriteLine($"Введіть координати 2 точки: ");
                dot2.XCoord = OutputingX(dot2.XCoord);
                dot2.YCoord = OutputingY(dot2.YCoord);
                Coord dot3 = new Coord();
                Console.WriteLine($"Введіть координати 3 точки: ");
                dot3.XCoord = OutputingX(dot3.XCoord);
                dot3.YCoord = OutputingY(dot3.YCoord);
                Sides side1 = new Sides();
                side1.Side = TriangleSide(dot1.XCoord, dot1.YCoord, dot2.XCoord, dot2.YCoord);
                Sides side2 = new Sides();
                side2.Side = TriangleSide(dot1.XCoord, dot1.YCoord, dot3.XCoord, dot3.YCoord);
                Sides side3 = new Sides();
                side3.Side = TriangleSide(dot2.XCoord, dot2.YCoord, dot3.XCoord, dot3.YCoord);
                if (Existing(side1.Side, side2.Side, side3.Side) == 0)
                {
                    Console.WriteLine("Такого трикутника не існує");
                }
                else
                {
                    OutFile();
                    Console.WriteLine("Периметр трикутника = {0} (од.вим.)", Perimeter(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Площа трикутника = {0} (кв.од.)", Area(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Радіус описаного кола = {0} (од.вим.)", Сircumscribed(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Радіус вписаного кола = {0} (од.вим.)", Inscribed(side1.Side, side2.Side, side3.Side));

                }
                Console.ReadKey();
            }
            else if (choice == "1")
            {
                Coord dot1 = new Coord();
                dot1.XCoord = OutputingX(dot1.XCoord);
                dot1.YCoord = OutputingY(dot1.YCoord);
                Coord dot2 = new Coord();
                dot2.XCoord = OutputingX(dot2.XCoord);
                dot2.YCoord = OutputingY(dot2.YCoord);
                Coord dot3 = new Coord();
                dot3.XCoord = OutputingX(dot3.XCoord);
                dot3.YCoord = OutputingY(dot3.YCoord);
                Sides side1 = new Sides();
                side1.Side = TriangleSide(dot1.XCoord, dot1.YCoord, dot2.XCoord, dot2.YCoord);
                Sides side2 = new Sides();
                side2.Side = TriangleSide(dot1.XCoord, dot1.YCoord, dot3.XCoord, dot3.YCoord);
                Sides side3 = new Sides();
                side3.Side = TriangleSide(dot2.XCoord, dot2.YCoord, dot3.XCoord, dot3.YCoord);
                if (Existing(side1.Side, side2.Side, side3.Side) == 0)
                {
                    Console.WriteLine("Такого трикутника не існує");
                }
                else
                {
                    OutFile();
                    Console.WriteLine("Периметр трикутника = {0} (од.вим.)", Perimeter(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Площа трикутника = {0} (кв.од.)", Area(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Радіус описаного кола = {0} (од.вим.)", Сircumscribed(side1.Side, side2.Side, side3.Side));
                    Console.WriteLine("Радіус вписаного кола = {0} (од.вим.)", Inscribed(side1.Side, side2.Side, side3.Side));

                }
                Console.ReadKey();
            }

        }

    }
}
