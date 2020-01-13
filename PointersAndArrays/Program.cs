using System;

namespace PointersAndArrays
{
    class Program
    {
        public unsafe void Method()
        {
            int[] iArray = new int[10];
            for (int count = 0; count < 10; count++)
            {
                iArray[count] = count * count;
            }

            //the fixed keyword tells Garbage Collector not to move an object (pinning). That means this fixes in memory the location of the value types pointed to.
            //should only be done when absolutely necessar since fixed objects may cause fragmentation of the heap.
            fixed (int* ptr = iArray)
            { 
                Display(ptr);
                //Console.WriteLine(*(ptr+2));  
                //Console.WriteLine((int)ptr); 
            }  
        }

        public unsafe void Display(int* pt)
        {
            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine(*(pt + i));
            }
        }

        unsafe static void Main(string[] args)
        {
            Program p = new Program();
            p.Method();

            int x = 1;
            int* pointer = &x;
            Console.WriteLine(*(pointer + 1));
        }
    }
}
