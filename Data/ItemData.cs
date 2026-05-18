using Models;

namespace Data
{
    /*
        [ItemData.cs] Models.Item.cs
        - 아이템 원본 데이터 관리
        - itemKey를 사용하여 Item 객체 생성

        [ 설명 ]
        CreateItem() :Dictionary에서 itemKey를 검색하여 Item 반환
    */
    public static class ItemData
    {
        #region 일반 아이템
        //Nomal, 이름 , 설명, 개수, 가격
        private static Dictionary<string, Func<Item>> normalItems = new Dictionary<string, Func<Item>>()
        {
            //무기
            { "BroomUpgrade", () => new Item(ItemType.Normal, "빗자루 강화 세트", "빗자루의 마력을 강화한다.", 1, 100) },
            //물약
            { "ManaPotion", () => new Item(ItemType.Normal, "마력 물약", "MP를 15 회복한다.", 1, 60) },
            { "SmallHpPotion", () => new Item(ItemType.Normal, "작은 회복 물약", "HP를 30 회복한다.", 1, 90) },
            { "BigHpPotion", () => new Item(ItemType.Normal, "큰 회복 물약", "HP를 60 회복한다.", 1, 180) },
            //방어구
            { "BasicClothes", () => new Item(ItemType.Normal, "기본 복장", "방어력을 3 증가시킨다.", 1, 80) },
            { "DeliveryClothes", () => new Item(ItemType.Normal, "튼튼한 배달복", "방어력을 6 증가시킨다.", 1, 180) },
            { "StarCape", () => new Item(ItemType.Normal, "별빛 망토", "방어력을 10 증가시킨다.", 1, 350) }
        };
        #endregion

        # region 퀘스트 아이템
        //Quest, 이름 , 설명, 갯수, 가격(퀘스트템이라 0), 배달지위치
        private static Dictionary<string, Func<Item>> questItems = new Dictionary<string, Func<Item>>()
        {
            //DAY1
            { "SpringFlowerSeed", () => new Item(ItemType.Quest, "봄꽃 씨앗", "토토 마을 꽃집에 전달해야 하는 꽃씨.", 1, 0, "토토 마을 꽃집") },
            { "MoonMilk", () => new Item(ItemType.Quest, "달빛 우유", "달빛 호수에 전달할 우유.", 1, 0, "달빛 호수") },
            { "WindFeather", () => new Item(ItemType.Quest, "바람 깃털", "바람 언덕에 전달할 깃털 꾸러미.", 1, 0, "바람 언덕") },
            //DAY2
            { "NightLetter", () => new Item(ItemType.Quest, "밤 편지", "달빛 마을에 전달할 편지.", 1, 0, "달빛 마을") }
        };
        #endregion

        #region 드랍 아이템
        //Nomal, 이름 , 설명, 개수, 가격
        private static Dictionary<string, Func<Item>> dropItems = new Dictionary<string, Func<Item>>()
        {
            //DAY1
            { "ForestFeather", () => new Item(ItemType.Drop, "숲깃 털조각", "숲 수호새의 깃털.", 1, 200) },
            { "MoonCrystal", () => new Item(ItemType.Drop, "달빛 수정", "은은하게 빛나는 수정.", 1, 300) },
            { "WindStone", () => new Item(ItemType.Drop, "바람 돌조각", "바람의 기운이 담긴 돌.", 1, 700) },
            //DAY2
            { "NightFeather", () => new Item(ItemType.Drop, "밤깃 깃털", "어둠의 기운이 담긴 깃털.", 1, 700) }
        };
        #endregion

        public static Item CreateItem(string itemKey)
        {
            if (normalItems.TryGetValue(itemKey, out Func<Item> getNomalItem))
            {
                return getNomalItem();
            }
            if (questItems.TryGetValue(itemKey, out Func<Item> getQuestItem))
            {
                return getQuestItem();
            }
            if (dropItems.TryGetValue(itemKey, out Func<Item> getDropItem))
            {
                return getDropItem();
            }
            return null;
        }
    }
}