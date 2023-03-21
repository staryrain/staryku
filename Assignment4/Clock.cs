using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_clock
{
    public delegate void ClockHander(object sender, ClockEventArgs arges);
    public class ClockEventArgs {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }

    public class ClockTick
    {
        public event ClockHander Tick;
        public void CreatTick(int x,int y,int z)
        {
            Console.WriteLine($"Clock time is {x} hour,{y} minute,{z} second");
            ClockEventArgs args = new ClockEventArgs() { Hour = x, Minute = y, Second = z };
            Tick(this, args);
        }
        
    }
    public class ClockAlarm
    {
        public event ClockHander Alarm;
        public void Creatalarm(int x, int y, int z)
        {
            Console.WriteLine($"Time now is {x} hour,{y} minute,{z} second");
            ClockEventArgs args = new ClockEventArgs() { Hour = x, Minute = y, Second = z };
            Alarm(this, args);
        }

    }

    public class ClockConsole
    {
        public ClockTick clocktick=new ClockTick();
        public ClockAlarm clockalarm=new ClockAlarm();
        public ClockConsole()
        {
            clocktick.Tick += new ClockHander(Ckt_Tick);
            clockalarm.Alarm += new ClockHander(Ckt_Alarm);
        }
        void Ckt_Tick(object sender, ClockEventArgs args) {
            Console.WriteLine("Clock is beginning");
        }
        void Ckt_Alarm(object sender, ClockEventArgs args)
        {
            Console.WriteLine("Clock is alarming");
        }

    }
    class program {
        static void Main(string[] args)
        {
            ClockConsole console1 = new ClockConsole();
            console1.clocktick.CreatTick(6,0,0);
            console1.clockalarm.Creatalarm(6,0,0);
            Console.ReadLine();
        }
     }
    
}
