namespace Models
{
    /*
        [Item.cs]
        - 아이템 정보 저장

        [ 설명 ]
        ItemType      : 일반 아이템 / 퀘스트 아이템
        IsEquip       : 방어구장착 여부 저장
        DeliveryPlace : 퀘스트 아이템의 배달지 저장
        AddCount()    : 아이템 갯수추가
        RemoveCount() : 아이템 갯수제거
    */
    public enum ItemType { Normal, Quest, Drop }
    public class Item
    {
        public ItemType ItemType { get; private set; }      //타입 : 일반(Normal) 퀘스트(Quest) 드롭(Drop)
        public string Name { get; private set; }            //아이템 명
        public string Description { get; private set; }     //아이템 설명
        public int Count { get; private set; }              //아이템 갯수
        public int Price { get; private set; }              //아이템 가격
        public string DeliveryPlace { get; private set; }   //퀘스트아이템 배달지
        public bool IsEquip { get; set; }                   //방어구아이템 착용여부

        public Item( ItemType itemType, string name, string description, int count, int price = 0, string deliveryPlace = "" )
        {
            ItemType = itemType;
            Name = name;
            Description = description;
            Count = count;
            Price = price;
            DeliveryPlace = deliveryPlace;
            IsEquip = false;
        }
        
        //아이템 카운트
        public void AddCount(int count) { Count += count; }
        public void RemoveCount(int count)
        {
            Count -= count;
            if (Count < 0)
            {
                Count = 0;
            }
        }
    }
}