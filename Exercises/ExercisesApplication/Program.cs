using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApplication
{
    class Program
    {
 
        static void Main(string[] args)
        {
           /* DoFirstExercise();
            DoSecondExercise();
            DoThirdExercise();
            DoFourthExercise();
            DoFivthExercise();
            DoSixthExercise();
            DoSeventhExercise();
            DoEighthExercise();
            DoNinethExercise();*/
            DoTenthExercise();

            Console.ReadLine();
        }

        static void DoFirstExercise()
        {
            int age = 20;
            Console.WriteLine("You are {0} years old\n", age);

        }

        static void DoSecondExercise()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("*****");
            }

        }

        static void DoThirdExercise()
        {
            int firstVariable = 10;
            Console.WriteLine(firstVariable);
            float secondVariable = 12.5f;
            Console.WriteLine(secondVariable);
            string thirdVariable = "C# programming";
            Console.WriteLine(thirdVariable);
            
        }

        static void DoFourthExercise()
        {
            Console.WriteLine("Please enter your name");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}", userName);
        }

        static void DoFivthExercise()
        {
            int x = 10;
            int y = 5;
            Console.WriteLine("Result:");
            Console.WriteLine("x value\t\ty value\t\tExpressions\tResult");
            Console.WriteLine("{0}\t\t\t{1}\tx=y+3 \t\t\t x= {2}", x, y, y + 3);
            Console.WriteLine("{0}\t\t\t{1}\tx=y-2 \t\t\t x= {2}", x, y, y - 2);
            Console.WriteLine("{0}\t\t\t{1}\tx=y*5 \t\t\t x= {2}", x, y, y * 5);
            Console.WriteLine("{0}\t\t\t{1}\tx=x/y \t\t\t x= {2}", x, y, (float)x / y);
            Console.WriteLine("{0}\t\t\t{1}\tx=x%y \t\t\t x= {2}", x, y, x % y); // остаток от деления          
        }

        static void DoSixthExercise()
        {
            Console.WriteLine("Enter an integer number, please");
            int a;
            int b;

            int.TryParse(Console.ReadLine(), out a);
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

        static void DoSeventhExercise()
        {
            Console.WriteLine("Please, enter the first number");
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            int.TryParse(Console.ReadLine(), out firstNumber);
            Console.WriteLine("Please, enter the second number");
            int.TryParse(Console.ReadLine(), out secondNumber);
            Console.WriteLine("Please, enter the third number");
            int.TryParse(Console.ReadLine(), out thirdNumber);

            if (firstNumber == secondNumber && firstNumber == thirdNumber)
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
        }

        static void DoEighthExercise()
        {

            Console.WriteLine("Enter quiz score:");
            float quizScore = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter mid-term score:");
            float midScore = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter final score:");
            float finalScore = float.Parse(Console.ReadLine());
            float averageScore = (quizScore + midScore + finalScore) / 3;

            if (averageScore >= 90)
            {
                Console.WriteLine("Grade A"); 
            }
            else if (averageScore >= 70 && averageScore < 90)
            { 
                Console.WriteLine("Grade B"); 
            }
            else if (averageScore >= 50 && averageScore < 70)
            { 
                Console.WriteLine("Grade C");
            }
            else if (averageScore < 50)
            { 
                Console.WriteLine("Grade F");
            }
            else
            { 
                Console.WriteLine("No variant"); 
            }

        }

        static void DoNinethExercise()
        {
            Console.WriteLine("Enter a number from 0 to 9 , please");
            char enteredNumber;
            char.TryParse(Console.ReadLine(), out enteredNumber);
            switch (enteredNumber)
            {
                case '0': Console.WriteLine("you entered 0"); break;
                case '1': Console.WriteLine("you entered 1"); break;
                case '2': Console.WriteLine("you entered 2"); break;
                case '3': Console.WriteLine("you entered 3"); break;
                case '4': Console.WriteLine("you entered 4"); break;
                case '5': Console.WriteLine("you entered 5"); break;
                case '6': Console.WriteLine("you entered 6"); break;
                case '7': Console.WriteLine("you entered 7"); break;
                case '8': Console.WriteLine("you entered 8"); break;
                case '9': Console.WriteLine("you entered 9"); break;
                default: Console.WriteLine("wrong value"); break;
            }

        }

        static void DoTenthExercise()
        {
            Console.WriteLine("What is the write way to declare the integer  value in C#");
            Console.WriteLine("a. int 1x = 10");
            Console.WriteLine("b. int x = 10");
            Console.WriteLine("c. float x = 10.0f");
            Console.WriteLine("d. string x = \"10\"");
            Console.WriteLine("Enter your choice");
            char answer = ' ';
            try
            {
                answer = char.Parse(Console.ReadLine());
            }
            catch (IOException e) { Console.WriteLine("IO Exception: {0}", e); }
            catch (FormatException i) { Console.WriteLine("IO Exception: {0}", i); }
            switch (answer)
            {
                case 'a': Console.WriteLine("Wrong"); break;
                case 'b': Console.WriteLine("Write"); break;
                case 'c': Console.WriteLine("Wrong"); break;
                case 'd': Console.WriteLine("Wrong"); break;
                default: Console.WriteLine("Wrong"); break;
            }
            


        }

    }
}
