using Models;

namespace Data
{
    /*
        [MemoryPieceData.cs] 
        - 기억 조각 원본 데이터 관리

        [ 흐름 ]
        GetMemoryPieces() : 기억 조각별 정보 반환
    */
    public static class MemoryPieceData
    {
        public static List<MemoryPiece> GetMemoryPieces()
        {
            return new List<MemoryPiece>()
            {
                new MemoryPiece("기억 조각 [00]","희미한 목소리가 귓가를 스쳐 지나갔다."),
                new MemoryPiece("기억 조각 [01]","누군가의 따뜻한 손길이 느껴졌다."),
                new MemoryPiece("기억 조각 [02]","밤하늘 아래 빗자루가 흔들리고 있었다.")
            };
        }
    }
}