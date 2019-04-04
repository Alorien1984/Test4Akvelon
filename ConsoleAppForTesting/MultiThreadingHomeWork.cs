namespace MultiThreading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    static class MultiThreadingHomeWork
    {
        static async Task Main(string[] args)
        {

            // Creates 5 philosophers.
            var philosophersDinner = new PhilosophersCafe(countOfPhilosophers: 5, countOfLunchIntake: 3, timeForLunch: 20, timeForThink: 100);
            Console.WriteLine("========= Start time for lunch =========");

            var globalThread = new Thread(philosophersDinner.StartDinner);
            globalThread.Start();
            //globalThread.Join();
;
            // General time of lunch in cafe.
            Thread.Sleep(300);

            foreach (var statesOfPholosopher in philosophersDinner.StatesOfPhilosophers)
            {
                Console.WriteLine(statesOfPholosopher);
            }

            Console.WriteLine("========= End time for lunch =========");

            var pathsOfImages = new []
            {
                @"https://cs1.livemaster.ru/storage/49/8e/54f637bae96d1486f5bc5a241cun--aksessuary-platok-pop-art.jpg",
                @"https://farm2.staticflickr.com/1623/26604365275_1173dc0641_b.jpg",
                @"https://st.kp.yandex.net/im/poster/3/0/3/kinopoisk.ru-It-3033107.jpg",
                @"https://i2.rozetka.ua/goods/1833121/13562467_images_1833121313.jpg"
            };

            LoadAndSaveImageFromHttp imagesFromUrl = new LoadAndSaveImageFromHttp();
            int indexOfImage = 0;

            foreach (var imagePath in pathsOfImages)
            {
                await imagesFromUrl.LoadImageByPath(indexOfImage.ToString(), imagePath);
                indexOfImage++;
            }

            imagesFromUrl.ImageData.CompleteAdding();
            await imagesFromUrl.SaveImagesByPath(imagesFromUrl.ImageData);
            Console.WriteLine("Completed saving files");
            await imagesFromUrl.ClearAllImages();
            Console.WriteLine("Completed clearing collection of images");
            Console.ReadLine();
        }

        public static void SeparateMethod()
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
        }

    }
}
