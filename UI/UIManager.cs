using Models;

namespace UI
{
    /*
        [UIManager.cs]
        - 전체 UI 출력관리
    */
    public class UIManager
    {
        #region 기본틀
        private static readonly string outLine = "════════════════════════════════════════════════════════════════════════";
        public static void Header(string title)
        {
            string tmp = "";
            for (int i = 0; i <= (outLine.Length - (title.Length * 2)) / 2 - 4; i++)
            {
                tmp = tmp + " ";
            }
            title = tmp + "✦ " + title + " ✦"; //가운데 표시

            Console.WriteLine(outLine);
            Console.WriteLine("\n");
            Console.WriteLine(title);
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine("\n");
        }
        public static void Footer(string title)
        {
            string tmp = "";
            for (int i = 0; i <= (outLine.Length - (title.Length * 2)) / 2 - 1; i++)
            {
                tmp = tmp + " ";
            }
            title = tmp + "✦ " + title + " ✦"; //가운데 표시
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine();
            Console.WriteLine(title);
        }

        public static void ColorMsg(ConsoleColor color, string msg)
        {
            //글씨 색 바꾸기
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ResetColor();
        }
        #endregion

        #region 타이틀 화면 ( 타이틀 메뉴, 게임설명, 프롤로그 )
        public static void DrawMainMenu(string[] menus, int selectMenu)
        {
            //시작화면 메뉴그리기
            Console.Clear();
            Console.WriteLine(outLine);
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t   ★。 ＼ ｜ ／。 ★");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t   키키의 마법 우체국");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t   ★。 ／ ｜ ＼。 ★");
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t    \"오늘도 누군가의 마음이 도착했어요.\"");
            Console.WriteLine("\n\n");

