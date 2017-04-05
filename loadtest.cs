using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace StressTest
{
    class Program
    {
        private static ManualResetEvent quitEvent = new ManualResetEvent(false);
        private static long counter = 0;

        // How many threads should be running at peak load.
        const int NUM_THREADS = 150;

        // How many minutes the test should run with all threads active.
        const int TIME_AT_PEAK_QPS = 1; // minutes

        // How many seconds to wait between starting threads.
        // Shouldn't be set below 30 seconds.
        const int DELAY_BETWEEN_THREAD_START = 50; //milliseconds

        static void ThreadProc()
        {
            Console.WriteLine("Thread started: {0}", Thread.CurrentThread.Name);

            while (!quitEvent.WaitOne(0))
            {
                string url = "http://www.google.com.ua/images/srpr/logo3w.png";
                var get = (HttpWebRequest)WebRequest.Create(url);
                get.Proxy = null;
                get.KeepAlive = true;

                // WebProxy myProxy = new WebProxy("myproxy", 80);
                // myProxy.BypassProxyOnLocal = true;
                // wrGETURL.Proxy = WebProxy.GetDefaultProxy();
                using (var response = get.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            reader.ReadToEnd();
                            Interlocked.Increment(ref counter);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;

            int runtime = (TIME_AT_PEAK_QPS * 60 + DELAY_BETWEEN_THREAD_START / 60 * NUM_THREADS);
            Console.WriteLine("Total runtime will be: {0} seconds", runtime);

            // create threads
            var threads = new List<Thread>(NUM_THREADS);
            for (int i = 0; i < NUM_THREADS; ++i)
            {
                var t = new Thread(ThreadProc);
                t.Name = string.Format("Thread-{0}", i);
                threads.Add(t);
                t.Start();
                Thread.Sleep(DELAY_BETWEEN_THREAD_START);
            }

            // reset counter
            var start = DateTime.Now;
            Interlocked.Exchange(ref counter, 0);
            System.Console.WriteLine();
            Thread.Sleep(1500);

            while (true)
            {
                var delta = (DateTime.Now - start).TotalSeconds;
                var count = Interlocked.Read(ref counter);
                // print stats
                System.Console.Write("\r                                                         ");
                System.Console.Write("\rThroughput: {0}", counter / (double)delta);

                if (delta > TIME_AT_PEAK_QPS * 60)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            System.Console.WriteLine();

            // quit
            quitEvent.Set();
            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
	
	//...
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	// Igor Kalnitsky & Roman Podolyaka, © 2012, http://xsnippet.org/359079/
}
