using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iskolavalasztas
{
    internal class backtrack_Iskolavalasztas
    {
        static bool Rossz(int hova, int[] isk)
            => (hova == -1) || (isk[hova] - 1 == -1);
        static (bool, int, int) FuggolegesKeres(int[][] tan, int[] isk, int i, int[] sor)
        {
            int j = sor[i]+1;
            while (j < 2 && Rossz(tan[i][j], isk))
                j++;
            
            return (2 <= j ? (j < 2, -1, -1) : (j < 2, tan[i][j], j));
        }

        static int[] Iskolavalasztas(int N, int[][] tan, int[] isk)
        {
            int[] J = new int[N];
            int[] sor = new int[N];
            for (int ix = 0; ix < N; ix++)
            {
                J[ix] = -1;
                sor[ix] = -1;
            }
                
            // jobbra-balra
            int i = 0;
            while (0 <= i && i < N)
            {
                (bool van, int j, int asor) = FuggolegesKeres(tan, isk, i, sor);
                if (van)
                {
                    isk[j]--;
                    sor[i] = asor;
                    J[i++] = j;
                }
                else
                {
                    sor[i] = -1;
                    J[i--] = -1;
                    isk[J[i]]++;
                }
            }

            for (int ixx = 0; ixx < N; ixx++)
                J[ixx]++;
            return J;
        }
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            (int N, int M) = (int.Parse(firstLine[0]), int.Parse(firstLine[1]));
            (int[][] tanulok, int[] iskolak) = (new int[N][], new int[M]);
            #region beolvasas
            string[] line;
            for (int i = 0; i < N; i++)
            {
                line = Console.ReadLine().Split(' ');
                tanulok[i] = new int[] { int.Parse(line[0])-1, int.Parse(line[1]) - 1 };
            }
            for (int i = 0; i < M; i++)
                iskolak[i] = int.Parse(Console.ReadLine());
            #endregion

            string stringforma  = string.Join(" ",Iskolavalasztas(N, tanulok, iskolak));

            Console.WriteLine(stringforma);
        }
    }
}