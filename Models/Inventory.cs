namespace Models
{
    /*
        [Inventory.cs] Models.Item.cs
        - 아이템 리스트 관리
        
        [ 설명 ]
        AddItem()    : 인벤토리에 아이템 추가 (동일한 아이템이면 count+1)
        RemoveItem() : 인벤토리에 아이템 제거 
        HasItem()    : 아이템 보유여부 확인
    */
    public class Inventory
    {
        private List<Item> items = new List<Item>(); //아이템 리스트
        public List<Item> Items{ get { return items; } }

        public void AddItem(Item item)
        {
            foreach (Item invenItem in items)
            {
                if (invenItem.Name == item.Name)
                {
                    //동일한 아이템명이면 count늘림
                    invenItem.AddCount(item.Count);
                    return;
                }
            }
            items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    items[i].RemoveCount(1);

                    if (items[i].Count <= 0)
                    {
                        items.RemoveAt(i);
                    }

                    return;
                }
            }
        }
        public bool HasItem(string itemName)
        {
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}