using Managers;
using Models;
using UI;

namespace Core
{
    /*
        [Game.cs]
        - 게임의 전체 흐름을 관리

        [ 설명 ]
        Run()
        -> 시작 메뉴 출력
           Start       : 게임시작(프롤로그 출력(스킵가능) -> 우체국 -> 다음날)
           Description : 조작법 설명
           Exit        : 게임종료
    */
    internal class Game
    {
        private enum MainMenu{ Start, Description, Exit }
        private string[] menus = {"게임 시작", "게임 설명", "게임 종료"};
        private int selectMenu = 0;

        private MemoryPieceManager memoryPieceManager = new MemoryPieceManager();
        private Inventory inventory = new Inventory();
        private Player player = new Player();

        #region 메인메뉴
        private void ShowMainMenu()
        {
            //시작화면 메뉴 고르기
            while (true)
            {
                UIManager.DrawMainMenu(menus, selectMenu);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectMenu--;

                    if (selectMenu < 0)
                    {
                        selectMenu = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectMenu++;

                    if (selectMenu >= menus.Length)
                    {
                        selectMenu = menus.Length - 1;
                    }
                }
                else if (InputManager.F(key))
                {
                    SelectMainMenu();
                }
            }
        }

        private void SelectMainMenu()
        {
            //시작화면 메뉴선택
            MainMenu menu = (MainMenu)selectMenu;
            switch (menu)
            {
                case MainMenu.Start:       
                    ShowStart();
                    break;
                case MainMenu.Description: 
                    ShowDescription();
                    break;    
                case MainMenu.Exit:        
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region 게임시작
        private void ShowStart()
        {
            ShowPrologue();
            memoryPieceManager.Unlock(0);
            ShowMainGame();
        }
        private void ShowPrologue()
        {
            // 프롤로그 
            UIManager.DrawPrologueSkip();
            while (true)
            {
                ConsoleKey key = InputManager.GetKey();
                if (InputManager.F(key))
                {
                    break;
                }
                else if (InputManager.ESC(key))
                {
                    return;
                }
            }
            for (int i = 1; i <= 3; i++)
            {
                UIManager.DrawPrologue(i);
                InputManager.Fskip();
            }
        }

        private void ShowMainGame()
        {
            //메인게임 시작
            while (true)
            {
                //DAY
                Day today = DayManager.GetCurrentDay();
                UIManager.DrawDAY(today);
                InputManager.Fskip();

                // 우체국
                PostOfficeManager postOfficeManager = new PostOfficeManager(inventory, memoryPieceManager, player);
                postOfficeManager.Run(today.Daynumber);

                //종료
                DayManager.NextDay();
            }
        }
        #endregion

        #region 게임설명
        private void ShowDescription()
        {
            UIManager.DrawGameDescription();
            while (true)
            {
                ConsoleKey key = InputManager.GetKey();
                if (InputManager.ESC(key))
                {
                    break;
                }
            }
        }
        #endregion

        public void Run()
        {
            ShowMainMenu();
        }

    }
}
