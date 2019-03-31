namespace MultiThreading
{
    using System;
    using System.Threading;
    using ConsoleAppForTesting;

    public static class MultiThreadingHomeWork
    {
        static void Main(string[] args)
        {

            //var myMutex = new Mutex();
            //var xLocker = 0;
            //Object locker = new {};
            //Console.WriteLine("Thread # {0} now start working, locker = {1} ", Thread.CurrentThread.ManagedThreadId, xLocker);
            //Thread myThread;
            //myThread = new Thread(() =>
            //{
            //    Console.WriteLine("Thread in new thread # {0} now start working, locker = {1} ", Thread.CurrentThread.ManagedThreadId, xLocker);
            //    //Thread.Sleep(400);
            //    lock (locker)
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine("Second Locker in {0}", Thread.CurrentThread.ManagedThreadId);
            //        xLocker++;
            //        Console.WriteLine("Thread in new thread # {0} was stopped, locker = {1}",
            //            Thread.CurrentThread.ManagedThreadId, xLocker);
            //    }

            //    myMutex.WaitOne();
            //    Console.WriteLine("Thread # {0} in mutex code!", Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(200);
            //    Console.WriteLine("Thread # {0} out from mutex code!", Thread.CurrentThread.ManagedThreadId);
            //    myMutex.ReleaseMutex();

            //});

            //var MyThread2 = new Thread(() =>
            //{
            //    Console.WriteLine("Thread in new thread # {0} now start working, locker = {1} ", Thread.CurrentThread.ManagedThreadId, xLocker);
            //    //Thread.Sleep(400);
            //    lock (locker)
            //    {
            //        Console.WriteLine("Second Locker in {0}", Thread.CurrentThread.ManagedThreadId);
            //        xLocker++;
            //        Thread.Sleep(500);
            //        Console.WriteLine("Thread in new thread # {0} was stopped, locker = {1}",
            //            Thread.CurrentThread.ManagedThreadId, xLocker);
            //    }

            //    myMutex.WaitOne();
            //    Console.WriteLine("Thread # {0} in mutex code!", Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(200);
            //    Console.WriteLine("Thread # {0} out from mutex code!", Thread.CurrentThread.ManagedThreadId);
            //    myMutex.ReleaseMutex();
            //});

            //MyThread2.Start();
            //myThread.Start();
            //lock (locker)
            //{
            //    Console.WriteLine("General Locker in {0}", Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(1000);
            //    xLocker--;
            //    Console.WriteLine("General Locker gert left from {0}", Thread.CurrentThread.ManagedThreadId);
            //}

            //myMutex.WaitOne();
            //Console.WriteLine("Thread # {0} in mutex code!", Thread.CurrentThread.ManagedThreadId);
            //Thread.Sleep(200);
            //Console.WriteLine("Thread # {0} out from mutex code!", Thread.CurrentThread.ManagedThreadId);
            //myMutex.ReleaseMutex();

            //Console.WriteLine("Thread # {0} was stopped, locker = {1}", Thread.CurrentThread.ManagedThreadId, xLocker);

            // Creates 5 philosophers.
            var philosophersDinner = new PhilosophersCafe(5,3, 20, 100);
            Console.WriteLine("========= Start time for lunch =========");

            // General time of lunch in cafe.
            Thread.Sleep(300);

            foreach (var statesOfPholosopher in philosophersDinner.StatesOfPhilosophers)
            {
                Console.WriteLine(statesOfPholosopher);
            }

            Console.WriteLine("========= End time for lunch =========");

            Console.ReadLine();
            foreach (var statesOfPholosopher in philosophersDinner.StatesOfPhilosophers)
            {
                Console.WriteLine(statesOfPholosopher);
            }
        }

        
    }
}
