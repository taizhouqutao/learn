using System;

namespace Cols
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");  

            //Console.WriteLine(Test(Get,1,2));
            EnventClass.main();
        }

        public static int Test(Func<int, int, int> func,int i,int j)
        {
            return func(i, j);
        }

        public static int test<T1,T2>(Func<T1, T2, int> func, T1 t1, T2 t2)
        {
            return func(t1, t2);
        }

        public static int Get(int i,int j)
        {
            return i + j;
        }
    }
}
