using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public delegate void ClockHandler(object sender, TimeEventArgs args); 

    public class TimeEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    public class SetClock
    {
        private int hour, minute, second;
        private int AlarmHour, AlarmMinute;
        private int AlarmSecond = 0;
        public event ClockHandler OnTick;
        public event ClockHandler OnAlarm;
        public SetClock(int hour, int minute)
        {
            if (hour < 24 && minute < 60)
            {
                this.hour = hour;
                this.minute = minute;
                this.second = 0;
            }
            else
            {
                Console.WriteLine("输入错误，时间改为0:0:0");
                this.hour = 0;
                this.minute = 0;
                this.second = 0;
            }
        }
        public void GetClock()
        {
            Console.WriteLine("设置的时钟时间为" + hour + ":" + minute + ":" + second);
        }
        public void SetAlarm(int hour, int minute)
        {
            AlarmHour = hour;
            AlarmMinute = minute;
        }
        public void GetAlarm()
        {
            Console.WriteLine("设置的闹钟时间为" + AlarmHour + ":" + AlarmMinute);
        }
        public void Run()
        {
            while (true)
            {
                second++;
                if (second == 60)
                {
                    second = 0;
                    minute++;
                }
                if (minute == 60)
                {
                    minute = 0;
                    hour++;
                }
                if (hour == 24)
                {
                    hour = 0;
                }

                TimeEventArgs args = new TimeEventArgs() { Hour = hour, Minute = minute, Second = second };
                
                OnTick(this, args);
                if (hour == AlarmHour && minute == AlarmMinute && second == AlarmSecond)
                {
                    OnAlarm(this, args);
                }
                
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public class MyClock
    {
        public SetClock myClock;
        public MyClock(int hour, int minute)
        {
            myClock = new SetClock(hour, minute);
            myClock.OnTick += OnTick1;
            myClock.OnAlarm += OnAlarm1;
        }
        void OnTick1(object sender, TimeEventArgs args)
        {
            Console.WriteLine("Tick,现在时间：" + args.Hour + ":" + args.Minute + ":" + args.Second);
        }
        void OnAlarm1(object sender, TimeEventArgs args)
        {
            Console.WriteLine("Alarm，闹钟响了");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("为了实验方便将时间加速了10倍");
            
            MyClock myClockTest = new MyClock(25, 30);
            myClockTest.myClock.GetClock();

            myClockTest.myClock.SetAlarm(0, 1);
            myClockTest.myClock.GetAlarm();

            myClockTest.myClock.Run();
        }
    }
}

