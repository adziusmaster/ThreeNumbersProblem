namespace ThreeNumbersProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            var inputNumber = Checker();
            var array = ArrayOfNumbers(inputNumber);
            int[][] comb = GetCartesian(array);
            GetFinalSums(inputNumber, comb);
        }
        static void GetAppInfo()
        {
            string appName = "Three Numbers Problem";
            int appVersion = 1;
            string appAuthor = "A.T.Lech";
            string info = $"[{appName}] Version: 0.1.{appVersion} Author:{appAuthor}";

            Console.WriteLine("######################################################################");
            PrintColorMessage(ConsoleColor.Blue, info);
            Console.WriteLine("######################################################################");
        }
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static int Checker()
        {
            bool checker = false;
            PrintColorMessage(ConsoleColor.Red, "Pass a number");
            int inputNumber = 0;
            while (!checker)
            {
                string input = Console.ReadLine();
                checker = int.TryParse(input, out inputNumber);
                if (!checker)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "That is not a number!");
                }
                if (inputNumber < 3)
                {
                    PrintColorMessage(ConsoleColor.DarkRed, "There are no triplets of intigers that sums up to numbers less than 3! Pass bigger number.");
                    checker = false;
                }
            }
            return inputNumber;
        }
        static int[] ArrayOfNumbers(int inputNumber) 
            => Enumerable.Range(1, inputNumber).Reverse().ToArray();


        static int[][] GetCartesian(int[] array)
        {
            double v = Math.Pow(array.Length, 3);
            int x = Convert.ToInt32(v);
            int[][] comb = new int[x][];
         
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array.Length; k++)
                    {
                        x--;
                        comb[x] = new int[3];  
                        comb[x][0] = array[i];
                        comb[x][1] = array[j];
                        comb[x][2] = array[k];
                    }
                }
            }
            return comb;
        }
        static void GetFinalSums(int inputNumber, int[][] comb)
        {
            List<string> finalResults = new List<string>();
            List<string> uniqueItemsList = new List<string>();
            string stringOfNumbers;

            for (int i = 0; i < comb.Length; i++)
            {
                if (comb[i].Sum() == inputNumber)
                {
                    Array.Sort(comb[i]);
                    stringOfNumbers = $"{comb[i][0]} + {comb[i][1]} + {comb[i][2]}";
                    finalResults.Add(stringOfNumbers);
                }
            }
            uniqueItemsList = finalResults.Distinct().ToList();
            PrintColorMessage(ConsoleColor.Green, "Triplets of numbers that sums up to the given number: ");          
            for (int i = 0; i < uniqueItemsList.Count; i++)
            {
                Console.WriteLine(uniqueItemsList[i]);
            }
            PrintColorMessage(ConsoleColor.DarkGreen, $"There are {uniqueItemsList.Count} different combinations!");
        }
    }
}