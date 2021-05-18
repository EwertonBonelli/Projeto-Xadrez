using System;
using tabuleiro; // Importando o arquivo tabuleiro para comunicação com a classe Posicao.
using xadrez; // Importando o diretorio das classes.

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosicao());

            
            Console.WriteLine();
        }
    }
}
