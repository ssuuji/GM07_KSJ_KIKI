using Models;

namespace Data
{
    /*
        [DayData.cs] Models.Day.cs
        - DAY별 데이터 관리
        - DAY별 날씨 / 메시지 저장
    */
    public static class DayData
    {
        private static Dictionary<int, Func<Day>> days = new Dictionary<int, Func<Day>>()
        {
            {1,()=> new Day(1, "\t[맑은 아침]", "\t\"키키님,\n\t 별빛 우체국 첫출근을 환영합니다!\"") },
            {2,()=> new Day(2, "\t[늦은 밤]", "\t\"키키님,\n\t 오늘은 늦은 편지가 도착했어요.\"") },
            {3,()=> new Day(2, "\t[미완성]", "...") },
        };

        public static Day GetDay(int day)
        {
            if (days.TryGetValue(day, out Func<Day> getDay))
            {
                return getDay();
            }

            return null;
        }
    }
}