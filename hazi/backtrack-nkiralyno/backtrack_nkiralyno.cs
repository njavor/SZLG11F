using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nkiralyno
{
    internal class backtrack_nkiralyno
    {
        static int[] tabla;
        static int N;

        static bool Siker(int azoszlop, int asor)
        {
            for (int i = 0; i < azoszlop; i++)
                if (asor == tabla[i] || azoszlop - asor == i - tabla[i] || azoszlop + asor == i + tabla[i])
                    return false;
            return true;
        }

        static void Nkiralyno(int oszlop)
        {
            if (oszlop == N)
            {
                for (int i = 0; i < N; i++)
                    Console.Write(tabla[i]+1 + " ");
                N = 0;
            }

            for (int sor = 0; sor < N; sor++)
            {
                if (Siker(oszlop, sor))
                {
                    tabla[oszlop] = sor;
                    Nkiralyno(oszlop + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            tabla = new int[N];
            
            Nkiralyno(0);
            if (N != 0) { Console.WriteLine(-1); }
        }
    }
}