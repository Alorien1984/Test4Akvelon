namespace MultiThreading
{
    using System.Threading;

    /// <summary>Task about dining philosophers problem</summary>
    public class PhilosophersCafe
    {
        /// <summary>Gets the philosophers.</summary>
        /// <value>The philosophers.</value>
        private Thread[] Philosophers { get; }
        /// <summary>The forks for philosophers.</summary>
        private SemaphoreSlim[] forks;
        /// <summary>The time during which the philosopher eats.</summary>
        private int timeForPhilosopherLunch;
        /// <summary>The time during which the philosopher thinks.</summary>
        private int timeForPhilosopherThink;
        /// <summary>The count of dinner intake for each of philosophers.</summary>
        private int countOfLunchIntake;
        /// <summary>Gets the states of each of philosophers.</summary>
        /// <value>The states of each philosophers.</value>
        public string[] StatesOfPhilosophers { get;}
        /// <summary>The count of philosophers.</summary>
        private int countOfPhilosophers;

        /// <summary>Initializes a new instance of the <see cref="PhilosophersCafe"/> class.</summary>
        /// <param name="countOfPhilosophers">The count of philosophers.</param>
        /// <param name="countOfLunchIntake">The count of dinner intake.</param>
        /// <param name="timeForLunch">The time during which the philosopher eats.</param>
        /// <param name="timeForThink">The time during which the philosopher thinks.</param>
        public PhilosophersCafe(int countOfPhilosophers, int countOfLunchIntake, int timeForLunch, int timeForThink)
        {
            this.countOfPhilosophers = countOfPhilosophers;
            Philosophers = new Thread[countOfPhilosophers];
            forks = new SemaphoreSlim[countOfPhilosophers];
            StatesOfPhilosophers = new string[countOfPhilosophers];
            timeForPhilosopherLunch = timeForLunch;
            timeForPhilosopherThink = timeForThink;
            this.countOfLunchIntake = countOfLunchIntake;
        }

        /// <summary>Starts the dinner.</summary>
        public void StartDinner()
        {
            for (var indexOfPhilosopher = 0; indexOfPhilosopher < countOfPhilosophers; indexOfPhilosopher++)
            {
                Philosophers[indexOfPhilosopher] = new Thread(StartLunchForCurrentPhilosopher);
                forks[indexOfPhilosopher] = new SemaphoreSlim(1, 1);
                StatesOfPhilosophers[indexOfPhilosopher] += $"Philosopher# {indexOfPhilosopher} is coming into cafe || ";
                Philosophers[indexOfPhilosopher].IsBackground = true;
                Philosophers[indexOfPhilosopher].Start(indexOfPhilosopher);
            }
        }

        /// <summary>Starts the dinner for current philosopher.</summary>
        /// <param name="indexOfPhilosopher">The index of philosopher.</param>
        void StartLunchForCurrentPhilosopher(object indexOfPhilosopher)
        {
            var index = (int) indexOfPhilosopher;
            var repeatLunch = countOfLunchIntake;
            while (repeatLunch > 0)
            {
                // State of thinking process
                StatesOfPhilosophers[index] += "thinking =>";
                Thread.Sleep(timeForPhilosopherThink);
                var leftFork = forks[index];

                // Cheсks for last fork
                var rightFork = (index == countOfPhilosophers-1) 
                    ? forks[0]
                    : forks[index + 1];
            
                // Teaches the philosopher has to respect the neighbor
                if (index % 2 == 1)
                {
                    var temp = leftFork;
                    leftFork = rightFork;
                    rightFork = temp;
                }

                // State of hunger
                leftFork.Wait();
                StatesOfPhilosophers[index] +="finding 2nd fork =>";
                Thread.Sleep(20);
                rightFork.Wait();
                // State of eating process
                StatesOfPhilosophers[index] += "eating =>";
                Thread.Sleep(timeForPhilosopherLunch);
                rightFork.Release();
                leftFork.Release();
                StatesOfPhilosophers[index] += "put down both forks => ";
                repeatLunch--;
            }

            // State of satisfaction
            StatesOfPhilosophers[index] += "getting out of cafe!";
        }
    }
}