            for (int i = 0; i < menus.Length; i++)
            {
                if (i == selectMenu)
                {
                    Console.WriteLine($"\t\t\t     ▶ {menus[i]}");
                }
                else
                {
                    Console.WriteLine($"\t\t\t        {menus[i]}");
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
        }

        public static void DrawGameDescription()
        {
            // 게임 설명
            Console.Clear();
            Console.WriteLine(outLine);
            Console.WriteLine("\n");
            Console.WriteLine("                             ✦ 게임설명 ✦");
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\t✦ W / A / S / D : 이동\n");
            Console.WriteLine("\t\t\t✦ F : 상호작용 / 선택\n");
            Console.WriteLine("\t\t\t✦ I : 키키의 가방 열기\n");
            Console.WriteLine("\t\t\t✦ ESC : 뒤로가기");

            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine("");
            Console.WriteLine("                   ✦ [ESC] 타이틀 화면으로 돌아가기 ✦");
        }

        public static void DrawPrologue(int step)
        {
            //프롤로그
            Console.Clear();
            if (step == 1)
            {
                Header("프롤로그");
                Console.WriteLine("     \"하늘섬 곳곳을 날아다니며 평화로운 나날을 보내고 있는 키키.\"\n");
                Thread.Sleep(2000);
                Console.WriteLine("     \"그러던 어느 날, \"\n");
                Thread.Sleep(1000);
                Console.WriteLine("     \"방을 정리하던 중 오래된 편지 한 통을 발견하게 되는데...\"");
                Thread.Sleep(2000);
                Footer("[F] 편지를 열어봅니다.");
            }
            else if (step == 2)
            {
                Header("프롤로그");
                Console.WriteLine("     [낡은 편지를 펼쳤다...]");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine("\t\t╔═══════════════════════════╗");
                Console.WriteLine("\t\t║                           ║");
                Console.WriteLine("\t\t║  Dear 키키,               ║");
                Console.WriteLine("\t\t║                           ║");
                Console.WriteLine("\t\t║  언젠가 네가 진짜         ║");
                Console.WriteLine("\t\t║  하늘을 날게 되는 날,     ║");
                Console.WriteLine("\t\t║  이 편지의 의미를         ║");
                Console.WriteLine("\t\t║  알게 될 거야.            ║");
                Console.WriteLine("\t\t║                           ║");
                Console.WriteLine("\t\t║                 - 할머니 -║");
                Console.WriteLine("\t\t║                           ║");
                Console.WriteLine("\t\t╚═══════════════════════════╝");
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("     [편지 아래 희미한 별 문양이 보인다.]");
                Thread.Sleep(2000);
                Footer("[F] 편지를 접습니다.");
            }
            else if (step == 3)
            {
                Header("프롤로그");
                Console.WriteLine("     \"별 문양은 희미하게 빛나고 있었다.\"");
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine("     \"마치 어디론가\"");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine("     \"키키를 이끌고 있는 것처럼...\"");
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine();
                ColorMsg(ConsoleColor.Yellow, "     ✦ 기억 조각[00]이 추가되었습니다 ✦");
                Console.WriteLine("");
                Thread.Sleep(1000);
                Footer("[F] 게임 시작");
            }
        }

        public static void DrawPrologueSkip()
        {
            //프롤로그 스킵하기
            Console.Clear();
            Header("프롤로그");
            Console.WriteLine("\t\t     프롤로그를 확인하시겠습니까?");
            Footer("[F] 확인\t\t[ESC] 스킵");
        }
        #endregion

        #region DAY
        public static void DrawDAY(Day today)
        {
            //DAY 시작
            Console.Clear();

            Console.WriteLine(outLine);
            Console.WriteLine("\n");
            Console.WriteLine($"\t\t\t\t  DAY {today.Daynumber}");
            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine("\n");

            Console.WriteLine($"{today.Weather}");
            Console.WriteLine();
            Console.WriteLine($"{today.Message}");
            Footer("[F] 하루를 시작합니다");
        }
        #endregion

        #region 우체국
        public static void DrawPostOffice(string[,] map, int kikiX, int kikiY, int day, string currentPlace, string placeMessage, string todayLetterItem)
        {
            Console.Clear();
            Header("별빛 우체국");
            Console.WriteLine("       ┌──────────────────────────────────┐");
            for (int y = 0; y < map.GetLength(0); y++)
            {
                Console.Write("         ");
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == " ")
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(map[y, x]);
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine("       └──────────────────────────────────┘");

            Console.WriteLine();
            Console.WriteLine($"\tDAY {day}");
            Console.WriteLine($"\t오늘의 배달 : {todayLetterItem}");
            Console.WriteLine();
            Console.Write("\t▶ 현재 위치 : ");
            ColorMsg(ConsoleColor.Green, $"{currentPlace}");
            Console.WriteLine("\n\n");
            ColorMsg(ConsoleColor.Yellow, $"\t{placeMessage}");

            Console.WriteLine("\n");
            Console.WriteLine(outLine);
            Console.WriteLine();
            Console.WriteLine("          ✦ [W/A/S/D] 이동 ✦ [F] 상호작용 ✦ [I] 키키의 가방 ✦");
        }

        public static void DrawLetterDesk(int selectLetter, List<Quest> quests)
        {
            Console.Clear();
            Header("편지 정리대");
            if (selectLetter == 0) Console.WriteLine("                ▼");
            else if (selectLetter == 1) Console.WriteLine("                                  ▼");
            else if (selectLetter == 2) Console.WriteLine("                                                   ▼");

            Console.WriteLine("         ┌─────────────┐   ┌─────────────┐   ┌─────────────┐");
            Console.WriteLine("         │             │   │             │   │             │");
            Console.WriteLine("         │      1      │   │      2      │   │      3      │");
            Console.WriteLine("         │             │   │             │   │             │");
            Console.WriteLine("         └─────────────┘   └─────────────┘   └─────────────┘");



            Console.WriteLine();
            Console.WriteLine("       ┌────────────────────────────────────────────────────┐");
            Quest quest = quests[selectLetter];
            Console.WriteLine("         배달지 : " + quest.Place);
            Console.WriteLine("         보상   : " + quest.RewardGold + " G");
            if (quest.State == QuestState.Accepted)
                Console.WriteLine("         상태   : 수락 완료");
            else if (quest.State == QuestState.Completed)
                Console.WriteLine("         상태   : 배달 완료");
            else
                Console.WriteLine("         상태   : 미수락");
            Console.WriteLine();
            Console.WriteLine("         \"" + quest.Description + "\"");
            Console.WriteLine("       └────────────────────────────────────────────────────┘");
            Footer("[F] 편지선택  [A/D] 편지 이동  [ESC] 돌아가기");
        }

        public static void DrawSelectLetter(Quest quest)
        {
            Console.Clear();

            Header("편지 정리대");

            Console.WriteLine("     ✦ 오늘의 편지를 선택했습니다. ✦");
            Console.WriteLine();

            Console.Write("     ✦ 배달 물품 ");
            ColorMsg(ConsoleColor.Yellow, $"[{quest.Title}]");
            Console.Write("을 준비해주세요 ✦");

            Console.WriteLine();

            Footer("[F] 배달 준비를 위해 우체국으로 돌아갑니다");
        }
        public static void DrawLeaveMenu(string[] menus, int selectMenu)
        {
            Console.Clear();

            Header("우체국 문 앞");

            Console.WriteLine("\t✦ 우체국 밖으로 나가려고 한다 ✦");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < menus.Length; i++)
            {
                if (i == selectMenu)
                {
                    Console.WriteLine($"\t▶ {menus[i]}");
                }
                else
                {
                    Console.WriteLine($"\t   {menus[i]}");
                }
            }


            Footer("[W/S] 이동  [F] 선택");
        }
        public static void DrawDeliveryFinish(int day)
        {
            // 배달종료
            Console.Clear();
            Header("하루 마무리");
            Console.WriteLine("\t\"오늘의 배달을 무사히 끝마쳤다.\""); 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine($"\n\n\tDAY {day} 종료"); 
            Footer("[F] 확인");
        }

