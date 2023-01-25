using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nKiralyno
{
    internal class backtrack_nkiralyno
    {
        static bool UtikEgymast(int a1, int b1, int a2, int b2)
            => (!(a1==a2 && b1==b2) && (Math.Abs(a1 - a2) == Math.Abs(b1 - b2) || b1 == b2));
        static bool Rossz(int i, int j, int[] J)
        {
            for (int ix = 0; ix < i; ix++)
                if (UtikEgymast(ix, J[ix], i, j))
                    return true;
            return false;
        }
        static (bool, int) FuggolegesKeres(int i, int[] J)
        {
            int j = J[i] + 1;  //-1es inicializálás itt lesz 0-ás index
            while (j < J.Length && Rossz(i, j, J))
                j++;
            return (j < J.Length, j);
        }

        static int[] NQueens(int N)
        {
            int[] J = new int[N];
            for (int ix = 0; ix < N; ix++)
                J[ix] = -1;

            // jobbra-balra keres
            int i = 0;
            while(0 <= i && i < N)
            {
                (bool van, int j) = FuggolegesKeres(i, J);
                if (van)
                    J[i++] = j;  // like: J[i] = j; i++;
                else
                    J[i--] = -1;
            }
            return J;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int N = int.Parse(input);
            string stringforma = string.Join(" ", NQueens(N));   //beolvasás
            Console.WriteLine(stringforma);
        }
    }
}
