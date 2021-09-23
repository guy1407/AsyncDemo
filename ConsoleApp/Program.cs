using System;
using System.Threading.Tasks;  

namespace ConsoleApp
{
    class Program
    {
         public static long getNthFiboNumber(int nthIndex)
        {

            //this one runs too fast :)
            long firstNumber = 0;

            long secondNumber = 1;

            long currentIndex;

            long fibonacciNumber = 0;  

            if (nthIndex == 1)
            {
                fibonacciNumber = firstNumber;
            }
            else if (nthIndex == 2)
            {
                fibonacciNumber = secondNumber;
            }
            else 
            {
                //oh well, I must calculate
                currentIndex = 3;

                while (currentIndex <= nthIndex)
                {
                    fibonacciNumber = firstNumber + secondNumber;

                    firstNumber = secondNumber;

                    secondNumber = fibonacciNumber;

                    currentIndex++;
                }

            }// else calculate
            
            //System.Console.WriteLine($"The requested number in index [{nthIndex.ToString().Trim()}] = " + fibonacciNumber.ToString().Trim());

            return fibonacciNumber;

        }//getNthFiboNumber

        public static async Task getNthFiboNumberAsync(int nthIndex)
        {

            long result = 0;
            
            result = await Task.Run(() => getNthFiboNumber(nthIndex)); 

            System.Console.WriteLine("result = " + result.ToString().Trim() + ", if all went as planned, this line appears after a finished message!");
        }//getNthFiboNumberAsync

        static void Main(string[] args)
        {

            long result = 0;
            //#########################################

            Console.WriteLine("This is a SYNC demo:");
            Console.WriteLine("Start time :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("----------------------------");
            /////////////////////////////////////////////////////////////////           
            result = getNthFiboNumber(30);
            System.Console.WriteLine("result = " + result.ToString().Trim());
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("----------------------------");
            Console.WriteLine("SYNC part finished running:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("----------------------------");

            //#########################################

            Console.WriteLine("This is an  ASYNC demo:");
            Console.WriteLine("Start time :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("----------------------------");
            /////////////////////////////////////////////////////////////////
            getNthFiboNumberAsync(30);                      
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("----------------------------");
            Console.WriteLine("ASYNC part finished running:" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("----------------------------");

            //#########################################
        }
    }
}
