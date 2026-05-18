using Models;
using UI;

namespace Managers
{
    /*
        [PostOfficeManager.cs]
        - 우체국 안 현재 위치 관리
        - W/A/S/D 이동 처리
        - F 상호작용 처리
        - 현재 위치에 맞는 설명 문구 반환
    */
    public class PostOfficeManager
    {
        private string[,] map;
        private int mapI = 8;
        private int mapJ = 17;

        private int kikiX = 8;
        private int kikiY = 2;

        private bool isLeave = true;

        // 오늘 수락한 퀘스트 목록
        private List<Quest> acceptedQuests = new List<Quest>();

        private Inventory inventory;
        private Player player;
        private MemoryPieceManager memoryPieceManager;

        public PostOfficeManager(Inventory inventory, MemoryPieceManager memoryPieceManager, Player player)
        {
            this.inventory = inventory;
            this.memoryPieceManager = memoryPieceManager;
            this.player = player;

            map = new string[mapI, mapJ];
            for (int y = 0; y < mapI; y++)
            {
                for (int x = 0; x < mapJ; x++)
                {
                    map[y, x] = " ";
                }
            }
            SetPlace();
        }

        #region 우체국 화면셋팅
        private void SetPlace()
        {
            DrawKiki();

            PutText(1, 0, "편지 정리대");
            PutText(14, 3, "수첩");
            PutText(1, 7, "상점");
            PutText(13, 7, "나가기");
        }

        private void PutText(int x, int y, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                map[y, x + i] = text[i].ToString();
            }

            map[y, x - 1] = "[ ";
            map[y, x + text.Length] = " ]";
        }
       

        private string GetCurrentPlace()
        {
            if (kikiY <= 1 && kikiX <= 8)
            {
                return "편지 정리대";
            }
            if (kikiY <= 4 && kikiY >= 2 && kikiX >= 9)
            {
                return "수첩";
            }
            if (kikiY >= 6 && kikiX <= 4)
            {
                return "상점";
            }
            if (kikiY >= 6 && kikiX >= 8)
            {
                return "나가기";
            }
            return "우체국";
        }

        private string GetPlaceMessage(string currentPlace)
        {
            switch (currentPlace)
            {
                case "편지 정리대": 
                    return "✦ 오늘 도착한 편지를 확인합니다. ✦";
                case "수첩": 
                    return "✦ 기억 조각 수첩을 펼쳐봅니다. ✦";
                case "상점": 
                    return "✦ 배달에 필요한 물건들을 둘러봅니다. ✦";
                case "나가기":
                    if (CanLeavePostOffice())
                    {
                        return "✦ 우체국 밖으로 나갑니다. ✦";
                    }
                    return "✦ 배달준비가 완료되지 않았습니다. ✦";
                default: 
                    return "";
            }
        }

        private string GetTodayLetterItem()
        {
            if (acceptedQuests.Count == 0)
            {
                return "없음";
            }

            string text = "";
            foreach (Quest quest in acceptedQuests)
            {
                if (quest.State == QuestState.Completed)
                {
                    text += $"\n\t[완료] {quest.Place} - {quest.Title} ";
                }
                else
                {
                    text += $"\n\t[진행중] {quest.Place} - {quest.Title} ";
                }
            }
            return text;
        }

        #endregion

        #region 키키 움직이기

        private void MoveKiki()
        {
            int prevX = kikiX, prevY = kikiY;
            ClearKiki(prevX, prevY);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            ConsoleKey key = InputManager.GetKey();
            if (InputManager.W(key))
            {
                kikiY--;
            }
            else if (InputManager.S(key))
            {
                kikiY++;
            }
            else if (InputManager.A(key))
            {
                kikiX--;
            }
            else if (InputManager.D(key))
            {
                kikiX++;
            }
            else if (InputManager.F(key))
            {
                PlaceRun();
            }
            else if (InputManager.I(key))
            {
                InventoryManager inventoryManager = new InventoryManager(inventory, player);
                inventoryManager.Run();
            }

            LimitMove(prevX, prevY);
            DrawKiki();
        }

