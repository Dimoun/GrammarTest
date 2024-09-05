using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarTest
{
    internal class InterlockedDemo
    {
        private static int counter = 0;

        public void InterlockedTest()
        {
            // 创建多个线程来增加计数器的值
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(IncrementCounter);
                threads[i].Start();
            }

            // 等待所有线程完成
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Final counter value: " + counter);
        }

        private static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                Interlocked.Increment(ref counter);
            }
        }
    }
}
