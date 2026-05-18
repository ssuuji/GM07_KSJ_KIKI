namespace Models
{
    /*
        [MemoryPiece.cs]
        - 기억 조각 정보
    */
    public class MemoryPiece
    {
        public string Title { get; private set; }       //제목
        public string Description { get; private set; } //설명
        public bool IsUnlock { get; set; }              //해금여부

        public MemoryPiece(string title,string description,bool isUnlock = false)
        {
            Title = title;
            Description = description;
            IsUnlock = isUnlock;
        }
    }
}