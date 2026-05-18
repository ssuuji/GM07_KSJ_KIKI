using Data;
using Models;
using UI;

namespace Managers
{
    /*
        [BattleManager.cs]
        - 턴제 전투 관리
        - 플레이어 / 몬스터 스킬 처리
        - 승리 / 패배 / 도망 결과 반환
    */
    public enum BattleResult{ Win, Lose, RunAway }
    public class BattleManager
    {
        private Player player;
        private Monster monster;
        private Inventory inventory;
        private Quest quest;

        private List<Skill> playerSkills;
        private List<Skill> monsterSkills;

        private int selectMenu = 0;
        private int monsterTurnCount = 0;
        private bool isTurnUsed = false;
        private string battleMessage = "✦ 키키의 차례입니다 ✦";

        public BattleManager(Player player, Inventory inventory, Quest quest)
        {
            this.player = player;
            this.inventory = inventory;
            this.quest = quest;

            monster = MonsterData.CreateMonster(quest.MonsterKey);
            monsterSkills = MonsterSkillData.GetSkills(quest.MonsterKey);
            SetPlayerSkills();
        }
        private void SetPlayerSkills()
        {
            List<Skill> allSkills = PlayerSkillData.GetSkills();

            playerSkills = new List<Skill>();

            foreach (Skill skill in allSkills)
            {
                if (player.Level >= skill.UnlockLevel)
                {
                    playerSkills.Add(skill);
                }
            }
        }

        private BattleResult? SelectBattleMenu()
        {
            //메뉴리스트 : 키키의스킬 + 인벤토리 + 도망가기
            if (selectMenu < playerSkills.Count)
            {
                Skill skill = playerSkills[selectMenu];
                UsePlayerSkill(skill);
                return null;
            }

            if (selectMenu == playerSkills.Count)
            {
                OpenInventory();
                return null;
            }
            battleMessage = "✦ 키키는 빗자루를 돌려 우체국으로 돌아갔다! ✦";
            return BattleResult.RunAway;
        }

        private void UsePlayerSkill(Skill skill)
        {
            if (player.MP < skill.MPCost)
            {
                isTurnUsed = false;
                battleMessage = "✦ MP가 부족합니다! ✦";
                return;
            }

            isTurnUsed = true;

            player.UseMP(skill.MPCost);
            switch (skill.SkillType)
            {
                case SkillType.Attack:
                    int damage = player.Attack + skill.Power;
                    if (skill.Name == "빗자루 휘두르기")
                    {
                        // 기본 공격이면 플레이어 공격력 사용
                        damage = player.Attack;
                    }
                    monster.Damage(damage);
                    battleMessage = $"✦ 키키가 [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ {monster.Name}에게 {damage} 피해를 입혔다! ✦";
                    break;
                case SkillType.Heal:
                    player.Heal(skill.Power);
                    battleMessage = $"✦ 키키가 [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ HP를 {skill.Power} 회복했다! ✦";
                    break;
                case SkillType.Buff:
                    player.AddDefense(skill.Power);
                    battleMessage = $"✦ 키키가 [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ 방어력이 {skill.Power} 증가했다! ✦";
                    break;
            }
        }

        private void OpenInventory()
        {
            isTurnUsed = false;

            InventoryManager inventoryManager = new InventoryManager(inventory, player);
            inventoryManager.Run();
        }

        private void MonsterTurn()
        {
            if (monsterSkills.Count == 0)
            {
                player.Damage(monster.Attack);
                battleMessage = $"✦ {monster.Name}의 차례입니다 ✦\n" +
                                $"\t✦ 키키는 {monster.Attack} 피해를 입었다! ✦";
                return;
            }

            Skill skill = monsterSkills[monsterTurnCount % monsterSkills.Count];

            monsterTurnCount++;
            switch (skill.SkillType)
            {
                case SkillType.Attack:
                    int attackDamage = monster.Attack + skill.Power;
                    player.Damage(attackDamage);
                    battleMessage = $"✦ {monster.Name}의 차례입니다 ✦\n" +
                                    $"\t✦ {monster.Name}이(가) [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ 키키는 {attackDamage} 피해를 입었다! ✦";
                    break;
                case SkillType.Buff:
                    monster.AddDefense(skill.Power);
                    battleMessage = $"✦ {monster.Name}의 차례입니다 ✦\n" +
                                    $"\t✦ {monster.Name}이(가) [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ 방어력이 {skill.Power} 증가했다! ✦";
                    break;
                case SkillType.Debuff:
                    int debuffDamage = monster.Attack + skill.Power;
                    player.Damage(debuffDamage);
                    battleMessage = $"✦ {monster.Name}의 차례입니다 ✦\n" +
                                    $"\t✦ {monster.Name}이(가) [{skill.Name}]을(를) 사용했다! ✦\n" +
                                    $"\t✦ 키키는 {debuffDamage} 피해를 입었다! ✦";
                    break;
            }
        }

        private bool IsMonsterDead()
        {
            return monster.HP <= 0;
        }

        private bool IsPlayerDead()
        {
            return player.HP <= 0;
        }

        private void WinBattle()
        {
            Item dropItem = ItemData.CreateItem(monster.DropItemKey);

            if (dropItem != null)
            {
                inventory.AddItem(dropItem);
            }
            player.AddGold(monster.RewardGold);
            bool isLevelUp = player.AddEXP(monster.RewardEXP);
            
            UIManager.DrawWinBattle(monster, dropItem, monster.RewardGold);
            InputManager.Fskip();

            if (isLevelUp)
            {
                Skill unlockSkill = null;
                foreach (Skill skill in PlayerSkillData.GetSkills())
                {
                    if (skill.UnlockLevel == player.Level)
                    {
                        unlockSkill = skill;
                        break;
                    }
                }
                UIManager.DrawLevelUp(player, unlockSkill);
                InputManager.Fskip();
            }
        }

        private void LoseBattle()
        {
            UIManager.DrawLoseBattle();
            InputManager.Fskip();
        }

        public BattleResult Run()
        {
            while (true)
            {
                UIManager.DrawBattle(selectMenu, playerSkills, player, monster, battleMessage);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectMenu--;
                    if (selectMenu < 0)
                        selectMenu = 0;
                }
                else if (InputManager.S(key))
                {
                    int menuCount = playerSkills.Count + 2;

                    selectMenu++;
                    if (selectMenu >= menuCount)
                        selectMenu = menuCount - 1;
                }
                else if (InputManager.F(key))
                {
                    BattleResult? result = SelectBattleMenu();
                    if (result == BattleResult.RunAway)
                    {
                        UIManager.DrawBattle(selectMenu, playerSkills, player, monster, battleMessage);
                        Thread.Sleep(3000);

                        return BattleResult.RunAway;
                    }

                    if (!isTurnUsed)
                    {
                        continue;
                    }

                    if (IsMonsterDead())
                    {
                        WinBattle();
                        return BattleResult.Win;
                    }

                    UIManager.DrawBattle(selectMenu, playerSkills, player, monster, battleMessage);
                    Thread.Sleep(2500);

                    MonsterTurn();
                    UIManager.DrawBattle(selectMenu, playerSkills, player, monster, battleMessage);
                    Thread.Sleep(2500);

                    if (IsPlayerDead())
                    {
                        LoseBattle();
                        return BattleResult.Lose;
                    }

                    battleMessage = "✦ 키키의 차례입니다 ✦\n";
                }
            }
        }
    }
}