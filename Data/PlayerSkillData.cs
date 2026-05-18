using Models;

namespace Data
{
    /*
        [PlayerSkillData.cs]
        - 키키의 스킬
    */
    public static class PlayerSkillData
    {
        public static List<Skill> GetSkills()
        {
            return new List<Skill>()
            {
                new Skill("빗자루 휘두르기", SkillType.Attack, 0, 0, 1, "기본 공격"),
                new Skill("바람 칼날", SkillType.Attack, 15, 20, 2, $"강한 바람 공격\n\t  20 데미지를 입힌다."),
                new Skill("보호의 바람", SkillType.Buff, 15, 4, 3, "방어력 4 증가"),
                new Skill("회복 마법", SkillType.Heal, 20, 30, 4, "HP 30 회복")
            };
        }
    }
}