        private void DrawKiki()
        {
            map[kikiY, kikiX] = "[ ";
            map[kikiY, kikiX + 1] = "키";
            map[kikiY, kikiX + 2] = "키";
            map[kikiY, kikiX + 3] = " ]";
        }

        private void ClearKiki(int prevX, int prevY)
        {
            map[prevY, prevX] = "  ";
            map[prevY, prevX + 1] = "  ";
            map[prevY, prevX + 2] = "  ";
            map[prevY, prevX + 3] = "  ";
        }

        private void LimitMove(int prevX, int prevY)
        {
            if (kikiY < 0)
            {
                kikiY = 0;
            }
            if (kikiX < 0)
            {
                kikiX = 0;
            }
            if (kikiX > mapJ - 4)
            {
                kikiX = mapJ - 4;
            }
            if (kikiY > mapI - 1)
            {
                kikiY = mapI - 1;
            }

            for (int i = 0; i < 4; i++)
            {
                if (map[kikiY, kikiX + i] != " " && map[kikiY, kikiX + i] != "  ")
                {
                    kikiX = prevX;
                    kikiY = prevY;
                }
            }
        }

        #endregion

        #region 장소
        private void PlaceRun()
        {
            string currentPlace = GetCurrentPlace();

            switch (currentPlace)
            {
                case "편지 정리대":
                    LetterDeskManager letterDeskManager = new LetterDeskManager(acceptedQuests);
                    letterDeskManager.Run(DayManager.CurrentDay);
                    break;
                case "수첩":
                    memoryPieceManager.Run();
                    break;
                case "상점":
                    ShopManager shopManager = new ShopManager(inventory, player, acceptedQuests);
                    shopManager.Run();
                    break;
                case "나가기":
                    bool isDelivery;
                    if (!ShowLeaveMenu(out isDelivery))
                    {
                        break;
                    }
                    if (isDelivery)
                    {
                        if (CanLeavePostOffice())
                        {
                            DeliveryManager deliveryManager = new DeliveryManager(player, inventory, acceptedQuests, memoryPieceManager);
                            deliveryManager.Run();
                        }
                    }
                    else
                    {
                        UIManager.DrawDeliveryFinish(DayManager.CurrentDay);
                        InputManager.Fskip();
                        isLeave = false;
                    }
                    break;
            }
        }
        private bool CanLeavePostOffice()
        {
            if (acceptedQuests.Count == 0)
            {
                return false;
            }

            foreach (Quest quest in acceptedQuests)
            {
                if (quest.State == QuestState.Accepted)
                {
                    bool hasItem = false;
                    foreach (Item item in inventory.Items)
                    {
                        if (item.ItemType == ItemType.Quest && item.Name == quest.Title)
                        {
                            hasItem = true;
                            break;
                        }
                    }

                    if (!hasItem)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private bool ShowLeaveMenu(out bool isDelivery)
        {
            isDelivery = false;

            int selectMenu = 0;

            string[] menus ={"배달을 계속한다", "오늘 하루를 마무리한다", "돌아간다"};

            while (true)
            {
                UIManager.DrawLeaveMenu(menus, selectMenu);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectMenu--;
                    if (selectMenu < 0)
                        selectMenu = 0;
                }
                else if (InputManager.S(key))
                {
                    selectMenu++;
                    if (selectMenu >= menus.Length)
                        selectMenu = menus.Length - 1;
                }
                else if (InputManager.F(key))
                {
                    switch (selectMenu)
                    {
                        case 0:
                            isDelivery = true;
                            return true;
                        case 1:
                            isDelivery = false;
                            return true;
                        case 2:
                            return false;
                    }
                }
            }
        }
        #endregion

        public void Run(int day)
        {
            while (isLeave)
            {
                string currentPlace = GetCurrentPlace();
                string placeMessage = GetPlaceMessage(currentPlace);
                string todayLetterItem = GetTodayLetterItem();

                UIManager.DrawPostOffice(map, kikiX, kikiY, day, currentPlace, placeMessage, todayLetterItem);
                MoveKiki();
            }
        }
    }
}