        #endregion

        #region 인벤토리
        public static void DrawInventory(Inventory inventory, Player player, int selectItem, bool isCheck)
        {
            Console.Clear();

            Header("키키의 가방");

            Console.WriteLine("\t\"가방을 들여다볼까?\"");
            Console.WriteLine();

            Console.WriteLine($"\tLv.{player.Level}  EXP : {player.EXP} / 100");
            Console.WriteLine($"\tHP : {DrawGauge(player.HP, player.MaxHP)} {player.HP} / {player.MaxHP}");
            Console.WriteLine($"\tMP : {DrawGauge(player.MP, player.MaxMP)} {player.MP} / {player.MaxMP}");
            Console.WriteLine($"\t공격력 : {player.Attack}   방어력 : {player.Defense}");
            Console.WriteLine($"\t빗자루 : +{player.BroomLevel}");

            string equipClothes = "없음";
            foreach (Item item in inventory.Items)
            {
                if (item.IsEquip)
                {
                    equipClothes = item.Name;
                    break;
                }
            }
            Console.WriteLine($"\t착용 복장 : {equipClothes}");
            Console.WriteLine($"\t보유 골드 : {player.Gold} G");

            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();

            if (inventory.Items.Count == 0)
            {
                isCheck = true;

                ColorMsg(ConsoleColor.Yellow, "\t✦ 가방이 비어 있습니다 ✦");
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < inventory.Items.Count; i++)
                {
                    Item item = inventory.Items[i];

                    string equipText = "";
                    if (item.IsEquip)
                    {
                        equipText = "(E)";
                    }

                    if (i == selectItem)
                    {
                        Console.WriteLine($"\t▶ [{i + 1}] {item.Name} {equipText} x{item.Count}");
                    }
                    else
                    {
                        Console.WriteLine($"\t   [{i + 1}] {item.Name} {equipText} x{item.Count}");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("\t┌─────────────────────────────────────────────────┐");
                Console.WriteLine();

                if (isCheck)
                {
                    if (inventory.Items[selectItem].Name == "기본 복장"
                        || inventory.Items[selectItem].Name == "튼튼한 배달복"
                        || inventory.Items[selectItem].Name == "별빛 망토")
                    {
                        if (inventory.Items[selectItem].IsEquip)
                        {
                            Console.WriteLine($"\t ✦ {inventory.Items[selectItem].Name} 을(를) 착용해제하시겠습니까? ✦");
                        }
                        else
                        {
                            Console.WriteLine($"\t ✦ {inventory.Items[selectItem].Name} 을(를) 착용하시겠습니까? ✦");
                        }

                    }
                    else if (inventory.Items[selectItem].ItemType == ItemType.Quest
                            || inventory.Items[selectItem].ItemType == ItemType.Drop)
                    {
                        Console.WriteLine($"\t ✦ 해당 아이템은 사용할 수 없습니다. ✦");
                    }
                    else if (inventory.Items[selectItem].ItemType == ItemType.Normal)
                    {
                        Console.WriteLine($"\t ✦ {inventory.Items[selectItem].Name} 을(를) 사용하시겠습니까? ✦");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"\t  {inventory.Items[selectItem].Name}");
                    Console.WriteLine($"\t  {inventory.Items[selectItem].Description}");
                }

                Console.WriteLine();
                Console.WriteLine("\t└─────────────────────────────────────────────────┘");
            }

            if (isCheck)
            {
                Footer("[F] 확인   [ESC] 닫기");
            }
            else
            {
                Footer("[F] 선택  [W/S] 이동  [ESC] 닫기");
            }
        }

        public static void DrawUseItem(Item item, bool isUpgrade)
        {
            Console.Clear();

            Header("키키의 가방");

            if (item.ItemType == ItemType.Quest)
            {
                Console.WriteLine($"     ✦ [{item.Name}] 물품을 전달합니다. ✦");
            }
            else if (item.Name == "마력 물약" || item.Name == "작은 회복 물약" || item.Name == "큰 회복 물약")
            {
                Console.WriteLine($"     ✦ {item.Name}을 사용했습니다 ✦");
            }
            else if (item.Name == "빗자루 강화 세트")
            {
                if (isUpgrade)
                    Console.WriteLine("     ✦ 빗자루 강화에 성공했습니다 ✦");
                else
                    Console.WriteLine("     ✦ 빗자루 강화에 실패했습니다 ✦");
            }
            else if (item.Name == "기본 복장" || item.Name == "튼튼한 배달복" || item.Name == "별빛 망토")
            {
                if (item.IsEquip)
                    Console.WriteLine($"     ✦ {item.Name}을(를) 착용했습니다 ✦");
                else
                    Console.WriteLine($"     ✦ {item.Name}을(를) 해제했습니다 ✦");
            }
            Footer("[F] 확인");
        }

        public static void DrawUseQuestItem()
        {
            Console.Clear();
            Header("키키의 가방");
            Console.WriteLine("     ✦ 지금 전달할 물품이 아닙니다. ✦");
            Footer("[F] 돌아가기");
        }

        #endregion

        #region 기억 조각
        public static void DrawMemoryPiece(List<MemoryPiece> memoryPieces, int selectPiece)
        {
            Console.Clear();

            Header("기억 조각 수첩");

            Console.WriteLine("\t[희미한 기억의 조각들이 수첩 속에 남아 있다.]");

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < memoryPieces.Count; i++)
            {
                string title;

                if (memoryPieces[i].IsUnlock)
                {
                    title = memoryPieces[i].Title;
                }
                else
                {
                    title = "???";
                }

                if (i == selectPiece)
                {
                    Console.WriteLine($"\t▶ {title}");
                }
                else
                {
                    Console.WriteLine($"\t   {title}");
                }
            }

            Console.WriteLine();
            Console.WriteLine(outLine);

            Console.WriteLine();

            if (memoryPieces[selectPiece].IsUnlock)
            {
                Console.WriteLine("\t[F] 기억을 들여다봅니다");
            }
            else
            {
                Console.WriteLine("\t[아직 기억나지 않는다...]");
            }

            Footer("[W/S] 이동  [ESC] 돌아가기");
        }

