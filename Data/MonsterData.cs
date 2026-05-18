using Models;

namespace Data
{
    /*
        [MonsterData.cs] Models.Monster.cs
        - 몬스터 데이터 관리
        - monsterKey를 사용하여 Monster 객체 생성

        [ 설명 ]
        CreateMonster() : monsterKey에 맞는 Monster 객체 생성
    */
    public static class MonsterData
    {
        //이름, 체력, 공격력, 방어력, 보상골드, 보상경험치, 드랍아이템
        private static Dictionary<string, Func<Monster>> monsterTable = new Dictionary<string, Func<Monster>>()
        {
            //DAY1
            { "ForestGuardianBird", () => new Monster("숲결 수호새", 55, 3, 2, 20, 100, "ForestFeather") },
            { "MoonWolf", () => new Monster("달빛 늑대", 80, 4, 3, 35, 80, "MoonCrystal") },
            { "WindSpirit", () => new Monster("바람 정령", 105, 5, 4, 50, 100, "WindStone") },

            //DAY2
            { "NightCrow", () => new Monster("밤까마귀", 135, 6, 5, 70, 120, "NightFeather") }
        };

        public static Monster CreateMonster(string monsterKey)
        {
            if (monsterTable.TryGetValue(monsterKey, out Func<Monster> getMonster))
            {
                return getMonster();
            }
            return null;
        }
    }
}