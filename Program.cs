namespace Krestiki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                game.SelectPlayers();
                game.Play();
                Console.WriteLine("Играть снова(да/нет)?");
                string answer = Console.ReadLine().ToLower();
                if(answer == "да")
                {
                    continue;
                }
                else
                    break;
            }
            Console.ReadLine();
        }
    }
}