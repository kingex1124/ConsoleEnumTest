using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // meetingDays =  2^0 + 2^2 + 2^4
            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine(meetingDays);
            // Output:
            // Monday, Wednesday, Friday

            // workingFromHomeDays = 2^1 + 2^4
            Days workingFromHomeDays = Days.Thursday | Days.Friday;

            // meetingDays & workingFromHomeDays = 2^4 (取交集)
            Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
            // Output:
            // Join a meeting by phone on Friday

            //meetingDays & Days.Tuesday = 2^0 + 2^2 + 2^4 與 2^1 沒有交集 所以是 0
            bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
            Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
            // Output:
            // Is there a meeting on Tuesday: False

            var a = (Days)37; // 37 = 2^5 + 2^2 + 2^0 (從大的開始扣)
            Console.WriteLine(a);
            // Output:
            // Monday, Wednesday, Saturday
        }

        // 加上 Flags 會顯示內容 不然只會顯示2進位的數字
        [Flags]
        public enum Days
        {
            None = 0,  // 0
            Monday = 1,  // 1 = 2^0  一
            Tuesday = 2,  // 2 = 2^1 二
            Wednesday = 4,  // 4 = 2^2 三
            Thursday = 8,  // 8 = 2^3 四
            Friday = 16,  // 16 = 2^4 五
            Saturday = 32,  // 32 = 2^5 六
            Sunday = 64,  // 64 = 2^6 日
            Weekend = Saturday | Sunday
        }
    }
}
