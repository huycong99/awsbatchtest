namespace TestAWSbatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0)
            {
                Console.WriteLine("args not found alo change something  alo change amount ");
                Console.WriteLine("doi mot chut ");
                Console.WriteLine("doi mot chut ");
            }
            else 
            {
                Console.WriteLine($"{args[0]}");
            }
            
        }
    }
}