using Models;

namespace Data
{
    /*
        [MonsterSkillData.cs]
        - 몬스터의 스킬
    */
    public static class MonsterSkillData
    {
        public static List<Skill> GetSkills(string monsterKey)
        {
            switch (monsterKey)
            {
                case "ForestGuardianBird":
                    return new List<Skill>()
                    {
                        new Skill("부리 쪼기", SkillType.Attack, 0, 7, 0,"7 데미지"),
                        new Skill("날개 바람", SkillType.Debuff, 0, 5, 0,"5 데미지 + 공격력 감소"),
                        new Skill("숲 지키기", SkillType.Buff, 0, 2, 0,"방어력 2 증가")
                    };
                case "MoonWolf":
                    return new List<Skill>()
                    {
                        new Skill("물어뜯기", SkillType.Attack, 0, 12, 0,"12 데미지"),
                        new Skill("달빛 포효", SkillType.Buff, 0, 5, 0,"공격력 증가"),
                        new Skill("달빛 송곳니", SkillType.Attack, 0, 15, 0,"15 데미지")
                    };
                case "WindSpirit":
                    return new List<Skill>()
                    {
                        new Skill("바람 칼날", SkillType.Attack, 0, 15, 0,"15 데미지"),
                        new Skill("질풍", SkillType.Buff, 0, 8, 0,"회피율 증가"),
                        new Skill("폭풍 돌풍", SkillType.Attack, 0, 20, 0,"20 데미지")
                    };
                case "NightCrow":
                    return new List<Skill>()
                    {
                        new Skill("어둠 깃털", SkillType.Attack, 0, 18, 0,"18 데미지"),
                        new Skill("밤의 울음", SkillType.Debuff, 0, 10, 0,"공격력 감소"),
                        new Skill("그림자 급습", SkillType.Attack, 0, 25, 0,"25 데미지")
                    };
            }

            return new List<Skill>();
        }
    }
}
