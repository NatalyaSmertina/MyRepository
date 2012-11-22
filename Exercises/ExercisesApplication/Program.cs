using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st
            int age = 20;
            Console.WriteLine("You are {0} years old\n", age);
            // 2nd
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("*****");
            }
            //3d
            int firstVariable = 10;
            Console.WriteLine(firstVariable);
            float secondVariable = 12.5f;
            Console.WriteLine(secondVariable);
            string thirdVariable = "C# programming";
            Console.WriteLine(thirdVariable);
            //4th
            Console.WriteLine("Please enter your name");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}", userName);
            //5th
            int x = 10;
            int y = 5;
            Console.WriteLine("Result:");
            Console.WriteLine("x value\t\ty value\t\tExpressions\tResult");
            Console.WriteLine("{0}\t\t\t{1}\tx=y+3 \t\t\t x= {2}", x, y, y + 3);
            Console.WriteLine("{0}\t\t\t{1}\tx=y-2 \t\t\t x= {2}", x, y, y - 2);
            Console.WriteLine("{0}\t\t\t{1}\tx=y*5 \t\t\t x= {2}", x, y, y * 5);
            Console.WriteLine("{0}\t\t\t{1}\tx=x/y \t\t\t x= {2}", x, y, (float)x / y);
            Console.WriteLine("{0}\t\t\t{1}\tx=x%y \t\t\t x= {2}", x, y, x % y); // остаток от деления
            //6th
            Console.WriteLine("Enter an integer number, please");
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b;
                b = ++a;
                Console.WriteLine("The value of ++a is {0}", b);
                Console.WriteLine("The value of a is {0}", a);
                b = a++;
                Console.WriteLine("The value of a++ is {0}", b);
                Console.WriteLine("The value of a is {0}", a);

                b = --a;
                Console.WriteLine("The value of --a is {0}", b);
                Console.WriteLine("The value of a is {0}", a);
                b = a--;
                Console.WriteLine("The value of a-- is {0}", b);
                Console.WriteLine("The value of a is {0}", a);

            }
            catch
            {
                Console.WriteLine("You should enter an integer number");  
            }
        // 7th
            
            Console.WriteLine("Please, enter the first number");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter the second number");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter the third number");
            int thirdNumber = int.Parse(Console.ReadLine());

            if ((firstNumber == secondNumber) && (firstNumber == thirdNumber))
            {
               Console.WriteLine("All numbers are equal");   
            }
            else
            {
                List<int> numberList = new List<int>();
                numberList.Add(firstNumber);
                numberList.Add(secondNumber);
                numberList.Add(thirdNumber);
                numberList.Sort();
                Console.WriteLine("The greatest number is: {0}", numberList[2]);
            }

            //8th

            float quizScore;
            float midScore;
            float finalScore;
            float averageScore;
            Console.WriteLine("Enter quiz score:");
            quizScore = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter mid-term score:");
            midScore = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter final score:");
            finalScore = float.Parse(Console.ReadLine());
            averageScore = (quizScore + midScore + finalScore) / 3;

            if (averageScore >= 90)
            { Console.WriteLine("Grade A"); }
            else if ((averageScore >= 70) && (averageScore < 90))
            { Console.WriteLine("Grade B"); }
            else if ((averageScore >= 50) && (averageScore < 70))
            { Console.WriteLine("Grade C"); }
            else if (averageScore < 50)
            { Console.WriteLine("Grade F"); }
            else
            { Console.WriteLine("No variant"); }

            Console.ReadLine();
        }
    }
}
