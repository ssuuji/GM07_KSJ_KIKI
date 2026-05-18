using Data;
using Models;

namespace Managers
{
    /*
        [DayManager.cs] 
        - DAY 진행 관리

        [ 설명 ]
        GetCurrentDay() : 현재 DAY정보 반환
        NextDay()       : 다음 Day설정
    */
    public static class DayManager
    {
        // 현재 DAY
        public static int CurrentDay { get; private set; } = 1;

        // 현재 DAY정보 
        public static Day GetCurrentDay()
        {
            return DayData.GetDay(CurrentDay);
        }

        // 다음 DAY진행
        public static void NextDay()
        {
            CurrentDay++;
        }
    }
}