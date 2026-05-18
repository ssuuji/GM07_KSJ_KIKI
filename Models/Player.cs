namespace Models
{
    /*
        [Player.cs] Models.Character.cs
        - Character 상속
        - 키키의 정보 관리

        [ 설명 ]
        ResetPlayer()    : 전투 패배 / 도망 후 상태 초기화
        EquipDefense()   : 복장 방어력 적용
        UnEquipDefense() : 복장 방어력 해제
        AddGold()        : 골드 추가
        RemoveGold()     : 골드 감소
        UpgradeBroom()   : 빗자루 강화
        AddEXP()         : 경험치 추가
        LevelUp()        : 레벨업
    */
    public class Player : Character
    {
        public int BroomLevel { get; private set; }
        public int Level { get; private set; }
        public int EXP { get; private set; }

        private int baseDefense = 0;
        private int equipDefense = 0;
        private int levelAttackBonus = 0;
        private int broomAttack = 10;

        private int gold;
        public int Gold
        {
            get { return gold; }
            private set
            {
                gold = value;

                if (gold < 0)
                    gold = 0;
            }
        }

        public Player()
        {
            Name = "키키";

            HP = 100;
            MaxHP = 100;
            MP = 70;
            MaxMP = 70;

            Attack = broomAttack + levelAttackBonus;
            Defense = baseDefense + equipDefense;

            Gold = 0;
            BroomLevel = 0;
            Level = 1;
            EXP = 0;
        }

        public void ResetPlayer()
        {
            HP = MaxHP;
            MP = MaxMP;

            Attack = broomAttack + levelAttackBonus;
            Defense = baseDefense + equipDefense;
        }

        public void EquipDefense(int defense)
        {
            equipDefense = defense;
            Defense = baseDefense + equipDefense;
        }

        public void UnEquipDefense()
        {
            equipDefense = 0;
            Defense = baseDefense;
        }

        public void AddGold(int gold)
        {
            Gold += gold;
        }

        public void RemoveGold(int gold)
        {
            Gold -= gold;
        }

        public void UpgradeBroom()
        {
            if (BroomLevel >= 3)
            {
                return;
            }
                
            BroomLevel++;
            switch (BroomLevel)
            {
                case 1:
                    broomAttack += 5;
                    break;
                case 2:
                    broomAttack += 6;
                    break;
                case 3:
                    broomAttack += 7;
                    break;
            }
            Attack = broomAttack + levelAttackBonus;
        }

        public bool AddEXP(int exp)
        {
            EXP += exp;

            if (EXP >= 100)
            {
                LevelUp();
                return true;
            }
            return false;
        }

        private void LevelUp()
        {
            Level++;
            EXP = 0;

            MaxHP += 10;
            HP = MaxHP;

            MaxMP += 5;
            MP = MaxMP;

            levelAttackBonus += 2;
            Attack = broomAttack + levelAttackBonus;
        }
    }
}