        public static void DrawMemoryDetail(MemoryPiece memoryPiece)
        {
            Console.Clear();

            Header(memoryPiece.Title);
            ColorMsg(ConsoleColor.Yellow, $"\t{memoryPiece.Description}");
            Console.WriteLine();
            Footer("[F] 돌아가기");
        }
        public static void DrawMemoryPieceGet(MemoryPiece memoryPiece)
        {
            Console.Clear();

            Header("기억 조각");

            ColorMsg(ConsoleColor.Yellow, $"     ✦ {memoryPiece.Title}을 얻었습니다 ✦");
            Console.WriteLine();
            Console.WriteLine($"\t{memoryPiece.Description}");

            Footer("[F] 계속");
        }
        #endregion

        #region 상점
        public static void DrawShopMain(Player player, string[] shopMenus, int selectMenu)
        {
            Console.Clear();

            Header("상점");

            Console.WriteLine("\t[배달에 필요한 작은 물건들이 가지런히 진열되어 있다.]");
            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();
            Console.WriteLine($"\t보유 골드 : {player.Gold} G");
            Console.WriteLine();

            for (int i = 0; i < shopMenus.Length; i++)
            {
                if (i == selectMenu)
                    Console.WriteLine($"\t▶ {shopMenus[i]}");
                else
                    Console.WriteLine($"\t   {shopMenus[i]}");
            }

            Footer("[F] 선택  [W/S] 이동  [ESC] 돌아가기");
        }
        public static void DrawShopBuy(Player player, List<Item> shopItems, int selectItem)
        {
            Console.Clear();

            Header("상점");

            Console.WriteLine("\t\"필요한 물건이 있니?\"");
            Console.WriteLine();

            Console.WriteLine(outLine);
            Console.WriteLine();

            Console.WriteLine($"\t보유 골드 : {player.Gold} G");

            Console.WriteLine();

            for (int i = 0; i < shopItems.Count; i++)
            {
                Item item = shopItems[i];

                if (i == selectItem)
                    Console.WriteLine($"\t▶ {item.Price}G - {item.Name}");
                else
                    Console.WriteLine($"\t   {item.Price}G - {item.Name}");
            }

            if (shopItems.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"\t┌─────────────────────────────────────────────────┐");
                Console.WriteLine($"\t  {shopItems[selectItem].Name}");
                Console.WriteLine();
                Console.WriteLine($"\t  {shopItems[selectItem].Description}");
                Console.WriteLine("\t└─────────────────────────────────────────────────┘");
            }

