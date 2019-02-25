using System;

namespace CustomConversions
{
    public static class Extensions
    {
        public static void DoNothing(this Rectangle r, int i)
        {
            for (int j = 0; j < i; j++)
                Console.Write(j);
            
        }
    }
}
