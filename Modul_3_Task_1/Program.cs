using System;

namespace Modul_3_Task_1
{
    public class Program
    {
        public static void Main()
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Remove(0);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
