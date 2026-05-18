using System.Security.Cryptography;

namespace Models
{
    /*
        [Day.cs]
        - DAY 정보 저장(DAY번호, 날씨, 메세지)
    */
    public class Day
    {
        public int Daynumber { get; private set; }  // DAY 번호
        public string Weather { get; private set; } // 날씨
        public string Message { get; private set; } // 메세지

        public Day(int dayNumber, string weather, string message)
        {
            Daynumber = dayNumber;
            Weather = weather;
            Message = message;
        }
    }
}