using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskPanel.TestConsole
{
    class TestConsole
    {
        static void Main(string[] args)
        {
            //XmlStorage.LoadAndSave();
            TestDateTime();
        }

        static void TestDateTime()
        {
            DateTime now = DateTime.Now;
            long tics = now.Ticks;

            DateTime reconstructed = new DateTime(tics);

            Console.WriteLine("Nonw: {0}, Tics: {1}, Rec: {2}", now, tics, reconstructed);
            Console.ReadKey(true);
        }
    }
}
