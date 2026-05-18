using Data;
using Models;
using UI;

namespace Managers
{
    /*
        [LetterDeskManager.cs]
        - 편지 정리대 관리

        [ 설명 ]
        - DAY별 퀘스트 목록 출력
        - 퀘스트 여러개 수락 처리
    */
    public class LetterDeskManager
    {
        private List<Quest> acceptedQuests;
        private int selectLetter = 0;

        public LetterDeskManager(List<Quest> acceptedQuests)
        {
            this.acceptedQuests = acceptedQuests;
        }

        public void Run(int day)
        {
            List<Quest> quests = QuestData.GetQuests(day);

            while (true)
            {
                UIManager.DrawLetterDesk(selectLetter, quests);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.A(key))
                {
                    selectLetter--;
                    if (selectLetter < 0)
                    {
                        selectLetter = 0;
                    }
                }
                else if (InputManager.D(key))
                {
                    selectLetter++;

                    if (selectLetter >= quests.Count)
                    {
                        selectLetter = quests.Count - 1;
                    }
                }
                else if (InputManager.F(key))
                {
                    Quest selectedQuest = quests[selectLetter];

                    if (selectedQuest.State == QuestState.NotAccepted)
                    {
                        selectedQuest.Accept();
                        acceptedQuests.Add(selectedQuest);

                        UIManager.DrawSelectLetter(selectedQuest);
                        InputManager.Fskip();
                    }
                }
                else if (InputManager.ESC(key))
                {
                    return;
                }
            }
        }
    }
}