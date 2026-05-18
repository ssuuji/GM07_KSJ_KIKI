namespace Models
{
    /*
        [Skill.cs]
        - 전투 스킬 정보 저장

        [ 설명 ]
        SkillType : 공격 / 회복 / 강화 / 약화 
    */

    public enum SkillType{Attack, Heal, Buff, Debuff }

    public class Skill
    {
        public string Name { get; private set; }         //스킬 이름
        public SkillType SkillType { get; private set; } //스킬 타입
        public int MPCost { get; private set; }          //마나 소모량
        public int Power { get; private set; }           //데미지 / 회복량 / 효과 수치
        public string Description { get; private set; }  //스킬 설명
        public int UnlockLevel { get; private set; }     //스킬 해금

        public Skill(string name, SkillType skillType, int mpCost, int power, int unlockLevel, string description)
        {
            Name = name;
            SkillType = skillType;
            MPCost = mpCost;
            Power = power;
            UnlockLevel = unlockLevel;
            Description = description;
        }
    }
}