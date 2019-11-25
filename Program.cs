using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayTest
{
    class Program
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //TODO: Take # of gb as an argument. Could do a select: if 1, a1, if 2, a2...
            int each = 2; // number of 2GB chunks
            // https://docBs.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element
            // The maximum index in any single dimension is 2,147,483,591 (0x7FFFFFC7) for byte arrays and arrays of single - byte structures, and 2, 146, 435, 071(0X7FEFFFFF) for other types. *BUT* "The maximum number of elements in an array is UInt32.MaxValue."
            // Number of elements in the second dimension of the array will be close to 2GB
            ulong elements = 0x7FFFFFC7; // Int32.MaxValue - 56; // max must be a 55-byte overhead... 900; //zero-based
            Console.WriteLine("Using " + elements.ToString() + " vs " + Int32.MaxValue.ToString());

            ulong chunk = (ulong)Math.Pow(elements, each);

            DateTime timeStart;
            DateTime timeStop;
            TimeSpan timeElapsed;

            Console.SetWindowSize(120, 10);

            // try
            {
                timeStart = DateTime.Now;
                Byte[,] bigArray0 = new byte[0x3, 0x7FFFFFC7];
                //Byte[,] bigArray0 = new byte[each, elements];
                Byte[,] bigArray1 = new byte[each, elements];
                Byte[,] bigArray2 = new byte[each, elements];
                Console.WriteLine("Byte[,] bigMatrix1 = new byte[" + each.ToString() + ", " + elements.ToString() + "]");
                // ulong len = (ulong)(bigArray0.Length);
                // Console.WriteLine("Length = " + bigArray.Length.ToString());
                Console.WriteLine("Initializing...");
                for (int i = 0; i <= each - 1; i++)
                {
                    for (ulong j = 0; j <= elements - 1; j++)
                    {
                        bigArray0[i, j] = 23;
                    }
                }
                for (int i = 0; i <= each - 1; i++)
                {
                    for (ulong j = 0; j <= elements - 1; j++)
                    {
                        bigArray1[i, j] = 23;
                    }
                }
                for (int i = 0; i <= each - 1; i++)
                {
                    for (ulong j = 0; j <= elements - 1; j++)
                    {
                        bigArray2[i, j] = 23;
                    }
                }

                timeStop = DateTime.Now;
                timeElapsed = timeStop.Subtract(timeStart);
                Console.WriteLine(timeElapsed.TotalMilliseconds.ToString() + "ms");
            }
            // catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.WriteLine("Press Enter to exit and free memory");
            Console.ReadLine();
        }
    }
}
