using Models;

namespace Data
{
    /*
        [QuestData.cs] Models.Quest.cs
        - DAY별 퀘스트 원본 데이터 관리
        - 배달지 / 설명 / 보상 / 관련 몬스터 설정
        - 퀘스트별 대사 및 기억 조각 연출 관리

        [ 흐름 ]
        GetQuests() : DAY에 맞는 퀘스트 목록
    */
    public static class QuestData
    {
        private static Dictionary<int, List<Quest>> questTable = new Dictionary<int, List<Quest>>()
        {
            {1, new List<Quest>() {new Quest("봄꽃 씨앗", "토토 마을 꽃집", "봄꽃 씨앗을 전달해주세요.", 120, "SpringFlowerSeed", "ForestGuardianBird",
                                             // 배달 이동
                                             "\t[은은한 꽃향기가 바람을 따라 퍼지고 있다.]\n" +
                                             "\t[작은 꽃집 앞에 누군가가 키키를 기다리고 있었다.]",
                                             
                                             // 도착
                                             "\t\"어머, 네가 새로 온 배달부구나?\"\n\n" +
                                             "\t\"봄꽃 씨앗을 기다리고 있었단다.\"\n\n" +
                                             "\t[은은한 꽃향기가 바람을 따라 퍼지고 있다.]",
                                             
                                             // 보상
                                             "\t\"정말 고마워, 키키!\"",
                                             
                                             // 기억 조각
                                             "\t\"잠깐 키키야, 추운데 따뜻한 차 한잔 하고 돌아가렴.\"\n\n" +
                                             "\t[따뜻한 기억이 떠오르는 것 같다.]", true,1),

                                    new Quest("달빛 우유", "달빛 호수", "달빛 우유를 전달해주세요.", 150, "MoonMilk", "MoonWolf",
                                             // 배달 이동
                                             "\t[호수 위로 잔잔한 물안개가 피어오르고 있다.]\n" +
                                             "\t[호숫가 관리인이 키키를 발견했다.]",
                                             
                                             // 도착
                                             "\t\"달빛 우유를 가져왔구나.\"\n\n" +
                                             "\t\"오늘 밤도 호수가 조용하겠어.\"\n\n" +
                                             "\t[호수 위로 잔잔한 물안개가 피어오르고 있다.]",
                                             
                                             // 보상
                                             "\t\"덕분에 오늘 밤도 평온하겠구나.\"",
                                             // 기억 조각
                                             "", false,-1),

                                    new Quest("바람 깃털", "바람 언덕", "바람 깃털을 전달해주세요.", 200, "WindFeather", "WindSpirit",
                                             // 배달 이동
                                             "\t[풍차가 천천히 돌아가고 있다.]\n" +
                                             "\t[언덕의 관리인이 손을 흔들었다.]",

                                             // 도착
                                             "\t\"아, 바람 깃털을 가져왔네!\"\n\n" +
                                             "\t\"풍차가 다시 움직일 수 있겠어.\"\n\n" +
                                             "\t[언덕 위의 풍차가 천천히 흔들리고 있다.]",

                                             // 보상
                                             "\t\"바람이 다시 움직이기 시작했어!\"",
                                             // 기억 조각
                                             "", false,-1),
                                  }
            },

            {2, new List<Quest>() { new Quest ("밤 편지", "달빛 마을", "밤 편지를 전달해주세요.", 180, "NightLetter", "NightCrow",
                                              // 배달 이동
                                              "\t[마을의 불빛이 하나둘 어둠 속에서 반짝이고 있다.]\n" +
                                              "\t[누군가 조용히 키키를 기다리고 있었다.]",
                                              
                                              // 도착
                                              "\t\"이 편지를 정말 기다리고 있었단다.\"\n\n" +
                                              "\t\"이 밤이 오기 전까지는 말이야...\"\n\n" +
                                              "\t[마을의 불빛이 어둠 속에서 희미하게 흔들리고 있다.]",
                                              
                                              // 보상
                                              "\t\"고마워, 덕분에 마음이 놓이는구나.\"",
                                              
                                              // 기억 조각
                                              "\t\"잠깐 키키야, 그 빗자루 어딘가 익숙하구나...\"\n\n" +
                                              "\t[달빛 아래 빗자루가 빛난다.]", true, 2)
                                  }
            }
        };

        public static List<Quest> GetQuests(int day)
        {
            if (questTable.TryGetValue(day, out List<Quest> quests))
            {
                return quests;
            }
            return new List<Quest>();
        }
    }
}