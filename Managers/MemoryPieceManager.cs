using Data;
using Models;
using UI;

namespace Managers
{
    /*
        [MemoryPieceManager.cs]
        - 기억 조각 수첩 관리
    */
    public class MemoryPieceManager
    {
        private List<MemoryPiece> memoryPieces = MemoryPieceData.GetMemoryPieces();
        public void Unlock(int index)
        {
            if (index < 0 || index >= memoryPieces.Count)
            {
                return;
            }
            memoryPieces[index].IsUnlock = true;
        }
        public MemoryPiece GetMemoryPiece(int index)
        {
            return memoryPieces[index];
        }

        public void Run()
        {
            int selectPiece = 0;
            while (true)
            {
                UIManager.DrawMemoryPiece(memoryPieces, selectPiece);

                ConsoleKey key = InputManager.GetKey();
                if (InputManager.W(key))
                {
                    selectPiece--;
                    if (selectPiece < 0)
                    {
                        selectPiece = 0;
                    }
                }
                else if (InputManager.S(key))
                {
                    selectPiece++;
                    if (selectPiece >= memoryPieces.Count)
                    {
                        selectPiece = memoryPieces.Count - 1;
                    }
                }
                else if (InputManager.F(key))
                {
                    if (memoryPieces[selectPiece].IsUnlock)
                    {
                        UIManager.DrawMemoryDetail(memoryPieces[selectPiece]);
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