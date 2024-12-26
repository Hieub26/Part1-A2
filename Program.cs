namespace Approximation_calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] testEpsilons = { 0.00001, 0.000001, 0.0000001 };
            double[] testValuesForSin = { Math.PI / 6, Math.PI / 4, Math.PI / 3 }; 
            double[] testValuesForCos = { Math.PI / 6, Math.PI / 4, Math.PI / 3 }; 
            double[] testValuesForLn = { 0.1, 0.5, 0.9 }; 

            Console.WriteLine("Testing approximations with sample data:\n");

            //CalculatePi
            foreach (double epsilon in testEpsilons)
            {
                double piApprox = CalculatePi(epsilon);
                Console.WriteLine($"Approximation of π with epsilon={epsilon}: {piApprox:F10} (Expected: 3.1415926536)");
            }

            //CalculateSin
            Console.WriteLine("\nTesting sin(x):");
            foreach (double x in testValuesForSin)
            {
                double sinApprox = CalculateSin(x, 0.0001);
                double expectedSin = Math.Sin(x);
                Console.WriteLine($"sin({x:F2}) ≈ {sinApprox:F10} (Expected: {expectedSin:F10})");
            }

            //CalculateCos
            Console.WriteLine("\nTesting cos(x):");
            foreach (double x in testValuesForCos)
            {
                double cosApprox = CalculateCos(x, 0.0001);
                double expectedCos = Math.Cos(x);
                Console.WriteLine($"cos({x:F2}) ≈ {cosApprox:F10} (Expected: {expectedCos:F10})");
            }

            //CalculateLn
            Console.WriteLine("\nTesting ln(1+x):");
            foreach (double x in testValuesForLn)
            {
                double lnApprox = CalculateLn(x, 0.0001);
                double expectedLn = Math.Log(1 + x);
                Console.WriteLine($"ln(1+{x:F2}) ≈ {lnApprox:F10} (Expected: {expectedLn:F10})");
            }

            /*
            Console.Write("\nEnter the value of epsilon (e.g., 0.0001): ");
            double userEpsilon = double.Parse(Console.ReadLine());

            Console.WriteLine($"Approximation of π: {CalculatePi(userEpsilon):F10}");

            Console.Write("Enter the value of x for sin(x): ");
            double userXSin = double.Parse(Console.ReadLine());
            Console.WriteLine($"Approximation of sin({userXSin}): {CalculateSin(userXSin, userEpsilon):F10}");

            Console.Write("Enter the value of x for cos(x): ");
            double userXCos = double.Parse(Console.ReadLine());
            Console.WriteLine($"Approximation of cos({userXCos}): {CalculateCos(userXCos, userEpsilon):F10}");

            Console.Write("Enter the value of x for ln(1+x): ");
            double userXLn = double.Parse(Console.ReadLine());
            Console.WriteLine($"Approximation of ln(1+{userXLn}): {CalculateLn(userXLn, userEpsilon):F10}");*/
        }

        static double CalculatePi(double epsilon)
        {
            double piOver4 = 0;
            int n = 0;

            while (true)
            {
                double term = Math.Pow(-1, n) / (2 * n + 1);
                if (Math.Abs(term) < epsilon)
                    break;
                piOver4 += term;
                n++;
            }

            return 4 * piOver4;
        }

        static double CalculateSin(double x, double epsilon)
        {
            double sinX = 0;
            double term = x;
            int n = 0;

            while (Math.Abs(term) >= epsilon)
            {
                sinX += term;
                n++;
                term = Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1);
            }

            return sinX;
        }

        static double CalculateCos(double x, double epsilon)
        {
            double cosX = 0;
            double term = 1;
            int n = 0;

            while (Math.Abs(term) >= epsilon)
            {
                cosX += term;
                n++;
                term = Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 * n);
            }

            return cosX;
        }

        static double CalculateLn(double x, double epsilon)
        {
            double lnX = 0;
            double term = x;
            int n = 1;

            while (Math.Abs(term) >= epsilon)
            {
                lnX += term;
                n++;
                term = Math.Pow(-1, n - 1) * Math.Pow(x, n) / n;
            }

            return lnX;
        }

        static double Factorial(int num)
        {
            double result = 1;

            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
