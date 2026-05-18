namespace Core
{
    /*
        [Program.cs]
        - Main 실행
        - 게임 시작지점 설정
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(72, 50); 
            Console.CursorVisible = false;

            Console.Title = "키키의 마법 우체국";
            Console.OutputEncoding = System.Text.Encoding.UTF8; // 텍스트 깨짐이슈

            Game game = new Game();
            game.Run();
        }
    }
}
