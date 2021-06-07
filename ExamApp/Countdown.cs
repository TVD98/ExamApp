using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExamApp
{
    public delegate void Notify();
    class Countdown
    {
        public event Notify CountdownFinished;
        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                if(time == 0)
                {
                    CountdownFinished?.Invoke();
                    Pause();
                    return;
                }
                time = value;
            }
        }
        public bool IsStarting { get; set; }

        private UIClient uIClient;
        private Timer timer;
        private int time;
        private readonly int defaultTime;

        private const int defaultInterval = 1000;

        public Countdown(int time)
        {
            this.time = time;
            defaultTime = time;
            uIClient = new UIClient();
            timer = new Timer
            {
                Interval = defaultInterval,
            };
            timer.Elapsed += Timer_Elapsed;
        }

        public void Show()
        {
            PrintTime();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time--;
            PrintTime();
        }

        private void PrintTime()
        {
            uIClient.Write(String.Format("Time: {0}         ", Time), true, 0, 0);
        }

        public void Start()
        {
            if (IsStarting)
            {
                Restart();
                return;
            }
            timer.Enabled = true;
            IsStarting = true;
        }

        private void Restart()
        {
            Pause();
            Time = defaultTime;
            PrintTime();
            Start();
        }

        private void Pause()
        {
            timer.Enabled = false;
            IsStarting = false;
        }

    }
}
