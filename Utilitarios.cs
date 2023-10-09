using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class Utilitarios
{
    public static void EsperarEnter()
    {
        WriteLine("\n\n\nDigite [ENTER] para terminar a operação");
        ReadLine();
        Clear();
    }
    public static void EscreverXY(int col, int lin, string texto)
    {
        SetCursorPosition(col, lin);
        Write(texto);
    }
}


