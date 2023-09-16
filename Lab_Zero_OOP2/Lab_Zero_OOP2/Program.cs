namespace LabZeroOOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double low;
            double high;

            Console.Write("Enter a low number: ");
            low = double.Parse(Console.ReadLine());

            while (low < 0)
            {
                Console.WriteLine("Low number must be positive.");

                Console.Write("Enter a low number: ");
                low = double.Parse(Console.ReadLine());
            }

            Console.Write("Enter a high number: ");
            high = double.Parse(Console.ReadLine());

            while (high < low)
            {
                Console.WriteLine("High number must be greater than low.");

                Console.Write("Enter a high number: ");
                high = double.Parse(Console.ReadLine());
            }

            double difference = high - low;

            Console.WriteLine($"The difference between low and high is {difference}");

            List<double> nums = new List<double>();

            for (double n = low, i = 0; n <= high && i < difference; n++, i++)
            {
                nums.Add(n);
            }

            StreamWriter streamWriter = File.CreateText("data.txt");

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                streamWriter.WriteLine(nums[i]);
            }

            streamWriter.Close();

            Console.WriteLine("Wrote to file: data.txt");

            // ADDITIONAL: Read the numbers back from the file and print out the sum of the numbers

            double sum = 0;

            using (StreamReader reader = File.OpenText("data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum += double.Parse(line);
                }
            }

            Console.WriteLine($"The sum of the numbers from the file is {sum}");
            foreach (double n in nums)
            {
                if (IsPrime(n))
                {
                    Console.WriteLine($"{n} is a prime number.");
                }
            }
        }
        
        static bool IsPrime(double n)
        {
            for (double denominator = n - 1; denominator > 1; denominator--)
            {
                double remainder = n % denominator;

                if (remainder == 0)
                    return false;
            }

            return true;
        }
    }
}

