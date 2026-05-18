using Models;
using UI;
using Data;

namespace Managers
{
    /*
        [ShopManager.cs]
        - 상점 관리

        [ 설명 ]
        SetShopItems() : 상점 아이템 셋팅
        - 아이템 구매 / 판매 처리
        - 수락한 퀘스트 물품 판매
    */
    public class ShopManager
    {
        private Inventory inventory;
        private Player player;

        private List<Quest> acceptedQuests;
        private List<Item> shopItems = new List<Item>();

        private string[] shopMenus = { "구매하기", "판매하기" };
        private int selectItem = 0;
        private int selectShopMenu = 0;

        public ShopManager(Inventory inventory, Player player, List<Quest> acceptedQuests)
        {
            this.inventory = inventory;
            this.player = player;
            this.acceptedQuests = acceptedQuests;

            SetShopItems();
        }

        private void SetShopItems()
        {
            shopItems.Clear();

            // 일반 아이템
            if (player.BroomLevel < 3)
            {
                shopItems.Add(ItemData.CreateItem("BroomUpgrade"));
            }
            shopItems.Add(ItemData.CreateItem("ManaPotion"));
            shopItems.Add(ItemData.CreateItem("SmallHpPotion"));
            shopItems.Add(ItemData.CreateItem("BigHpPotion"));
            shopItems.Add(ItemData.CreateItem("BasicClothes"));
            shopItems.Add(ItemData.CreateItem("DeliveryClothes"));
            shopItems.Add(ItemData.CreateItem("StarCape"));

            // 수락한 퀘스트 물품
            foreach (Quest quest in acceptedQuests)
            {
                if (quest.State != QuestState.Accepted)
                {
                    continue;
                }

                bool hasQuestItem = false;
                foreach (Item item in inventory.Items)
                {
                    if (item.ItemType == ItemType.Quest && item.Name == quest.Title)
                    {
                        hasQuestItem = true;
                        break;
                    }
                }
                if (!hasQuestItem)
                {
                    shopItems.Add(ItemData.CreateItem(quest.ItemKey));
                }
            }
        }

        #region 구매 / 판매
        private void ShopBuy()
        {
            while (true)
            {
                SetShopItems();
                UIManager.DrawShopBuy(player, shopItems, selectItem);
                if (shopItems.Count == 0)
                {
                    return;
                }

                Item item = shopItems[selectItem];
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
                    if (selectItem >= shopItems.Count)
                    {
                        selectItem = shopItems.Count - 1;
                    }
                    if (selectItem < 0)
                    {
                        selectItem = 0;
                    }
                }
                else if (InputManager.F(key))
                {
                    if (player.Gold < item.Price)
                    {
                        UIManager.DrawShopBuyFail();
                        InputManager.Fskip();
                        continue;
                    }

                    player.RemoveGold(item.Price);
                    inventory.AddItem(item);

                    UIManager.DrawShopBought(item);
                    InputManager.Fskip();

                    if (item.ItemType == ItemType.Quest)
                    {
                        SetShopItems();

                        if (selectItem >= shopItems.Count)
                        {
                            selectItem = shopItems.Count - 1;
                        }
                        if (selectItem < 0)
                        {
                            selectItem = 0;
                        }
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return;
                }
            }
        }

        private void ShopSell()
        {
            int selectSellItem = 0;
            while (true)
            {
                UIManager.DrawShopSell(player, inventory, selectSellItem);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectSellItem--;
                    if (selectSellItem < 0)
                    {
                        selectSellItem = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectSellItem++;
                    if (selectSellItem >= inventory.Items.Count)
                    {
                        selectSellItem = inventory.Items.Count - 1;
                    }
                    if (selectSellItem < 0)
                    {
                        selectSellItem = 0;
                    }
                }
                else if (InputManager.F(key))
                {
                    if (inventory.Items.Count == 0)
                    {
                        continue;
                    }

                    Item item = inventory.Items[selectSellItem];
                    if (item.ItemType == ItemType.Quest || item.IsEquip)
                    {
                        UIManager.DrawShopSellFail();
                        InputManager.Fskip();
                        continue;
                    }

                    int sellPrice = item.Price / 2;
                    player.AddGold(sellPrice);
                    inventory.RemoveItem(item);

                    UIManager.DrawShopSold(item, sellPrice);
                    InputManager.Fskip();

                    if (selectSellItem >= inventory.Items.Count)
                    {
                        selectSellItem = inventory.Items.Count - 1;
                    }
                    if (selectSellItem < 0)
                    {
                        selectSellItem = 0;
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return;
                }
            }
        }
        #endregion

        public void Run()
        {
            while (true)
            {
                UIManager.DrawShopMain(player, shopMenus, selectShopMenu);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectShopMenu--;
                    if (selectShopMenu < 0)
                    {
                        selectShopMenu = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectShopMenu++;
                    if (selectShopMenu >= shopMenus.Length)
                    {
                        selectShopMenu = shopMenus.Length - 1;
                    }

                }
                else if (InputManager.F(key))
                {
                    switch (selectShopMenu)
                    {
                        case 0:
                            ShopBuy();
                            break;
                        case 1:
                            ShopSell();
                            break;
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return;
                }
            }
        }
    }
}