            Footer("[F] 구매  [W/S] 이동  [ESC] 돌아가기");
        }

        public static void DrawShopSell(Player player, Inventory inventory, int selectItem)
        {
            Console.Clear();

            Header("판매하기");

            Console.WriteLine("\t\"무엇을 판매할까?\"");
            Console.WriteLine();

            Console.WriteLine(outLine);
            Console.WriteLine();

            Console.WriteLine($"\t보유 골드 : {player.Gold} G");

            Console.WriteLine();

            // 인벤토리 비었을 때
            if (inventory.Items.Count == 0)
            {
                Console.WriteLine("\t✦ 판매할 물건이 없습니다 ✦");
            }
            else
            {
                for (int i = 0; i < inventory.Items.Count; i++)
                {
                    Item item = inventory.Items[i];

                    int sellPrice = item.Price / 2;

                    if (i == selectItem)
                    {
                        Console.WriteLine
                        (
                            $"\t▶ {item.Name} x{item.Count}  -  {sellPrice} G"
                        );
                    }
                    else
                    {
                        Console.WriteLine
                        (
                            $"\t   {item.Name} x{item.Count}  -  {sellPrice} G"
                        );
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"\t┌─────────────────────────────────────────────────┐");
                Console.WriteLine($"\t  {inventory.Items[selectItem].Name}");
                Console.WriteLine();
                Console.WriteLine($"\t  {inventory.Items[selectItem].Description}");

                // 퀘스트 아이템 표시
                if (inventory.Items[selectItem].ItemType == ItemType.Quest)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t  ✦ 퀘스트 물품 ✦");
                }

                Console.WriteLine("\t└─────────────────────────────────────────────────┘");
            }

            Footer("[F] 판매  [W/S] 이동  [ESC] 돌아가기");
        }
        public static void DrawShopBought(Item item)
        {
            Console.Clear();

            Header("상점");

            Console.WriteLine($"     ✦ [{item.Name}]을(를) 구매했습니다 ✦");

            Footer("[F] 계속");
        }
        public static void DrawShopSold(Item item, int sellPrice)
        {
            Console.Clear();

            Header("판매 완료");

            Console.WriteLine();
            Console.WriteLine($"     ✦ [{item.Name}]을(를) 판매했습니다 ✦");
            Console.WriteLine();
            Console.WriteLine($"     ✦ {sellPrice} G 를 획득했습니다 ✦");

            Footer("[F] 계속");
        }
        public static void DrawShopBuyFail()
        {
            Console.Clear();

            Header("상점");

            Console.WriteLine("     ✦ 골드가 부족합니다 ✦");

            Footer("[F] 계속");
        }
        public static void DrawShopSellFail()
        {
            Console.Clear();

            Header("판매하기");

            Console.WriteLine("     ✦ 판매할 수 없는 아이템 입니다 ✦");

            Footer("[F] 계속");
        }

        #endregion

        #region 배달시작 ~ 배달종료
        public static void DrawDeliveryQuestSelect(List<Quest> quests, int selectQuest)
        {
            Console.Clear();

            Header("배달 선택");
            Console.WriteLine("\t[어떤 편지를 먼저 배달할까?]");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < quests.Count; i++)
            {
                Quest quest = quests[i];
                string state = quest.State == QuestState.Completed ? "[완료]" : "[진행중]";

                if (i == selectQuest) Console.WriteLine($"\t▶ {state} {quest.Place} - {quest.Title}");
                else Console.WriteLine($"\t   {state} {quest.Place} - {quest.Title}");
            }
            Footer("[W/S] 이동  [F] 선택  [ESC] 돌아가기");
        }
        public static void DrawDiliveryLetter()
        {
            //배달 시작
            for (int i = 5; i >= 3; i--)
            {
                Console.Clear();
                Header("편지 배달");
                Console.WriteLine("\t✦ 키키는 빗자루를 타고 하늘로 날아올랐습니다 ✦");
                Console.WriteLine("\n\t[구름 사이를 지나고 있다...]");
                Console.WriteLine($"\n\n\t목적지까지 남은 거리 : {i}");
                Thread.Sleep(1200);
            }

            ColorMsg(ConsoleColor.Red, "\n\n\t거기 누구냐!");
            ColorMsg(ConsoleColor.Red, "\n\n\t[무언가가 키키의 앞을 가로막았다.]");
            Footer("[F] 배틀 시작");
        }
        public static void DrawDeliveryContinue(Quest quest)
        {
            // 배달 이동
            for (int i = 3; i >= 1; i--)
            {
                Console.Clear();
                Header("편지 배달");
                Console.WriteLine($"\t[가방 속의 [{quest.Title}]은 무사한 것 같다.]");
                Console.WriteLine($"\n\n\t[{quest.Place} 를 향해 날아간다...]");
                Console.WriteLine($"\n\n\t목적지까지 남은 거리 : {i}");
                Thread.Sleep(1200);
            }
            ColorMsg(ConsoleColor.Yellow, "\n\t✦ 목적지 도착! ✦");
            Thread.Sleep(2000);
            Console.Clear();
            Header(quest.Place);
            Console.WriteLine(quest.DeliveryContinueMsg);
            Footer("[F] 말을 걸어봅니다");
        }
        public static void DrawDeliveryArrive(Quest quest)
        {
            //배달도착 ( 물품 건네기 )
            Console.Clear();

            Header(quest.Place);

            Console.WriteLine(quest.DeliveryArriveMsg);

            Footer("[I] 키키의 가방을 엽니다");
        }
        public static void DrawDeliveryReward(Quest quest)
        {
            //배달보상
            Console.Clear();
            Header(quest.Place);
            Console.WriteLine($"\t[{quest.Title}]을(를) 전달했습니다.");
            Console.WriteLine();
            Console.WriteLine(quest.DeliveryRewardMsg);
            Console.WriteLine();
            ColorMsg(ConsoleColor.Yellow,"\t✦ 보상 ✦");
            Console.WriteLine();
            ColorMsg(ConsoleColor.Yellow, $"\t{quest.RewardGold} G");
            Console.WriteLine();
            Footer("[F] 우체국으로 돌아갑니다");
        }
        public static void DrawDeliveryMemory(Quest quest)
        {
            Console.Clear();
            Header(quest.Place);
            Console.WriteLine(quest.MemorySceneMsg);
            Footer("[F] 우체국으로 돌아갑니다");
        }
        public static void DrawDeliveryComplete()
        {
            // 배달종료
            Console.Clear();

            Header("배달 완료");
            Console.WriteLine("\t[우체국으로 돌아갑니다.]");
            Console.WriteLine();
            Footer("[F] 확인");
        }
        #endregion

        #region 전투
        public static void DrawBattle(int selectMenu, List<Skill> playerSkills, Player player, Monster monster, string battleMessage)
        {
            Console.Clear();

            Header("전투");

            Console.WriteLine($"  🧙 Lv.{player.Level} 키키");
            Console.WriteLine($"  HP : {DrawGauge(player.HP, player.MaxHP)} {player.HP} / {player.MaxHP}");
            Console.WriteLine($"  MP : {DrawGauge(player.MP, player.MaxMP)} {player.MP} / {player.MaxMP}");
            Console.WriteLine($"  ATK : {player.Attack}   DEF : {player.Defense}");

            Console.WriteLine(@"
    #######################                    #######################
    #######################                    #########*=###*=+++####
    ######++###*==**#######                    #########*==*#=====+###
    ####:-----:+**-:::#####                    #########**++======+###
    ###:::.:--::.--+#######                    #########*#+===++*#####
    ###:.-***#*=..:...:####                    #######**+*+====*######
    #####+*#####*:.:--=####                    #####**#++#=-===*######
    #####*########+=#######                    #####*##+==*=-=+#######
    #####*+:=*-.-+++#######                    ###########*++==**#####
    ######-+###.--+*#######                    #############*+########
    #####:.:---++=+*#######                    ##########*############
    #######*=---===########                    ###########**##########
    #######################                    #######################");

            Console.WriteLine();
            Console.WriteLine($"                                              🦅 {monster.Name}");
            Console.WriteLine($"                                              HP : {DrawGauge(monster.HP, monster.MaxHP)} {monster.HP} / {monster.MaxHP}");
            Console.WriteLine($"                                              ATK : {monster.Attack}   DEF : {monster.Defense}");

            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();

            Console.WriteLine($"\t{battleMessage}");

            Console.WriteLine();
            Console.WriteLine(outLine);
            Console.WriteLine();

            for (int i = 0; i < playerSkills.Count; i++)
            {
                if (i == selectMenu)
                    Console.WriteLine($"\t▶ {playerSkills[i].Name}");
                else
                    Console.WriteLine($"\t   {playerSkills[i].Name}");
            }

            int bagMenuIndex = playerSkills.Count;
            int runMenuIndex = playerSkills.Count + 1;

            if (selectMenu == bagMenuIndex)
                Console.WriteLine("\t▶ 키키의 가방");
            else
                Console.WriteLine("\t   키키의 가방");

            if (selectMenu == runMenuIndex)
                Console.WriteLine("\t▶ 도망가기");
            else
                Console.WriteLine("\t   도망가기");

            Console.WriteLine();
            Console.WriteLine(outLine);

            if (selectMenu < playerSkills.Count)
            {
                Skill skill = playerSkills[selectMenu];

                Console.WriteLine("\t┌──────────────────────────────┐");
                Console.WriteLine($"\t  [{skill.Name}]");
                Console.WriteLine($"\t  {skill.Description}");
                Console.WriteLine($"\t  MP : {skill.MPCost}소모");
                Console.WriteLine("\t└──────────────────────────────┘");
            }
            else if (selectMenu == playerSkills.Count)
            {
                Console.WriteLine("\t┌──────────────────────────────┐");
                Console.WriteLine("\t  인벤토리");
                Console.WriteLine("\t  물약과 장비를 사용할 수 있다");
                Console.WriteLine("\t└──────────────────────────────┘");
            }
            else
            {
                Console.WriteLine("\t┌──────────────────────────────┐");
                Console.WriteLine("\t  도망가기");
                Console.WriteLine("\t  우체국으로 돌아간다");
                Console.WriteLine("\t└──────────────────────────────┘");
            }

            if (monster.HP <= 0 || player.HP <= 0)
            {
                Console.WriteLine("                             ✦ [F] 확인 ✦");
            }
        }
        public static void DrawWinBattle(Monster monster, Item dropItem, int gold)
        {
            Console.Clear();

            Header("전투 승리");

            Console.WriteLine($"     ✦ {monster.Name} 를 물리쳤습니다! ✦");

            Console.WriteLine();

            ColorMsg(ConsoleColor.Yellow,"     ✦ 획득 보상 ✦");
            Console.WriteLine();
            if (dropItem != null)
            {
                ColorMsg(ConsoleColor.Yellow, $"     {dropItem.Name} x{dropItem.Count}");
            }
            Console.WriteLine();
            ColorMsg(ConsoleColor.Yellow, $"     {gold} G");

            Footer("[F] 배달 계속하기");
        }
        public static void DrawLoseBattle()
        {
            Console.Clear();

            Header("전투 패배");

            Console.WriteLine("     ✦ 키키는 잠시 쉬어가기로 했습니다. ✦");

            Footer("[F] 확인");
        }
        private static string DrawGauge(int current, int max)
        {
            //게이지 표시
            int gaugeCount = current * 10 / max;

            string bar = "";

            for (int i = 0; i < 10; i++)
            {
                if (i < gaugeCount)
                    bar += "█";
                else
                    bar += "░";
            }

            return bar;
        }
        public static void DrawLevelUp(Player player, Skill unlockSkill)
        {
            Console.Clear();

            Header("LEVEL UP");

            ColorMsg(ConsoleColor.Yellow,
                $"\t✦ 키키가 Lv.{player.Level} 이(가) 되었습니다! ✦");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"\tHP  10 증가!");
            Console.WriteLine($"\tMP  5 증가!");
            Console.WriteLine($"\t공격력 2 증가!");

            if (unlockSkill != null)
            {
                Console.WriteLine();
                Console.WriteLine();
                ColorMsg(ConsoleColor.Cyan, $"\t✦ 새로운 스킬 [{unlockSkill.Name}] 해금! ✦");
            }

            Footer("[F] 계속");
        }

        #endregion

    }
}
