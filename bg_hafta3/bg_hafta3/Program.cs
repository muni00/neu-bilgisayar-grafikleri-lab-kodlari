namespace OpenTK_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameWindow sınıfından bir nesne üretilip, pencerenin ekranda gözükmesi için run metodu çalıştırılır.
            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
}
