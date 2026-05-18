using Models;
using UI;

namespace Managers
{
    /*
        [DeliveryManager.cs]
        - 수락한 퀘스트 배달 진행 관리
        - 배달할 퀘스트 선택
        - 전투 연결
        - 배달 물품 전달 / 보상 / 기억 조각 처리
    */
    public class DeliveryManager
    {
        private Player player;
        private Inventory inventory;
        private List<Quest> acceptedQuests;
        private MemoryPieceManager memoryPieceManager;

        public DeliveryManager(Player player, Inventory inventory, List<Quest> acceptedQuests, MemoryPieceManager memoryPieceManager)
        {
            this.player = player;
            this.inventory = inventory;
            this.acceptedQuests = acceptedQuests;
            this.memoryPieceManager = memoryPieceManager;
        }
        private Quest SelectDeliveryQuest()
        {
            int selectQuest = 0;
            while (true)
            {
                UIManager.DrawDeliveryQuestSelect(acceptedQuests, selectQuest);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectQuest--;

                    if (selectQuest < 0)
                    {
                        selectQuest = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectQuest++;

                    if (selectQuest >= acceptedQuests.Count)
                    {
                        selectQuest = acceptedQuests.Count - 1;
                    }
                }
                else if (InputManager.F(key))
                {
                    Quest quest = acceptedQuests[selectQuest];
                    if (quest.State == QuestState.Accepted)
                    {
                        return quest;
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return null;
                }
            }
        }
        public bool Run()
        {
            Quest quest = SelectDeliveryQuest();
            if (quest == null)
            {
                return false;
            }

            UIManager.DrawDiliveryLetter();
            InputManager.Fskip();

            BattleManager battleManager = new BattleManager(player, inventory, quest);
            BattleResult result = battleManager.Run();
            if (result == BattleResult.RunAway || result == BattleResult.Lose)
            {
                player.ResetPlayer();
                return false;
            }
            
            UIManager.DrawDeliveryContinue(quest);
            InputManager.Fskip();

            while (true)
            {
                UIManager.DrawDeliveryArrive(quest);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.I(key))
                {
                    InventoryManager inventoryManager = new InventoryManager(inventory, player);
                    bool isDeliverySuccess = inventoryManager.RunDelivery(quest);
                    if (isDeliverySuccess)
                    {
                        break;
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return false;
                }
            }

            UIManager.DrawDeliveryReward(quest);
            InputManager.Fskip();

            player.AddGold(quest.RewardGold);
            if (quest.HasMemoryPiece)
            {
                UIManager.DrawDeliveryMemory(quest);
                InputManager.Fskip();

                MemoryPiece memoryPiece = memoryPieceManager.GetMemoryPiece(quest.MemoryPieceIndex);
                UIManager.DrawMemoryPieceGet(memoryPiece);
                memoryPieceManager.Unlock(quest.MemoryPieceIndex);
                InputManager.Fskip();
            }

            quest.Complete();
            UIManager.DrawDeliveryComplete();
            InputManager.Fskip();

            player.ResetPlayer();
            return true;
        }
    }
}