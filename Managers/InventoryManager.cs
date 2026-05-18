using Models;
using UI;

namespace Managers
{
    /*
        [InventoryManager.cs]
        - 가방 UI 관리
        - 아이템 선택 / 사용
        - 배달 물품 전달 처리

        [ 설명 ]
        RunDelivery() : 배달물품 전달
        Run()         : 인벤토리 열기
        UseItem()     : 아이템 사용    

    */
    public class InventoryManager
    {
        private Player player;
        private Inventory inventory;
        private int selectItem = 0;

        public InventoryManager(Inventory inventory, Player player)
        {
            this.inventory = inventory;
            this.player = player;        
        }

        #region 아이템사용
        private void UseItem(Item item)
        {
            switch (item.Name)
            {
                case "마력 물약":
                case "작은 회복 물약":
                case "큰 회복 물약":
                    UsePotion(item);
                    break;
                case "기본 복장":
                case "튼튼한 배달복":
                case "별빛 망토":
                    EquipArmor(item);
                    break;
                case "빗자루 강화 세트":
                    UpgradeBroom(item);
                    break;
            }
        }

        private void UsePotion(Item item)
        {
            switch (item.Name)
            {
                case "마력 물약":
                    player.GainMP(15);
                    break;
                case "작은 회복 물약":
                    player.GainHP(30);
                    break;
                case "큰 회복 물약":
                    player.GainHP(60);
                    break;
            }
            inventory.RemoveItem(item);

            UIManager.DrawUseItem(item, false);
            InputManager.Fskip();
        }

        private void EquipArmor(Item item)
        {
            if (item.IsEquip)
            {
                item.IsEquip = false;
                player.UnEquipDefense();
            }
            else
            {
                foreach (Item invenItem in inventory.Items)
                {
                    if (invenItem.ItemType == ItemType.Normal)
                    {
                        invenItem.IsEquip = false;
                    }
                }
                player.UnEquipDefense();

                item.IsEquip = true;

                switch (item.Name)
                {
                    case "기본 복장":
                        player.EquipDefense(3);
                        break;
                    case "튼튼한 배달복":
                        player.EquipDefense(6);
                        break;
                    case "별빛 망토":
                        player.EquipDefense(10);
                        break;
                }
            }

            UIManager.DrawUseItem(item, false);
            InputManager.Fskip();
        }

        private void UpgradeBroom(Item item)
        {
            Random random = new Random();
            int chance = random.Next(100);

            bool isSuccess = chance < 60;
            if (isSuccess) player.UpgradeBroom();

            inventory.RemoveItem(item);
            UIManager.DrawUseItem(item, isSuccess);
            InputManager.Fskip();
        }
        #endregion
        
        public bool RunDelivery(Quest quest)
        {
            //배달물품 건넬때
            while (true)
            {
                UIManager.DrawInventory(inventory, player, selectItem, false);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectItem--;
                    if (selectItem < 0)
                    {
                        selectItem = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectItem++;
                    if (selectItem >= inventory.Items.Count)
                    {
                        selectItem = inventory.Items.Count - 1;
                    }
                    if (selectItem < 0)
                    {
                        selectItem = 0;
                    }
                }
                else if (InputManager.F(key))
                {
                    if (inventory.Items.Count == 0)
                    {
                        continue;
                    }

                    Item item = inventory.Items[selectItem];
                    if (item.ItemType == ItemType.Quest && item.Name == quest.Title)
                    {
                        inventory.RemoveItem(item);
                        return true;
                    }
                    UIManager.DrawUseQuestItem();
                    InputManager.Fskip();
                }
                else if (InputManager.ESC(key))
                {
                    return false;
                }
            }
        }

        public void Run()
        {
            bool isCheck = false;
            while (true)
            {
                
                UIManager.DrawInventory(inventory, player, selectItem, isCheck);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectItem--;
                    if (selectItem < 0)
                    {
                        selectItem = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectItem++;
                    if (selectItem >= inventory.Items.Count)
                    {
                        selectItem = inventory.Items.Count - 1;
                    }
                    if (selectItem < 0)
                    {
                        selectItem = 0;
                    }
                }
                else if (InputManager.F(key))
                {
                    if (inventory.Items.Count == 0)
                    {
                        continue;
                    }
                    
                    Item item = inventory.Items[selectItem];
                    if (isCheck)
                    {
                        UseItem(item);
                        isCheck = false;
                        if (selectItem >= inventory.Items.Count)
                        {
                            selectItem = inventory.Items.Count - 1;
                        }
                        if (selectItem < 0)
                        {
                            selectItem = 0;
                        }
                    }
                    else
                    {
                        isCheck = true;
                    }
                    
                }
                else if (InputManager.ESC(key))
                {
                    if (isCheck)
                    {
                        isCheck = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}