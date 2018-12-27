using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_String
{
    class Program
    {

        static void ReadConsoleMassive1D()
        {
            int[] massInt = new int[6];
            var random = new Random();

            for (int i = 0; i < massInt.Length; i++)
                massInt[i] = random.Next(0, 10);

            for (int i = 0; i < massInt.Length; i++)
                Console.Write($" {massInt[i]} ");
        }

        static void MassiveMaxInRow3D()
        {
            const int SIZE = 3;
            int[,] mass = new int[SIZE, SIZE];

            var random = new Random();

            int maxValueInRow = 0;

            for (int i = 0; i < SIZE ; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    mass[i, j] = random.Next(1, 100);
                    if (maxValueInRow < mass[i, j]) maxValueInRow = mass[i, j];
                }
                Console.WriteLine($"Max value in {i} row : {maxValueInRow}");
                maxValueInRow = 0;
            }

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write($"  { mass[i, j] }  ");
            
                }
                Console.WriteLine("");
            }
        }

        static void MasiveSort1D()
        {
            int[] massInt = new int[5];
            var random = new Random();

            int tempValue;

            for (int i = 0; i < massInt.Length - 1; i++)
                massInt[i] = random.Next(0, 10);

            Console.Write("Массив");
            for (int i = 0; i < massInt.Length; i++)
                Console.Write($" {massInt[i]} ");

            for (int i = 0; i < massInt.Length; i++)
            {
                tempValue = massInt[i];
                for (int j = i + 1; j < massInt.Length; j++)
                {
                    if (tempValue > massInt[j])
                    {
                        massInt[i] = massInt[j];
                        massInt[j] = tempValue;
                        tempValue = massInt[i];
                    }
                }
            }

            Console.Write("\nОтсортированный массив");
            for (int i = 0; i < massInt.Length; i++)
                Console.Write($" {massInt[i]} ");
        }

        static void ViewMass(int[,] mass, int SIZE)
        {
            Console.WriteLine();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Console.Write($" { mass[i, j] } ");


                }
                Console.WriteLine("");
            }
        }

        static void Pyatnashki()
        {
            const int SIZE = 3;
            int[,] mass = new int[SIZE, SIZE];

            var random = new Random();

            int zeroI = 0;
            int zeroJ = 0;

            int temp;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    mass[i, j] = random.Next(1, SIZE*SIZE);
                }
            }

            zeroI = random.Next(0, SIZE - 1);
            zeroJ = random.Next(0, SIZE - 1);

            mass[zeroI, zeroJ] = 0;

            ViewMass(mass, SIZE);

            while (true)
            {
                Console.WriteLine("Выберите направление клавишами 'WASD'. Для выходя нажмите 'L'");
                
                var buttom = Console.ReadKey();
                switch (buttom.KeyChar)
                {
                    case 'W':
                    case 'w':
                        if (zeroI - 1 < 0) ViewMass(mass, SIZE);
                        else
                        {
                            temp = mass[zeroI - 1, zeroJ];
                            mass[zeroI - 1, zeroJ] = 0;
                            mass[zeroI, zeroJ] = temp;
                            zeroI--;
                            ViewMass(mass, SIZE);
                        }
                        break;
                    case 'S':
                    case 's':
                        if (zeroI + 1 > SIZE - 1) ViewMass(mass, SIZE);
                        else
                        {
                            temp = mass[zeroI + 1, zeroJ];
                            mass[zeroI + 1, zeroJ] = 0;
                            mass[zeroI, zeroJ] = temp;
                            zeroI++;
                            ViewMass(mass, SIZE);
                        }
                        break;
                    case 'A':
                    case 'a':
                        if (zeroJ - 1 < 0) ViewMass(mass, SIZE);
                        else
                        {
                            temp = mass[zeroI, zeroJ - 1];
                            mass[zeroI, zeroJ - 1] = 0;
                            mass[zeroI, zeroJ] = temp;
                            zeroJ--;
                            ViewMass(mass, SIZE);
                        }
                        break;
                    case 'D':
                    case 'd':
                        if (zeroJ + 1 > SIZE - 1) ViewMass(mass, SIZE);
                        else
                        {
                            temp = mass[zeroI, zeroJ + 1];
                            mass[zeroI, zeroJ + 1] = 0;
                            mass[zeroI, zeroJ] = temp;
                            zeroJ++;
                            ViewMass(mass, SIZE);
                        }

                        break;
                    case 'L':
                    case 'l':
                        return;
                    default:
                        ViewMass(mass, SIZE);
                        break;
                }
            }
        }

        static void CutString()
        {
            Console.WriteLine("Введите строку");
            string Stroka = Console.ReadLine();
            int numOfSymbols = 0;

            foreach (int chr in Stroka)
                numOfSymbols++;

            if (numOfSymbols > 13)
            {
                Stroka = Stroka.Remove(13, numOfSymbols - 13);
               //Console.WriteLine(Stroka);
                Stroka = Stroka + "...";
            }
            Console.WriteLine(Stroka);
        }

        static void ReplaceInPoem()
        {
            Console.WriteLine("Введите стихотворение разделяя строки символом ';'");
            string Stih = Console.ReadLine();
            Stih = Stih.ToUpper();

            string[] rowsInStih = Stih.Split(';');

            for (int i = 0; i < rowsInStih.Length; i++)
            {
                rowsInStih[i] = rowsInStih[i].Replace("О", "А")
                .Replace("Л", "ЛЬ")
                .Replace("ТЬ", "Т");
            }
            for (int i = 0; i < rowsInStih.Length; i++)
            {
                Console.WriteLine(rowsInStih[i]);
            }
        }

        static void Main(string[] args)
        {
            ReadConsoleMassive1D(); 
            MassiveMaxInRow3D();
            MasiveSort1D();
            Pyatnashki();
            CutString();
            ReplaceInPoem();

            Console.ReadKey();

        }
    }
}
