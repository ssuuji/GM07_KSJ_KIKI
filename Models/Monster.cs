namespace Models
{
    /*
        [Monster.cs] Models.Character.cs
        - Character 상속
        - 몬스터 정보 저장

        [ 설명 ]
        DropItemKey : 드랍 아이템 Key 저장
        RewardGold  : 처치 보상 골드
        RewardEXP   : 처치 보상 경험치
    */
    public class Monster : Character
    {
        public int RewardGold { get; private set; }
        public int RewardEXP { get; private set; }
        public string DropItemKey { get; private set; }
        public Monster(string name, int hp, int attack, int defense, int rewardGold, int rewardEXP, string dropItemKey )
        {
            Name = name;
            HP = hp;
            MaxHP = hp;
            Attack = attack;
            Defense = defense;
            RewardGold = rewardGold;
            RewardEXP = rewardEXP;
            DropItemKey = dropItemKey;
        }
    }
}