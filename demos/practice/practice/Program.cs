namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<string> names = new List<string>(new string[] {
    "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in names.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");
        }
    }
}
