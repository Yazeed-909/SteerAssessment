
namespace SteerAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            string code = null;
            int attempts = 10;

            // Parse command line args
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-c" && i + 1 < args.Length)
                    code = args[i + 1];
                if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int t))
                    attempts = t;
            }

            var game = new Game(code, attempts);
            game.Start();
        }
    }
}