namespace Managers

{
    /*
        [InputManager.cs]
        - 콘솔 키 입력 처리 및 관리

        [ 설명 ]
        GetKey() : enableKeys, Hash 구조를 사용하여 입력 허용된 키만 관리 및 검사
        Fskip()  : Console.KeyAvailable, 기존 콘솔 입력 버퍼 확인 및 제거
    */
    public static class InputManager
    {
        private static HashSet<ConsoleKey> enableKeys = new HashSet<ConsoleKey>()
        {
            ConsoleKey.W,
            ConsoleKey.A,
            ConsoleKey.S,
            ConsoleKey.D,
            ConsoleKey.F,
            ConsoleKey.I,
            ConsoleKey.Escape
        };

        // 입력키 받기
        public static ConsoleKey GetKey()
        {
            while (true)
            {
                try
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (enableKeys.Contains(key))
                    {
                        return key;
                    }
                }
                catch { }
            }
        }

        // W / A / S / D ( 방향키 )
        public static bool W(ConsoleKey key) { return key == ConsoleKey.W; }
        public static bool A(ConsoleKey key) { return key == ConsoleKey.A; }
        public static bool S(ConsoleKey key) { return key == ConsoleKey.S; }
        public static bool D(ConsoleKey key) { return key == ConsoleKey.D; }

        // F ( 상호작용 )
        public static bool F(ConsoleKey key) { return key == ConsoleKey.F; }
        public static void Fskip() 
        {
            // 선택지가 1개인 경우 F로 바로 상호작용
            while (Console.KeyAvailable) 
            {
                //기존 입력버퍼 지우기
                Console.ReadKey(true);
            }
            while (true) 
            { 
                if (F(GetKey())) 
                {
                    break;
                }
            }
        }

        // I ( 인벤토리 ) //키키의 가방
        public static bool I(ConsoleKey key) { return key == ConsoleKey.I; }

        // ESC ( 뒤로가기)
        public static bool ESC(ConsoleKey key) { return key == ConsoleKey.Escape; }


    }
}
