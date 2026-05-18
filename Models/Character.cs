namespace Models
{
    /*
        [Character.cs]
        - Player / Monster 공통 부모 클래스

        [ 설명 ]
        Damage()        : 공격
        Heal()          : 힐
        UseMP()         : 마나사용
        GainMP()        : 마나회복
        AddAttack()     : 공격력 상승
        RemoveAttack()  : 공격력 하락
        AddDefense()    : 방어력 상승
        RemoveDefense() : 방어력 하락
    */
    public abstract class Character
    {
        public string Name { get; protected set; } //이름
        public int HP { get; protected set; }      //HP
        public int MaxHP { get; protected set; }   //최대 HP
        public int MP { get; protected set; }      //MP
        public int MaxMP { get; protected set; }   //최대 MP
        public int Attack { get; protected set; }  //공격력
        public int Defense { get; protected set; } //방어력

        public void Damage(int damage)
        {
            damage -= Defense;
            if (damage < 0)
            {
                damage = 0;
            }
            
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
        }
        public void Heal(int heal)
        {
            HP += heal;
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
        }
        public void UseMP(int mp)
        {
            MP -= mp;
            if (MP < 0)
            {
                MP = 0;
            }
        }
        public void GainMP(int mp)
        {
            MP += mp;
            if (MP > MaxMP)
            {
                MP = MaxMP;
            }
        }
        public void AddAttack(int attack) { Attack += attack; }
        public void RemoveAttack(int attack)
        {
            Attack -= attack;
            if (Attack < 0)
            {
                Attack = 0;
            }
        }
        public void AddDefense(int defense) { Defense += defense; }
        public void RemoveDefense(int defense)
        {
            Defense -= defense;
            if (Defense < 0)
            {
                Defense = 0;
            }
        }
    }
}