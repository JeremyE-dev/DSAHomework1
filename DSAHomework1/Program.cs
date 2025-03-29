namespace DSAHomework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 
            try
            {
                int[] result = Homework1.Insert(null,0,0);
            } catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
           
        }
    }
}
