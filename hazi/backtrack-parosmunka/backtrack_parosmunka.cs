using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parosmunka
{
    internal class backtrack_Parosmunka
    {
        static bool Rossz(int hova, int[] isk)
            => (hova == -1) || (isk[hova] - 1 == -1);
        static (bool, int, int) FuggolegesKeres(int[][] tan, int[] isk, int i, int[] sor)
        {
            int j = sor[i] + 1;
            while (j < 2 && Rossz(tan[i][j], isk))
                j++;

            return (2 <= j ? (j < 2, -1, -1) : (j < 2, tan[i][j], j));
        }

        static int[] Parosmunka(int N, int[][] tan, int[] isk)
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
            int N = int.Parse(Console.ReadLine());
            int[][] diakpreferencia = new int[N][];
            #region beolvasas
            string[] line;
            for (int i = 0; i < N; i++)
            {
                line = Console.ReadLine().Split(',');
                diakpreferencia[i] = new int[N-1];
                for (int j = 0; j < N-1; j++)
                    diakpreferencia[i][j] = int.Parse(line[j])-1;
            }
            #endregion

            //string stringforma = string.Join(" ", Parosmunka(N, tanulok, iskolak));

            //Console.WriteLine(stringforma);
        }
    }
}