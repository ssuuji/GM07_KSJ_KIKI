namespace Models
{
    /*
        * 대사출력과 조각은 추후 나누는게 좋을거같음
        [Quest.cs]
        - 배달 퀘스트 정보 저장

        [ 설명 ]
        Accept()   : 퀘스트 수락
        Complete() : 퀘스트 완료
    */
    public enum QuestState { NotAccepted, Accepted, Completed }

    public class Quest
    {
        public string Title { get; private set; }       //제목
        public string Place { get; private set; }       //장소
        public string Description { get; private set; } //설명
        public int RewardGold { get; private set; }     //보상골드
        public string ItemKey { get; private set; }     //보상아이템
        public string MonsterKey { get; private set; }  //몬스터
        public QuestState State { get; private set; }   //퀘스트 상태 (수락/완료)

        //대사
        public string DeliveryContinueMsg { get; private set; }
        public string DeliveryArriveMsg { get; private set; }
        public string DeliveryRewardMsg { get; private set; }
        //조각
        public bool HasMemoryPiece { get; private set; }
        public int MemoryPieceIndex { get; private set; }
        public string MemorySceneMsg { get; private set; }
        

        public Quest
        (
            string title,
            string place,
            string description,
            int rewardGold,
            string itemKey,
            string monsterKey,
            string deliveryContinueMsg,
            string deliveryArriveMsg,
            string deliveryRewardMsg,
            string memorySceneMsg,
            bool hasMemoryPiece,
            int memoryPieceIndex
        )
        {
            Title = title;
            Place = place;
            Description = description;
            RewardGold = rewardGold;
            ItemKey = itemKey;
            MonsterKey = monsterKey;
            State = QuestState.NotAccepted;
            //
            DeliveryContinueMsg = deliveryContinueMsg;
            DeliveryArriveMsg = deliveryArriveMsg;
            DeliveryRewardMsg = deliveryRewardMsg;
            MemorySceneMsg = memorySceneMsg;
            HasMemoryPiece = hasMemoryPiece;
            MemoryPieceIndex = memoryPieceIndex;
        }
        public void Accept() { State = QuestState.Accepted; }
        public void Complete() { State = QuestState.Completed; }
    }
}