using System;
using System.Collections.Generic;
using System.Linq;
    
    using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleConsole
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class AsyncSample
    {
        public static void TestFunc()
        {

        }
        public static async Task BakeBFAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready " + Thread.CurrentThread.ManagedThreadId);
            //Thread eggsThread = new Thread((FryEggs));
            //eggsThread.Start();
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);
            var ta = TestAsync();
            Task.WaitAll(ta);

            await Task.Run(TestAsync);
            await Task.Run(TestFunc);
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready " + Thread.CurrentThread.ManagedThreadId);
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready " + Thread.CurrentThread.ManagedThreadId);
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready " + Thread.CurrentThread.ManagedThreadId);
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Breakfast is ready! " + Thread.CurrentThread.ManagedThreadId);
        }

        static async Task TestAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Test Aync");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice " + Thread.CurrentThread.ManagedThreadId);
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast " + Thread.CurrentThread.ManagedThreadId);

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast " + Thread.CurrentThread.ManagedThreadId);

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster " + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Start toasting... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster " + Thread.CurrentThread.ManagedThreadId);

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("cooking first side of bacon... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon " + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("cooking the second side of bacon... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate " + Thread.CurrentThread.ManagedThreadId);

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("cooking the eggs ... " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate " + Thread.CurrentThread.ManagedThreadId);

            return new Egg();
        }

        private static void FryEggs(object? howMany)
        {
            Console.WriteLine("Warming the egg pan... " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine($"cracking {howMany} eggs " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("cooking the eggs ... " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("Put eggs on plate " + Thread.CurrentThread.ManagedThreadId);

            //return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee " + Thread.CurrentThread.ManagedThreadId);
            return new Coffee();
        }
    }

    class AsyncTest
    {
        
        public AsyncTest()
        {
            Task<string> task = GetUrlContentLengthAsync();
            Console.WriteLine("dfdsf");
            task.Wait();
            string res = task.Result;
            
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1 
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() => {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                                         Task.CurrentId, taskData,
                                                          Thread.CurrentThread.ManagedThreadId);
            });
            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();
        }
        public void fun1(object obj)
        {
            Console.WriteLine("func1");
        }

        public object fun2()
        {
            Console.WriteLine("func2");
            return null;
        }

        public async Task GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask =
                client.GetStringAsync("https://docs.microsoft.com/dotnet");

            //Task.Run(() => { DoIndependentWork(); });

            DoIndependentWork();

            string contents = await getStringTask;


            await Task.Run(() => Thread.Sleep(10000));

            //return contents;
        }

        void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
    }
}

