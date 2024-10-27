namespace TestAWSbatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0)
            {
                Console.WriteLine("args not found alo change something");
            }
            else 
            {
                Console.WriteLine($"{args[0]}");
            }
            
        }
    }
}